using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Windows.Data;
using System.Windows.Input;
using CalicoMock.Model;

namespace CalicoMock.ViewModel
{
    public class WorkspaceViewModel : CalicoViewModel
    {
        // these are inherited
        //public double navPanelWidth { get; set; }
        //public double detailPanelHeight { get; set; }
        //public List<string> selectedTags { get; set; }
        //public List<string> selectedUsers { get; set; }
        //public string searchTerm { get; set; }
        //public double navItemHeight { get; set; }
        //public bool filterFavorites { get; set; }
        //private Workspace _activeWS;

        private ObservableCollection<CCanvas> _selectedCanvases; //list of canvases that are selected
        //private Dictionary<int, bool> _filterMap; //maps canvasID -> matchesFilter
        //private CanvasModel _canvasModel;
        //private WorkspaceModel _workspaceModel;

        public event EventHandler<CCanvas> RaiseEditCanvasEvent;

        private delegate bool filterDelegate(CCanvas c);

        public WorkspaceViewModel(CanvasModel cm, WorkspaceModel wm) : base(cm,wm)
        {
            _canvasModel = cm;  //protected field in base class
            _workspaceModel = wm;   //protected field in base class
            activeWS = allWorkspaces[0];
            navPanelWidth = 175;
            detailPanelHeight = 150;
            allCanvasesView = CollectionViewSource.GetDefaultView(allCanvases);
            selectedTags = new List<string>();
            selectedUsers = new List<string>();
            searchTerm = "";
            navItemHeight = 50;
        }

        public ObservableCollection<CCanvas> selectedCanvases
        {
            get { return _selectedCanvases; }
            set
            {
                _selectedCanvases = value;
                OnPropertyChanged("selectedCanvases");
            }
        }

        #region Inherited Properties

        //public Workspace activeWS
        //{
        //    get { return _activeWS; }
        //    set
        //    {
        //        _activeWS = value;
        //        OnPropertyChanged("activeWS");
        //    }
        //}

        //public List<string> allTags
        //{
        //    get
        //    {
        //        return allCanvases.SelectMany(x => x.tags)
        //                          .Distinct()
        //                          .ToList();
        //    }
        //}

        //public List<string> allUsers
        //{
        //    get
        //    {
        //        return allCanvases.Select(x => x.user)
        //                          .Distinct()
        //                          .ToList();
        //    }
        //}

        //public ObservableCollection<CCanvas> allCanvases
        //{
        //    get { return _canvasModel.allCanvases; }
        //    set
        //    {
        //        _canvasModel.allCanvases = value;
        //        OnPropertyChanged("allCanvases");
        //    }
        //}

        //public ObservableCollection<Workspace> allWorkspaces
        //{
        //    get { return _workspaceModel.allWorkspaces; }
        //    set
        //    {
        //        _workspaceModel.allWorkspaces = value;
        //        OnPropertyChanged("allWorkspaces");
        //    }
        //}

        //public Dictionary<int, bool> filterMap
        //{
        //    get { return _filterMap; }
        //    set
        //    {
        //        _filterMap = value;
        //        OnPropertyChanged("filterMap");
        //    }
        //}

        //public ICollectionView allCanvasesView { get; set; }
        #endregion //Inherited Properties

        #region Inherited Methods
        //public void SortCanvases(string sortProperty, bool ascending)
        //{
        //    allCanvasesView.SortDescriptions.Clear();

        //    ListSortDirection direction;
        //    if (ascending)
        //        direction = ListSortDirection.Ascending;
        //    else
        //        direction = ListSortDirection.Descending;

        //    allCanvasesView.SortDescriptions.Add(new SortDescription(sortProperty,direction));
        //}

        //public void ChangeSortDirection(bool ascending)
        //{
        //    if (allCanvasesView.SortDescriptions.Count > 0)
        //    {
        //        var sort = allCanvasesView.SortDescriptions[0];
        //        var newSort = new SortDescription();
        //        newSort.PropertyName = sort.PropertyName;
        //        if (ascending)
        //            newSort.Direction = ListSortDirection.Ascending;
        //        else
        //            newSort.Direction = ListSortDirection.Descending;

        //        allCanvasesView.SortDescriptions.Clear();
        //        allCanvasesView.SortDescriptions.Add(newSort);
        //    }
        //}

        //public void ClearSort()
        //{
        //    allCanvasesView.SortDescriptions.Clear();
        //}
        
        //public void ExecuteSearch(string filter)
        //{
        //    ListCollectionView list = (ListCollectionView)allCanvasesView;
        //    if (filter != "")
        //        list.Filter = new Predicate<object>(x => ((CCanvas)x).MatchesKeyword(filter));
        //    else
        //        list.Filter = null;
        //}

        //public void DeleteCanvas(CCanvas c)
        //{
        //    allCanvases.Remove(c);
        //    _workspaceModel.RemoveCanvas(c);
        //}

        //public void AddCanvas()
        //{
        //    allCanvases.Add(new CCanvas(allCanvases.Count + 1));
        //}
        #endregion //Inherited Methods

        public override void ApplyAllFilters()
        {
            // First call the base function
            base.ApplyAllFilters();
            ListCollectionView list = (ListCollectionView)allCanvasesView;

            //Util.MultiFilter mf = new Util.MultiFilter();

            ////Favorites filter
            //if (filterFavorites)
            //    mf.AddFilter(new Predicate<object>(c => ((CCanvas)c).IsFavorite));

            ////Tag filters
            //if (selectedTags.Count > 0)
            //    mf.AddFilter(new Predicate<object>(c => ((CCanvas)c).tags.Any(tag => selectedTags.Contains(tag))));

            ////User filters
            //if (selectedUsers.Count > 0)
            //    mf.AddFilter(new Predicate<object>(c => selectedUsers.Contains(((CCanvas)c).user)));
            ////Search filter
            //if (searchTerm != "")
            //{
            //    mf.AddFilter(new Predicate<object>(x => ((CCanvas)x).MatchesKeyword(searchTerm)));
            //}

            //list.Filter = mf.Filter;

            // Clear matches - only applies to Workspace View
            foreach (SketchThumbnail s in activeWS.Sketches)
            {
                s.MatchesFilter = false;
            }

            // Apply new matches
            foreach (CCanvas c in list)
            {
                // There should only ever be 1 match, but this will also handle the case where there are none
                foreach (SketchThumbnail s in activeWS.Sketches.Where(x => x.canvasID == c.ID).ToList())
                    s.MatchesFilter = true;
            }

        }

        // Resets isInActiveWS flag when the workspace changes
        public void CheckActiveWorkspace()
        {
            List<int> activeIDList = activeWS.Sketches.Select(s => s.canvasID).ToList();

            foreach (CCanvas c in allCanvases)
            {
                if (activeIDList.Contains(c.ID))
                    c.isInActiveWS = true;
                else
                    c.isInActiveWS = false;
            }
        }

        public void ClearSelection()
        {
            selectedCanvases.Clear();
        }

        public void MoveSelectedToWorkspace()
        {
            foreach (CCanvas c in selectedCanvases)
            {
                activeWS.AddCanvas(c);
            }
        }

        public void RemoveSelectedFromWorkspace()
        {
            foreach (CCanvas c in selectedCanvases)
            {
                activeWS.RemoveCanvas(c);
            }
        }

        public void RefreshDetailFromWorkspace()
        {
            ObservableCollection<CCanvas> newSelection = new ObservableCollection<CCanvas>();
            foreach (SketchThumbnail s in _activeWS.Sketches)
            {
                if (s.IsSelected)
                {
                    CCanvas ancestor = _canvasModel[s.canvasID];
                    newSelection.Add(ancestor);
                } 
            }

            selectedCanvases = newSelection;
        }

        public void RefreshDetailFromNavigator(List<CCanvas> canvases)
        {
            ObservableCollection<CCanvas> newSelection = new ObservableCollection<CCanvas>();
            foreach (CCanvas c in canvases)
            {
                newSelection.Add(c);
            }

            selectedCanvases = newSelection;
        }

        public void EditCanvas(CCanvas c)
        {
            // Clear filters so the editor shows all canvases
            ListCollectionView list = (ListCollectionView)allCanvasesView;
            list.Filter = null;
            OnEditCanvas(c);
        }

        // Wrap event invocations inside a protected virtual method 
        // to allow derived classes to override the event invocation behavior 
        protected virtual void OnEditCanvas(CCanvas e)
        {
            // Make a temporary copy of the event to avoid possibility of 
            // a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            EventHandler<CCanvas> handler = RaiseEditCanvasEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, e);
            }
        }

        public void NewWorkspace(string Name)
        {
            _activeWS = _workspaceModel.NewWorkspace(Name);
        }

        public void CopyWorkspace()
        {
            Workspace ws = _activeWS;
            string Name = string.Format("{0} - Copy", ws.name);
            activeWS = _workspaceModel.CloneWorkspace(ws, Name);
        }

        public void RemoveWorkspace(Workspace ws)
        {
            _workspaceModel.Remove(ws);
        }

        public void RemoveActiveWorkspace()
        {
            // if there is only 1 workspace, replace it with a blank one
            if (allWorkspaces.Count == 1)
            {
                Workspace ws = new Workspace("Workspace1");
                allWorkspaces.Add(ws);
                activeWS = allWorkspaces[1];
                allWorkspaces.RemoveAt(0);
            }
            else
            {
                int wsID = allWorkspaces.IndexOf(activeWS);
                int newWSID = wsID;

                // Point to the next WS or if none exists, the previous
                if (wsID == allWorkspaces.Count - 1)
                    newWSID--;
                else
                    newWSID++;

                activeWS = allWorkspaces[newWSID];
                allWorkspaces.RemoveAt(wsID);

            }

        }

        public void RefreshWorkspaces()
        {
            _workspaceModel.RefreshWorkspaces(_canvasModel.allCanvases);
        }

        public void RefreshSketchNames()
        {
            _workspaceModel.RefreshSketchNames(_canvasModel.allCanvases);
        }

    }
}
