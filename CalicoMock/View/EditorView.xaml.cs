using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Ink;
using Xceed.Wpf.Toolkit;
using System.IO;
using System.Windows.Threading;
using System.ComponentModel;
using System.Collections.Concurrent;
using CalicoMock.ViewModel;
using CalicoMock.Model;
using System.Data;
using System.Timers;

namespace CalicoMock.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EditorView : Window
    {
        ToolBox toolbox;
        KnowledgeContent knowledgeContent;
        RelKnowledgeContent relKnowledgeContent;

        StrokeContextMenu strokeMenu;
        bool _copying = false;
        private Stack<KeyValuePair<Stroke,int>> _undoStack;
        private Stack<KeyValuePair<Stroke, int>> _redoStack;
        private EditorViewModel _viewModel;
        
        private bool undoTracking = true;
        Dispatcher inkDispatcher;
        private BlockingCollection<Stroke> _highlighterStrokes; // Collection to hold highlighter strokes
        //TODO: multiple highlighter threads?
        private Thread _highlightManagerThread;
        private bool _captureMouseEvents = true;
        DataTable dtKnowledge;
        public System.Timers.Timer aTimer = new System.Timers.Timer();

        public EditorView(EditorViewModel evm)
        {
            InitializeComponent();
            _viewModel = evm;
            DataContext = evm;
            toolbox = new ToolBox(this);
            
            

            strokeMenu = new StrokeContextMenu(this);
            _undoStack = new Stack<KeyValuePair<Stroke, int>>(20);
            _redoStack = new Stack<KeyValuePair<Stroke, int>>(20);
            _highlighterStrokes = new BlockingCollection<Stroke>();
            inkDispatcher = icCanvas.Dispatcher;
            InitializeHighlightManager();
            
            // Bind inkcanvas stroke to activecanvas
            RebindStrokes();

            Binding newBinding = new Binding();
            newBinding = new Binding("allCanvasesView");
            newBinding.Source = _viewModel;
            lvCanvasList.SetBinding(ListView.ItemsSourceProperty, newBinding);

            newBinding = new Binding("SelectedWSName");
            newBinding.Source = _viewModel;
            cboWSNameSelector.SetBinding(ComboBox.SelectedItemProperty, newBinding);

            DBOperations.SetUpConnection();
            dtKnowledge = new DataTable();
            //UpdateListViewData();
            TimerSetUp();
            //cmdInfo.IsEnabled = false;
        }

        public void TimerSetUp()
        {         
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 60000;
            aTimer.Enabled = true;
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            aTimer.Enabled = false;           
            CheckNewKnowledge(); //test
            aTimer.Enabled = true;
        }

        public void UpdateListViewData()
        {
            //TO DO: Change data structure to get Id
            dtKnowledge.Clear();
            dtKnowledge = DBOperations.GetUsefulKnowledge();
            lvKnowledge.Items.Clear();
            foreach (DataRow row in dtKnowledge.Rows)
            {
                //idKnowledge, keywords, type, description, checked, useful;
                lvKnowledge.Items.Add(row["idKnowledge"].ToString() +":"+ row["keywords"]);
            }
        }

        public void CheckNewKnowledge()
        {
            int KnowledgeAvailable = DBOperations.CheckNewKnowledge();
            if (KnowledgeAvailable > 0)
            {
                //cmdInfo.IsEnabled = true;
                string message = "I found some related knowlege to your work! \n Click on the star icon to check it.";
                string caption = "Do you need some help?";
                System.Windows.MessageBox.Show(message,caption);
            }
        }
        public void PauseMouseCapture()
        {
            _captureMouseEvents = false;
        }

        public void ResumeMouseCapture()
        {
            _captureMouseEvents = true;
        }

        public void SelectActiveCanvas()
        {
            int ID = _viewModel.activeCanvas.ID;

            foreach (CCanvas c in lvCanvasList.Items)
            {
                if (c.ID == ID)
                    lvCanvasList.SelectedItem = c;
            }

        }

        public void RefreshWorkspaceComboBox(string selectedItem)
        {

            cboWSNameSelector.Items.Clear();
            cboWSNameSelector.Items.Add("All Canvases");
            cboWSNameSelector.Items.Add(string.Empty);

            foreach (Workspace ws in _viewModel.allWorkspaces)
                cboWSNameSelector.Items.Add(ws.name);

            cboWSNameSelector.SelectedItem = selectedItem;
        }

        private void RebindStrokes()
        {
            // Bind inkcanvas stroke to activecanvas
            Binding newBinding = new Binding();
            newBinding = new Binding("Strokes");
            newBinding.Source = _viewModel.activeCanvas.canvas;
            Console.WriteLine("Binding strokes for " + _viewModel.activeCanvas.ID.ToString());
            icCanvas.SetBinding(InkCanvas.StrokesProperty, newBinding);
        }

        // Initializes the highlighter management thread
        private void InitializeHighlightManager()
        {
            _highlightManagerThread = new Thread(() => fadeHighlighterLoop());
            _highlightManagerThread.Start();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            toolbox.Close();
            //knowledgeContent.Close();
            strokeMenu.Close();
            _highlighterStrokes.CompleteAdding();
        }

        private void DoneEditing()
        {
            toolbox.Hide();
            //knowledgeContent.Hide();
            strokeMenu.Hide();
            _highlighterStrokes.CompleteAdding();
            _viewModel.CloseEditor();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //toolbox.HideIfNotPinned();
            Console.WriteLine("Activated Window!");
            strokeMenu.Hide();
            RebindStrokes();
        }

        private void inkCanvas_SelectionChanged(object sender, EventArgs e)
        {
            showCopyMenu();
        }

        private void inkCanvas_SelectionMoved(object sender, EventArgs e)
        {
            showCopyMenu();
            _viewModel.activeCanvas.RefreshThumbnail();
        }

        private void showCopyMenu()
        {
            if (!_copying)
            {
                StrokeCollection strokes = icCanvas.GetSelectedStrokes();
                if (strokes.Count > 0)
                {
                    Point offset = new Point();
                    Rect selectionBounds = icCanvas.GetSelectionBounds();
                    Point canvasLocation = icCanvas.PointToScreen(new Point(0,0));
                    offset.X = selectionBounds.Left + selectionBounds.Width + canvasLocation.X + 10;
                    offset.Y = selectionBounds.Top + canvasLocation.Y;
                    Console.WriteLine("Offset: ({0},{1})", offset.X, offset.Y);
                    strokeMenu.Top = offset.Y;
                    strokeMenu.Left = offset.X;
                    strokeMenu.Show();
                }
                else
                {
                    strokeMenu.Hide();
                }
            }
        }
        
        public void copySelectedStroke()
        {
            _copying = true;
            int strokesBeforeCopy = icCanvas.Strokes.Count;
            Rect selectionBounds = icCanvas.GetSelectionBounds();
            //Console.WriteLine("Offset: ({0},{1})", selectionBounds.Left, selectionBounds.Top);

            Point offset = new Point();
            offset.Y = selectionBounds.Top + 10;
            offset.X = selectionBounds.Left + 10;
            icCanvas.CopySelection();
            //inkCanvas.Paste(offset);
            icCanvas.Paste(offset);
            icCanvas.Select(null, null);
            _copying = false;
            StrokeCollection addedStrokes = new StrokeCollection();
            for (int i = strokesBeforeCopy; i < icCanvas.Strokes.Count; i++)
                addedStrokes.Add(icCanvas.Strokes[i]);
            icCanvas.Select(addedStrokes);
        }

        private void inkCanvas_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs e)
        {
            if (icCanvas.DefaultDrawingAttributes.IsHighlighter)
            {
                _highlighterStrokes.Add(e.Stroke);
            }
            else
            {
                _undoStack.Push(new KeyValuePair<Stroke, int>(e.Stroke, 1));
                _viewModel.activeCanvas.RefreshThumbnail();
            }
        }

        private void inkCanvas_StrokeErasing(object sender, InkCanvasStrokeErasingEventArgs e)
        {
            if (undoTracking)
                _undoStack.Push(new KeyValuePair<Stroke, int>(e.Stroke,0));

            _viewModel.activeCanvas.RefreshThumbnail();
        }

        public void undo()
        {
            if (_undoStack.Count > 0)
            {
                KeyValuePair<Stroke, int> strokeEvent = _undoStack.Pop();
                _redoStack.Push(strokeEvent);

                // Stroke added
                if (strokeEvent.Value == 1)
                {
                    icCanvas.Strokes.Remove(strokeEvent.Key);
                }
                else //Stroke removed
                {
                    icCanvas.Strokes.Add(strokeEvent.Key);
                }
                _viewModel.activeCanvas.RefreshThumbnail();
            }
        }

        public void redo()
        {
            if (_redoStack.Count > 0)
            {
                KeyValuePair<Stroke, int> strokeEvent = _redoStack.Pop();
                _undoStack.Push(strokeEvent);

                // Stroke added
                if (strokeEvent.Value == 1)
                {
                    icCanvas.Strokes.Add(strokeEvent.Key);
                }
                else //Stroke removed
                {
                    icCanvas.Strokes.Remove(strokeEvent.Key);
                }
                _viewModel.activeCanvas.RefreshThumbnail();
            }
        }

        private void cmdDetails_Click(object sender, RoutedEventArgs e)
        {
            //Open detail editor
            DetailsDialog d = new DetailsDialog(_viewModel.activeCanvas, _viewModel.canvasModel);
            d.Owner = Window.GetWindow(this);
            d.ShowDialog();
        }

        private void cmdNew_Click(object sender, RoutedEventArgs e)
        {
            NewCanvas();
        }

        private void cmdClone_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CloneCanvas();
            RebindStrokes();
            _viewModel.activeCanvas.RefreshThumbnail();
            this.ApplyAllFilters();
            SelectActiveCanvas();
        }

        private void cmdQuit_Click(object sender, RoutedEventArgs e)
        {
            this.DoneEditing();
        }

        private void NewCanvas()
        {
            _viewModel.NewCanvas();
            //activeCanvas = canvasModel.NewCanvas();
            RebindStrokes();
            //icCanvasList.Items.Add(activeCanvas.name);
            this.ApplyAllFilters();
            SelectActiveCanvas();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Stroke s in _highlighterStrokes.GetConsumingEnumerable())
            {
                //inkDispatcher.BeginInvoke(new Action<Stroke>(FadeStrokes), s);
            }
        }

        private void fadeHighlighterLoop()
        {
            foreach (Stroke s in _highlighterStrokes.GetConsumingEnumerable())
            {
                System.Threading.Thread.Sleep(50);
                for (int i = 1; i <= 15; i++)
                {
                    inkDispatcher.Invoke(new Action<Stroke>(FadeStrokes), s);
                    System.Threading.Thread.Sleep(50);
                }

                undoTracking = false;
                inkDispatcher.Invoke(new Action<Stroke>(RemoveStroke), s);
                undoTracking = true;
            }
        }

        private void FadeStrokes(Stroke s)
        {
            byte newR = Convert.ToByte(Math.Min(s.DrawingAttributes.Color.R + 15, 255));
            byte newG = Convert.ToByte(Math.Min(s.DrawingAttributes.Color.G + 15, 255));
            byte newB = Convert.ToByte(Math.Min(s.DrawingAttributes.Color.B + 15, 255));

            s.DrawingAttributes.Color = Color.FromRgb(newR, newG, newB);
            
            //s.DrawingAttributes.Color = Colors.Aquamarine;
        }

        private void RemoveStroke(Stroke s)
        {
            icCanvas.Strokes.Remove(s);
        }

        private void CanvasName_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            //TextBlock t = sp.Children[0] as TextBlock;
            _viewModel.OpenCanvas((int)sp.Tag);
            RebindStrokes();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            // Instead of closing the window, cancel the close event
            // and call DoneEditing which will hide it.
            if (this.Visibility == System.Windows.Visibility.Visible)
            {
                e.Cancel = true;
                this.DoneEditing();
            }
        }

        private void cboWSSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                string wsName = e.AddedItems[0].ToString();
                if (wsName == "All Canvases")
                    _viewModel.ShowAllCanvases();
                else
                    _viewModel.RefreshCanvasList(wsName);
            }
        }


        private void cmdToolbox_Checked(object sender, RoutedEventArgs e)
        {          
            toolbox.Owner = this;
            toolbox.Show();
        }

        private void cmdToolbox_Unchecked(object sender, RoutedEventArgs e)
        {
            toolbox.Hide();
        }

        private void lvNavItem_Click(object sender, MouseEventArgs e)
        {
            // HACK: To prevent inexplicable passthrough of mouse click when the editor opens
            if (_captureMouseEvents)
            {
                Console.WriteLine("Clicked!");
                //System.Windows.MessageBox.Show("You clicked on a canvas!");
                ListViewItem l = sender as ListViewItem;
                CCanvas c = l.Content as CCanvas;
                _viewModel.OpenCanvas(c.ID);
                RebindStrokes();
            }
            else
            {
                // To ensure only the first, "bad" click is ignored
                _captureMouseEvents = true;
            }
        }

        #region Navigator Event Handlers
        public void ApplyAllFilters()
        {
            _viewModel.ApplyAllFilters();
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            TextBox t = e.Source as TextBox;
            _viewModel.searchTerm = t.Text;
            this.ApplyAllFilters();
        }

        private void user_CheckChanged(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.IsChecked == true)
                _viewModel.selectedUsers.Add(cb.Content as string);
            else
                _viewModel.selectedUsers.Remove(cb.Content as string);

            this.ApplyAllFilters();
        }

        private void tag_CheckChanged(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.IsChecked == true)
                _viewModel.selectedTags.Add(cb.Content as string);
            else
                _viewModel.selectedTags.Remove(cb.Content as string);
            this.ApplyAllFilters();
        }

        private void sortAscending_Checked(object sender, RoutedEventArgs e)
        {
            //Uncheck sortDescending
            sortDescending.IsChecked = false;
            _viewModel.ChangeSortDirection(true);
        }

        private void sortDescending_Checked(object sender, RoutedEventArgs e)
        {
            //Uncheck sortAscending
            sortAscending.IsChecked = false;
            _viewModel.ChangeSortDirection(false);
        }

        private void sortBy_Checked(object sender, RoutedEventArgs e)
        {
            MenuItem checkedItem = sender as MenuItem;

            // Uncheck other items
            foreach (MenuItem m in sortByMenu.Items)
            {
                if (m != checkedItem)
                    m.IsChecked = false;
            }

            _viewModel.SortCanvases(checkedItem.Tag.ToString(), sortAscending.IsChecked);
        }

        private void sortBy_Unchecked(object sender, RoutedEventArgs e)
        {
            _viewModel.ClearSort();
        }

        private void FilterMenu_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            // force rebinding of tags/users
            FilterMenu.DataContext = null;
            FilterMenu.DataContext = _viewModel;
        }

        private void FavFilter_CheckChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.filterFavorites = FavFilter.IsChecked;
            this.ApplyAllFilters();
        }
        #endregion // Navigator Event Handlers

        private void cboWSNameSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ApplyAllFilters();
            _viewModel.ChangeWorkspace();
            SelectActiveCanvas();
        }

        private void removeCanvas_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem l = this.FindVisualParent<ListViewItem>(sender as DependencyObject);
            CCanvas c = l.Content as CCanvas;
            _viewModel.RemoveFromWorkspace(c);
            this.ApplyAllFilters();
        }

        public T FindVisualParent<T>(DependencyObject obj)
        where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);
            while (parent != null)
            {
                T typed = parent as T;
                if (typed != null)
                {
                    return typed;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }

        private void cmdInfo_Checked(object sender, RoutedEventArgs e)
        {
            
            knowledgeContent = new KnowledgeContent(this);
            knowledgeContent.Owner = this;
            knowledgeContent.Show();    
        }

        private void cmdInfo_Unchecked(object sender, RoutedEventArgs e)
        {
            knowledgeContent.Hide();
            knowledgeContent.Close();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                int index = item.Content.ToString().IndexOf(':');
                string id = item.Content.ToString().Substring(0, index);
                int idKnowledge = -1;
                Int32.TryParse(id, out idKnowledge);
                if (idKnowledge > -1)
                {
                    relKnowledgeContent = new RelKnowledgeContent(this, idKnowledge);
                    relKnowledgeContent.Owner = this;
                    relKnowledgeContent.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("There is a problem, cannot display this item.");
                }
            }
        }

        private void cmdRefreshKnowledge_Click(object sender, RoutedEventArgs e)
        {
            UpdateListViewData();
        }
    }
}
