using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CalicoMock.Model;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace CalicoMock.ViewModel
{
    public class EditorViewModel : CalicoViewModel
    {
        private CCanvas _activeCanvas;
        private string _selectedWSName;
        //private CanvasModel _canvasModel;
        //private WorkspaceModel _workspaceModel;
        private ObservableCollection<CCanvas> _canvasList;

        public EditorViewModel(CanvasModel cm, WorkspaceModel wm) : base(cm, wm)
        {
            _canvasModel = cm;
            _workspaceModel = wm;
            _activeCanvas = new CCanvas();
        }

        public event EventHandler<EventArgs> RaiseDoneEditingEvent;

        public string SelectedWSName
        {
            get { return _selectedWSName; }
            set
            {
                _selectedWSName = value;
                OnPropertyChanged("SelectedWSName");
            }
        }

        public CCanvas activeCanvas
        {
            get { return _activeCanvas; }
            set
            {
                _activeCanvas = value;
                OnPropertyChanged("activeCanvas");
            }
        }

        #region Inherited Properties
        //public ObservableCollection<Workspace> allWorkspaces
        //{
        //    get { return _workspaceModel.allWorkspaces; }
        //    set
        //    {
        //        _workspaceModel.allWorkspaces = value;
        //        OnPropertyChanged("allWorkspaces");
        //    }
        //}

        #endregion

        public ObservableCollection<CCanvas> CanvasList
        {
            get { return _canvasList; }
            set
            {
                _canvasList = value;
                OnPropertyChanged("CanvasList");
            }
        }

        public void NewCanvas()
        {
            SwitchCanvas();
            activeCanvas = _canvasModel.NewCanvas();
            if (SelectedWSName != "All Canvases")
                activeWS.AddCanvas(activeCanvas);
        }

        public void CloneCanvas()
        {
            SwitchCanvas();
            activeCanvas = _canvasModel.CloneCanvas(activeCanvas);
            if (SelectedWSName != "All Canvases")
                activeWS.AddCanvas(activeCanvas);
        }

        public void OpenCanvas(int ID)
        {
            activeCanvas = _canvasModel.allCanvases.Where(x => x.ID == ID).ToList()[0];
        }

        public void SwitchCanvas()
        {
            if (activeCanvas != null)
            {
                activeCanvas.thumbnail = activeCanvas.getThumbnail();
                activeCanvas.modified = DateTime.Now;
            }
        }

        public void CloseEditor()
        {
            activeCanvas.thumbnail = activeCanvas.getThumbnail();
            activeCanvas.modified = DateTime.Now;
            OnClosed();
        }

        // Wrap event invocations inside a protected virtual method 
        // to allow derived classes to override the event invocation behavior 
        protected virtual void OnClosed()
        {
            // Make a temporary copy of the event to avoid possibility of 
            // a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            EventHandler<EventArgs> handler = RaiseDoneEditingEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, new EventArgs());
            }
        }

        public void RefreshCanvasList(string wsName)
        {            
            ObservableCollection<CCanvas> newList = new ObservableCollection<CCanvas>();
            Workspace ws = allWorkspaces.Where(x => x.name == wsName).ToList()[0];
            foreach (SketchThumbnail s in ws.Sketches)
            {
                CCanvas ancestor = _canvasModel.allCanvases.Where(c => c.ID == s.canvasID).ToList()[0];
                newList.Add(ancestor);
            }

            CanvasList = newList;
        }

        public void ShowAllCanvases()
        {
            CanvasList = _canvasModel.allCanvases;
        }

        public void ChangeWorkspace()
        {
            Workspace ws = null;
            if (SelectedWSName != "All Canvases" && SelectedWSName != null)
                ws = allWorkspaces.Where(w => w.name == SelectedWSName).ToList()[0];
            activeWS = ws;
        }

        // Most of this is the same as the inherited method
        public override void ApplyAllFilters()
        {
            ListCollectionView list = (ListCollectionView)allCanvasesView;

            Util.MultiFilter mf = new Util.MultiFilter();

            //Favorites filter
            if (filterFavorites)
                mf.AddFilter(new Predicate<object>(c => ((CCanvas)c).IsFavorite));

            //Tag filters
            if (selectedTags.Count > 0)
                mf.AddFilter(new Predicate<object>(c => ((CCanvas)c).tags.Any(tag => selectedTags.Contains(tag))));

            //User filters
            if (selectedUsers.Count > 0)
                mf.AddFilter(new Predicate<object>(c => selectedUsers.Contains(((CCanvas)c).user)));

            //Search filter
            if (searchTerm != "")
            {
                mf.AddFilter(new Predicate<object>(c => ((CCanvas)c).MatchesKeyword(searchTerm)));
            }

            // This block is the only difference from the inherited method
            if (SelectedWSName != "All Canvases")
            {
                if (SelectedWSName != null)
                {
                    Workspace ws = _workspaceModel.allWorkspaces.Where(x => x.name == SelectedWSName).ToList()[0];
                    if (ws != null)
                        mf.AddFilter(new Predicate<object>(c => ws.Sketches.Count(s => s.canvasID == ((CCanvas)c).ID) > 0));
                }
            }

            list.Filter = mf.Filter;

        }

    }
}
