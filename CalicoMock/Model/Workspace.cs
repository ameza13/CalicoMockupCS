using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Ink;

namespace CalicoMock.Model
{
    public class Workspace : INotifyPropertyChanged
    {
        private string _name;
        private string _user;
        private string _annotation;
        private DateTime _dateModified;
        private InkCanvas _noteCanvas;
        private ObservableCollection<SketchThumbnail> _sketches;
        private Point _lastInitPoint = new Point(0,0);
        private double _scale = 1;

        public event PropertyChangedEventHandler PropertyChanged;

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }

        public string user
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("user");
            }
        }

        public string annotation
        {
            get { return _annotation; }
            set
            {
                _annotation = value;
                OnPropertyChanged("annotation");
            }
        }

        public DateTime dateModified
        {
            get { return _dateModified; }
            set
            {
                _dateModified = value;
                OnPropertyChanged("dateModified");
            }
        }

        public ObservableCollection<SketchThumbnail> Sketches
        {
            get { return _sketches; }
            set
            {
                _sketches = value;
                OnPropertyChanged("Sketches");
            }
        }

        public double Scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
                OnPropertyChanged("Scale");
            }
        }

        [XmlIgnore]
        public InkCanvas NoteCanvas
        {
            get { return _noteCanvas; }
            set
            {
                _noteCanvas = value;
                OnPropertyChanged("NoteCanvas");
            }
        }

        public Workspace(string Name)
        {
            name = Name;
            Sketches = new ObservableCollection<SketchThumbnail>();
            NoteCanvas = new InkCanvas();
        }

        //Default constructor to allow serialization
        public Workspace()
        {
            Sketches = new ObservableCollection<SketchThumbnail>();
            NoteCanvas = new InkCanvas();
        }

        public Workspace Clone(string Name)
        {
            ObservableCollection<SketchThumbnail> clonedSketches = new ObservableCollection<SketchThumbnail>();
            foreach (SketchThumbnail s in this.Sketches)
            {
                clonedSketches.Add(s.Clone());
            }

            Workspace newWS = new Workspace(Name)
            {
                user = this.user,
                Sketches = clonedSketches,
                dateModified = System.DateTime.Now,
                NoteCanvas = this.NoteCanvas,
                annotation = this.annotation,
                Scale = this.Scale
            };

            return newWS;
        }

        public void AddCanvas(CCanvas c)
        {
            // Only add the canvas if it is not already here
            if (Sketches.Count(s => s.canvasID == c.ID) == 0)
            {
                ObservableCollection<SketchThumbnail> newSketches = Sketches;

                SketchThumbnail s = new SketchThumbnail(c, newSketches.Count);

                Point p = GetNextPoint(_lastInitPoint);
                s.x = p.X;
                s.y = p.Y;
                _lastInitPoint = p;

                newSketches.Add(s);
                Sketches = newSketches;

                c.isInActiveWS = true;
            }
        }

        public void MoveToTop(SketchThumbnail topSketch)
        {
            foreach (SketchThumbnail s in Sketches)
            {
                if (s.z > topSketch.z)
                    s.z = s.z - 1;
            }

            topSketch.z = Sketches.Count;
        }

        public void RemoveCanvas(CCanvas c)
        {
            for (int i = Sketches.Count - 1; i >= 0; i--)
            {

                if (Sketches[i].canvasID == c.ID)
                    Sketches.RemoveAt(i);
            }
            c.isInActiveWS = false;
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void RefreshThumbnails(ObservableCollection<CCanvas> allCanvases)
        {
            foreach (SketchThumbnail s in Sketches)
            {
                CCanvas c = allCanvases.Where(x => x.ID == s.canvasID).ToList()[0];
                s.thumbnail = c.getThumbnail();
            }
        }

        public void RefreshNames(ObservableCollection<CCanvas> allCanvases)
        {
            foreach (SketchThumbnail s in Sketches)
            {
                CCanvas c = allCanvases.Where(x=>x.ID == s.canvasID).ToList()[0];
                s.name = c.name;
            }
        }

        private Point GetNextPoint(Point p)
        {
            p.X += 10;
            p.Y += 10;

            if (p.X > 800)
                p.X = 0;
            if (p.Y > 650)
                p.Y = 0;

            return p;
        }

        public void SaveNotesToFile(string sPath)
        {
            using (FileStream fs = new FileStream(String.Format("{0}\\ws-{1}.isf", sPath, this.name), FileMode.Create))
            {
                NoteCanvas.Strokes.Save(fs);
            }
        }

        public void LoadNotesFromFile(string sPath)
        {
            string path = String.Format("{0}\\ws-{1}.isf", sPath, this.name);
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    NoteCanvas.Strokes = new StrokeCollection(fs);
                }
            }

        }

    }
}
