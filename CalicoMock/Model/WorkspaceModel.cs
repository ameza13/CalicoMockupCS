using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace CalicoMock.Model
{
    public class WorkspaceModel : INotifyPropertyChanged
    {
        private ObservableCollection<Workspace> _allWorkspaces;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Workspace> allWorkspaces
        {
            get { return _allWorkspaces; }
            set
            {
                _allWorkspaces = value;
                OnPropertyChanged("allWorkspaces");
            }
        }

        // Default constructor to allow serialization
        public WorkspaceModel()
        {

        }

        public void Initialize()
        {
            allWorkspaces = new ObservableCollection<Workspace>();
            allWorkspaces.Add(new Workspace("Workspace1"));
        }

        public Workspace NewWorkspace(string Name)
        {
            Workspace newWorkspace = new Workspace(Name);
            allWorkspaces.Add(newWorkspace);
            return newWorkspace;
        }

        public Workspace CloneWorkspace(Workspace ws, string Name)
        {
            Workspace newWorkspace = ws.Clone(Name);
            allWorkspaces.Add(newWorkspace);
            return newWorkspace;
        }

        public void Remove(Workspace ws)
        {
            allWorkspaces.Remove(ws);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void RefreshWorkspaces(ObservableCollection<CCanvas> allCanvases)
        {
            foreach (Workspace ws in allWorkspaces)
                ws.RefreshThumbnails(allCanvases);
        }

        public void RefreshSketchNames(ObservableCollection<CCanvas> allCanvases)
        {
            foreach (Workspace ws in allWorkspaces)
                ws.RefreshNames(allCanvases);
        }

        public void RemoveCanvas(CCanvas c)
        {
            foreach (Workspace ws in allWorkspaces)
            {
                ws.RemoveCanvas(c);
            }
        }

    }
}
