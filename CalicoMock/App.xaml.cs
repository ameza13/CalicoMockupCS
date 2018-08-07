using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using CalicoMock.View;
using CalicoMock.ViewModel;
using CalicoMock.Model;
using System.ComponentModel;
using System.Windows.Threading;
using System.Windows.Input;
using System.Threading;

namespace CalicoMock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private WorkspaceView _MainView;
        private EditorView _EditorView;

        private CanvasModel _cModel;
        private WorkspaceModel _wsModel;
        private WorkspaceViewModel _mainViewModel;

        DispatcherTimer timer;
        int autoSaveInterval = 10000; //autosave every 30 seconds
        DateTime lastSave;

        public App()
        {
            timer = new DispatcherTimer(TimeSpan.FromMilliseconds(autoSaveInterval), DispatcherPriority.Background, new EventHandler(DoAutoSave), this.Dispatcher);
            timer.Start();
        }

        private void DoAutoSave(object sender, EventArgs e)
        {
            if (DateTime.Now.Subtract(lastSave).TotalMilliseconds >= autoSaveInterval)
            {
                SaveState(false); //save but do not commit to final save
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoadState(out _cModel, out _wsModel);

            var editorContext = new EditorViewModel(_cModel, _wsModel);
            _EditorView = new EditorView(editorContext);
            editorContext.RaiseDoneEditingEvent += CloseCanvas;

            _mainViewModel = new WorkspaceViewModel(_cModel, _wsModel);
            _MainView = new WorkspaceView(_mainViewModel);
            _mainViewModel.RaiseEditCanvasEvent += OpenCanvas;
            _MainView.Show();

        }

        public void OpenCanvas(object sender, CCanvas c)
        {
            _MainView.Hide();
            _EditorView.PauseMouseCapture();
            EditorViewModel context = _EditorView.DataContext as EditorViewModel;
            context.activeCanvas = c;
            // HACK
            WorkspaceViewModel mvm = _MainView.DataContext as WorkspaceViewModel;
            string wsName;
            if (_MainView.navHasFocus)
                wsName = "All Canvases";
            else
                wsName = mvm.activeWS.name;
            _EditorView.RefreshWorkspaceComboBox(wsName);
            _EditorView.SelectActiveCanvas();
            _EditorView.Show();
            Console.WriteLine("Done opening canvas!");
        }

        public void CloseCanvas(object sender, EventArgs e)
        {
            _EditorView.Hide();
            _MainView.Show();
            _MainView.RefreshWorkspaces();
            _MainView.RebindWorkspace();
            _MainView.ApplyAllFilters();
        }

        public void LoadState(out CanvasModel cm, out WorkspaceModel wm)
        {
            string dataPath = ".\\data";

            string path = dataPath + "\\canvasstate.xml";
            if (File.Exists(path))
            {
                XmlSerializer x = new XmlSerializer(typeof(CanvasModel));
                CanvasModel tempModel;

                using (XmlReader xReader = XmlReader.Create(path))
                {
                    tempModel = (CanvasModel)x.Deserialize(xReader);
                }

                foreach (CCanvas c in tempModel.allCanvases)
                {
                    c.LoadFromFile(dataPath);
                }

                cm = tempModel;
            }
            else
            {
                cm = new CanvasModel();
            }

            path = dataPath + "\\workspacestate.xml";
            if (File.Exists(path))
            {
                XmlSerializer x = new XmlSerializer(typeof(WorkspaceModel));
                WorkspaceModel tempModel;

                using (XmlReader xReader = XmlReader.Create(path))
                {
                    tempModel = (WorkspaceModel)x.Deserialize(xReader);
                }

                foreach (Workspace ws in tempModel.allWorkspaces)
                {
                    foreach (SketchThumbnail s in ws.Sketches)
                    {
                        CCanvas ancestor = cm[s.canvasID];
                        s.thumbnail = ancestor.getThumbnail();
                        s.canvas = ancestor;
                    }
                }

                wm = tempModel;

                foreach (Workspace ws in _wsModel.allWorkspaces)
                {
                    ws.LoadNotesFromFile(dataPath);
                }
            }
            else
            {
                wm = new WorkspaceModel();
                wm.Initialize();
            }
        }

        public void SaveState(bool commit=true)
        {
            // First save state to a temp directory, in case there
            // are any problems saving.  If the save works, then replace
            // the contents of the data dir with those from the temp dir.
            Console.WriteLine("Saving...");
            string dataPath = ".\\data";
            string tempPath = ".\\data\\temp";

            XmlSerializer x = new XmlSerializer(_cModel.GetType());
            Directory.CreateDirectory(dataPath);
            if (Directory.Exists(tempPath))
                Directory.Delete(tempPath,true);
            Directory.CreateDirectory(tempPath);

            string path = tempPath + "\\canvasstate.xml";
            
            using (XmlWriter xWriter = XmlWriter.Create(path))
            {
                x.Serialize(xWriter, _cModel);
            }

            foreach (CCanvas c in _cModel.allCanvases)
            {
                c.SaveToFile(tempPath);
            }

            x = new XmlSerializer(_wsModel.GetType());
            path = tempPath + "\\workspacestate.xml";
            using (XmlWriter xWriter = XmlWriter.Create(path))
            {
                x.Serialize(xWriter, _wsModel);
            }

            foreach (Workspace ws in _wsModel.allWorkspaces)
            {
                ws.SaveNotesToFile(tempPath);
            }

            // If the temp save completes, copy the temp files
            // to the data directory
            if (commit) //do this only for commit=true (so not autosaves)
            {
                foreach (string f in Directory.GetFiles(dataPath))
                {
                    File.Delete(f);
                }

                foreach (string f in Directory.GetFiles(tempPath))
                {
                    File.Copy(string.Format(f),
                        string.Format("{0}\\{1}", dataPath, Path.GetFileName(f)));
                }
            }
            lastSave = DateTime.Now;
            Console.WriteLine("Saving complete!");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            SaveState();
        }

    }
}
