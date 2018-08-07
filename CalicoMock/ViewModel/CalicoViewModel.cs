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
    public class CalicoViewModel : ViewModelBase
    {
        public double navPanelWidth { get; set; }
        public double detailPanelHeight { get; set; }
        public List<string> selectedTags { get; set; }
        public List<string> selectedUsers { get; set; }
        public string searchTerm { get; set; }
        public double navItemHeight { get; set; }
        public bool filterFavorites { get; set; }

        protected Workspace _activeWS;
        protected Dictionary<int, bool> _filterMap; //maps canvasID -> matchesFilter
        protected CanvasModel _canvasModel;
        protected WorkspaceModel _workspaceModel;

        private delegate bool filterDelegate(CCanvas c);

        public CalicoViewModel()
        {
        }

        public CalicoViewModel(CanvasModel cm, WorkspaceModel wm)
        {
            _canvasModel = cm;
            _workspaceModel = wm;
            navPanelWidth = 175;
            detailPanelHeight = 150;
            allCanvasesView = CollectionViewSource.GetDefaultView(allCanvases);
            selectedTags = new List<string>();
            selectedUsers = new List<string>();
            searchTerm = "";
            navItemHeight = 50;
        }


        public Workspace activeWS
        {
            get { return _activeWS; }
            set
            {
                _activeWS = value;
                OnPropertyChanged("activeWS");
            }
        }

        public List<string> allTags
        {
            get
            {
                return allCanvases.SelectMany(x => x.tags)
                                  .Distinct()
                                  .ToList();
            }
        }

        public Dictionary<string, bool> allTagsChecked
        {
            get
            {
                Dictionary<string, bool> temp = new Dictionary<string, bool>();
                foreach (var tag in allTags)
                {
                    if (selectedTags.Contains(tag))
                        temp.Add(tag, true);
                    else
                        temp.Add(tag, false);
                }
                return temp;
            }
        }

        public List<string> allUsers
        {
            get
            {
                return allCanvases.Select(x => x.user)
                                  .Distinct()
                                  .ToList();
            }
        }

        public Dictionary<string, bool> allUsersChecked
        {
            get
            {
                Dictionary<string, bool> temp = new Dictionary<string, bool>();
                foreach (var user in allUsers)
                {
                    if (selectedUsers.Contains(user))
                        temp.Add(user, true);
                    else
                        temp.Add(user, false);
                }
                return temp;
            }
        }

        public CanvasModel canvasModel
        {
            get { return _canvasModel; }
            set
            {
                _canvasModel = value;
                OnPropertyChanged("canvasModel");
            }
        }

        public ObservableCollection<CCanvas> allCanvases
        {
            get { return _canvasModel.allCanvases; }
            set
            {
                _canvasModel.allCanvases = value;
                OnPropertyChanged("allCanvases");
            }
        }

        public ObservableCollection<Workspace> allWorkspaces
        {
            get { return _workspaceModel.allWorkspaces; }
            set
            {
                _workspaceModel.allWorkspaces = value;
                OnPropertyChanged("allWorkspaces");
            }
        }

        public Dictionary<int, bool> filterMap
        {
            get { return _filterMap; }
            set
            {
                _filterMap = value;
                OnPropertyChanged("filterMap");
            }
        }

        public ICollectionView allCanvasesView { get; set; }

        public void RemoveFromWorkspace(SketchThumbnail s)
        {
            CCanvas c = allCanvases.Where(x => x.ID == s.canvasID).ToList()[0];
            activeWS.RemoveCanvas(c);
        }

        public void RemoveFromWorkspace(CCanvas c)
        {
            activeWS.RemoveCanvas(c);
        }

        public void SortCanvases(string sortProperty, bool ascending)
        {
            allCanvasesView.SortDescriptions.Clear();

            ListSortDirection direction;
            if (ascending)
                direction = ListSortDirection.Ascending;
            else
                direction = ListSortDirection.Descending;

            allCanvasesView.SortDescriptions.Add(new SortDescription(sortProperty,direction));
        }

        public void ChangeSortDirection(bool ascending)
        {
            if (allCanvasesView.SortDescriptions.Count > 0)
            {
                var sort = allCanvasesView.SortDescriptions[0];
                var newSort = new SortDescription();
                newSort.PropertyName = sort.PropertyName;
                if (ascending)
                    newSort.Direction = ListSortDirection.Ascending;
                else
                    newSort.Direction = ListSortDirection.Descending;

                allCanvasesView.SortDescriptions.Clear();
                allCanvasesView.SortDescriptions.Add(newSort);
            }
        }

        public void ClearSort()
        {
            allCanvasesView.SortDescriptions.Clear();
        }
        
        public void ExecuteSearch(string filter)
        {
            ListCollectionView list = (ListCollectionView)allCanvasesView;
            if (filter != "")
                list.Filter = new Predicate<object>(x => ((CCanvas)x).MatchesKeyword(filter));
            else
                list.Filter = null;
        }

        // Virtual keyword = can be overwritten by subclass
        public virtual void ApplyAllFilters()
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
                mf.AddFilter(new Predicate<object>(x => ((CCanvas)x).MatchesKeyword(searchTerm)));
            }

            list.Filter = mf.Filter;

        }

        public void DeleteCanvas(CCanvas c)
        {
            allCanvases.Remove(c);
            _workspaceModel.RemoveCanvas(c);
        }

        public void AddCanvas()
        {
            _canvasModel.NewCanvas();
        }

    }
}
