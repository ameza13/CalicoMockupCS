using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CalicoMock.Model;
using CalicoMock.ViewModel;

namespace CalicoMock.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class WorkspaceView : Window
    {
        private WorkspaceViewModel _viewModel;
        private NavPanelTemplate _navPanelTemplate;

        public bool navHasFocus { get; set; }

        public WorkspaceView(WorkspaceViewModel vm)
        {
            _viewModel = vm;
            _navPanelTemplate = new NavPanelTemplate();
            InitializeComponent();
            DataContext = vm;

            //Binding newBinding = new Binding("allCanvases");
            Binding newBinding = new Binding("allCanvasesView");
            newBinding.Source = _viewModel;
            lvNavigator.SetBinding(ListView.ItemsSourceProperty, newBinding);

            navExpander.DataContext = _navPanelTemplate;
            newBinding = new Binding("ExpDirection");
            newBinding.Source = _navPanelTemplate;
            navExpander.SetBinding(Expander.ExpandDirectionProperty, newBinding);

            newBinding = new Binding("Sketches");
            newBinding.Source = _viewModel.activeWS;
            lbWorkspace.SetBinding(ListBox.ItemsSourceProperty, newBinding);

            newBinding = new Binding("allWorkspaces");
            newBinding.Source = _viewModel;
            cboWSSelector.SetBinding(ComboBox.ItemsSourceProperty, newBinding);

            newBinding = new Binding("activeWS");
            newBinding.Source = _viewModel;
            cboWSSelector.SetBinding(ComboBox.SelectedItemProperty, newBinding);

            newBinding = new Binding("Scale");
            newBinding.Source = _viewModel.activeWS;
            WSScaleSlider.SetBinding(Slider.ValueProperty, newBinding);

            FilterMenu.DataContext = _viewModel;
            sortAscending.IsChecked = true;
        }

        private void detailExpander_Collapsed(object sender, RoutedEventArgs e)
        {
            _viewModel.detailPanelHeight = innerGrid.RowDefinitions[2].Height.Value;
            innerGrid.RowDefinitions[2].Height = GridLength.Auto;
        }

        private void navExpander_Collapsed(object sender, RoutedEventArgs e)
        {
            _viewModel.navPanelWidth = outerGrid.ColumnDefinitions[0].Width.Value;
            outerGrid.ColumnDefinitions[0].Width = GridLength.Auto;
            _navPanelTemplate.SetCollapsed();
            //navExpander.ExpandDirection = ExpandDirection.Right;
        }

        private void detailExpander_Expanded(object sender, RoutedEventArgs e)
        {
            innerGrid.RowDefinitions[2].Height = new GridLength(_viewModel.detailPanelHeight);
        }

        private void navExpander_Expanded(object sender, RoutedEventArgs e)
        {
            outerGrid.ColumnDefinitions[0].Width = new GridLength(_viewModel.navPanelWidth);
            _navPanelTemplate.SetExpanded();
            //navExpander.ExpandDirection = ExpandDirection.Down;
        }

        private void lbWorkspace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.RefreshDetailFromWorkspace();

            navHasFocus = false;
        }

        private void lvNavItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            e.Handled = true;
            ListViewItem l = sender as ListViewItem;
            CCanvas c = l.Content as CCanvas;
            Console.WriteLine(c.ID.ToString());
            _viewModel.EditCanvas(c);
        }

        private void lvNavigator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<CCanvas> selectedCanvases = new List<CCanvas>();
            foreach (CCanvas c in lvNavigator.SelectedItems)
            {
                selectedCanvases.Add(c);
            }

            _viewModel.RefreshDetailFromNavigator(selectedCanvases);

            navHasFocus = true;
        }

        private void cmdQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cboMoveRight_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.MoveSelectedToWorkspace();
            lbWorkspace.Items.Refresh();
            lvNavigator.SelectedItems.Clear();
        }

        private void cboMoveLeft_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveSelectedFromWorkspace();
        }

        private void upperGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _viewModel.RefreshDetailFromWorkspace();
            lvNavigator.SelectedItems.Clear();
        }

        private void navExpander_GotFocus(object sender, RoutedEventArgs e)
        {
            List<CCanvas> selectedCanvases = new List<CCanvas>();
            foreach (CCanvas c in lvNavigator.SelectedItems)
            {
                selectedCanvases.Add(c);
            }

            _viewModel.RefreshDetailFromNavigator(selectedCanvases);
            lbWorkspace.SelectedItems.Clear();
        }

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Thumb t = e.Source as Thumb;
            SketchThumbnail s = t.DataContext as SketchThumbnail;
            s.x = s.x + e.HorizontalChange;
            s.y = s.y + e.VerticalChange;
        }

        public void RebindLv()
        {
            Binding newBinding = new Binding("allCanvases");
            newBinding.Source = _viewModel;
            lvNavigator.SetBinding(ListView.ItemsSourceProperty, newBinding);
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            TextBox t = e.Source as TextBox;
            _viewModel.searchTerm = t.Text;
            this.ApplyAllFilters();
        }

        private void Thumb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem l = this.FindVisualParent<ListBoxItem>(sender as DependencyObject);

            if (Keyboard.Modifiers != ModifierKeys.Control)
                lbWorkspace.SelectedItems.Clear();

            l.IsSelected = true;

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

        private void cmdNewCanvas_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddCanvas();
        }

        private void deleteCanvas_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this canvas?", "Confirm Action", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ListViewItem l = this.FindVisualParent<ListViewItem>(sender as DependencyObject);
                CCanvas c = l.Content as CCanvas;
                _viewModel.DeleteCanvas(c);
            }
        }

        private void cmdNewWS_Click(object sender, RoutedEventArgs e)
        {
            //Open detail editor
            _viewModel.activeWS = new Workspace(string.Format("Workspace{0}",_viewModel.allWorkspaces.Count));
            EditWorkspaceDialog d = new EditWorkspaceDialog(true, _viewModel.activeWS);
            d.Owner = Window.GetWindow(this);
            d.ShowDialog();
            _viewModel.allWorkspaces.Add(_viewModel.activeWS);
            // HACK: refresh sketch binding
            // For some reason the binding to the nested property is not refreshing
            // when the parent changes
            RebindSketches();
        }

        private void cmdDeleteWS_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the active workspace?", "Confirm Action", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _viewModel.RemoveActiveWorkspace();
                // HACK: refresh sketch binding
                // For some reason the binding to the nested property is not refreshing
                // when the parent changes
                RebindSketches();
            }
        }

        private void RebindSketches()
        {
            if (_viewModel.allWorkspaces.Count > 0)
            {
                svWorkspace.Visibility = System.Windows.Visibility.Visible;
                Binding newBinding = new Binding("Sketches");
                newBinding.Source = _viewModel.activeWS;
                lbWorkspace.SetBinding(ListBox.ItemsSourceProperty, newBinding);
            }
            else
            {
                svWorkspace.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void cmdEditWS_Click(object sender, RoutedEventArgs e)
        {
            //Open detail editor
            EditWorkspaceDialog d = new EditWorkspaceDialog(false, _viewModel.activeWS);
            d.Owner = Window.GetWindow(this);
            d.ShowDialog();
        }

        private void DetailItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CCanvas c = ((ListViewItem)sender).Content as CCanvas;
            //Open detail editor
            DetailsDialog d = new DetailsDialog(c,_viewModel.canvasModel);
            d.Owner = Window.GetWindow(this);
            d.ShowDialog();
            lvDetails.Items.Refresh();
            //HACK: Forces sketch names to update in the workspace
            _viewModel.RefreshSketchNames();
        }

        public void ApplyAllFilters()
        {
            _viewModel.ApplyAllFilters();
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

        private void cboWSSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // HACK: refresh sketch binding
            // For some reason the binding to the nested property is not refreshing
            // when the parent changes
            RebindWorkspace();

            RebindStrokes();

            _viewModel.CheckActiveWorkspace();
        }

        public void RebindWorkspace()
        {
            Binding newBinding = new Binding("Sketches");
            newBinding.Source = _viewModel.activeWS;
            lbWorkspace.SetBinding(ListBox.ItemsSourceProperty, newBinding);

            newBinding = new Binding("Scale");
            newBinding.Source = _viewModel.activeWS;
            WSScaleSlider.SetBinding(Slider.ValueProperty, newBinding);
        }

        private void Thumb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("You double-clicked a thumbnail!");
            ListBoxItem l = this.FindVisualParent<ListBoxItem>(sender as DependencyObject);
            SketchThumbnail s = l.Content as SketchThumbnail;
            CCanvas c = _viewModel.allCanvases.Where(x => x.ID == s.canvasID).ToList()[0];
            _viewModel.EditCanvas(c);
        }

        public void RefreshWorkspaces()
        {
            _viewModel.RefreshWorkspaces();
        }

        private void FilterMenu_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            // force rebinding of tags/users
            FilterMenu.DataContext = null;
            FilterMenu.DataContext = _viewModel;

            // recheck boxes
            //for (int i = 0; i <= lbTagFilter.Items.Count; i++)
            //{
            //    var item = lbTagFilter.Items[i];
            //    //var dpSource = lbTagFilter.ItemContainerGenerator.ContainerFromItem(lbTagFilter.Items[i]);
            //    //ListBoxItem l = FindVisualParent<ListBoxItem>(dpSource);
            //    ListBoxItem lbi = (ListBoxItem)(lbTagFilter.ItemContainerGenerator.ContainerFromItem(lbTagFilter.Items[i]));
            //    CheckBox cb = (CheckBox)lbTagFilter.ItemContainerGenerator.ContainerFromItem(lbTagFilter.Items[i]);
            //    //CheckBox cb = (CheckBox)item.Content;
            //    if (_viewModel.selectedTags.Contains(cb.Content))
            //        cb.IsChecked = true;
            //}

            //foreach (CheckBox cb in lbUserFilter.Items)
            //{
            //    if (_viewModel.selectedUsers.Contains(cb.Content))
            //        cb.IsChecked = true;
            //}

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void tglDraw_Checked(object sender, RoutedEventArgs e)
        {
            icNotes.IsHitTestVisible = true;
            tglErase.Visibility = System.Windows.Visibility.Visible;
            tglPencil.Visibility = System.Windows.Visibility.Visible;
        }

        private void tglDraw_Unchecked(object sender, RoutedEventArgs e)
        {
            icNotes.IsHitTestVisible = false;
            tglErase.Visibility = System.Windows.Visibility.Collapsed;
            tglPencil.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void EnableEraseMode(object sender, RoutedEventArgs e)
        {
            icNotes.UseCustomCursor = false;
            tglPencil.IsChecked = false;
            tglErase.IsChecked = true;
            icNotes.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }

        private void EnableDrawMode(object sender, RoutedEventArgs e)
        {
            icNotes.UseCustomCursor = true;
            icNotes.Cursor = Cursors.Pen;
            tglPencil.IsChecked = true;
            tglErase.IsChecked = false;
            icNotes.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void RebindStrokes()
        {
            // Bind inkcanvas stroke to activecanvas
            if (_viewModel.activeWS != null)
            {
                Binding newBinding = new Binding();
                newBinding = new Binding("Strokes");
                newBinding.Source = _viewModel.activeWS.NoteCanvas;
                icNotes.SetBinding(InkCanvas.StrokesProperty, newBinding);
            }
        }

        private void removeCanvasFromWS_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem l = this.FindVisualParent<ListBoxItem>(sender as DependencyObject);
            SketchThumbnail s = l.Content as SketchThumbnail;
            _viewModel.RemoveFromWorkspace(s);
        }

        private void lbWorkspace_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dpSource = e.OriginalSource as DependencyObject;

            ListBoxItem l = FindVisualParent<ListBoxItem>(dpSource);

            if (l == null)
                lbWorkspace.SelectedItems.Clear();
        }

        private void lvNavigator_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dpSource = e.OriginalSource as DependencyObject;

            ListViewItem l = FindVisualParent<ListViewItem>(dpSource);

            if (l == null)
                lvNavigator.SelectedItems.Clear();
        }

        private void FavFilter_CheckChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.filterFavorites = FavFilter.IsChecked;
            this.ApplyAllFilters();
        }

        private void cmdCloneWS_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CopyWorkspace();
            // HACK: refresh sketch binding
            // For some reason the binding to the nested property is not refreshing
            // when the parent changes
            RebindSketches();
        }

    }
}
