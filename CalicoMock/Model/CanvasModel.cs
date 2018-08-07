using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.ComponentModel;

namespace CalicoMock.Model
{
    public class CanvasModel : INotifyPropertyChanged
    {
        private ObservableCollection<CCanvas> _allCanvases;

        private int _id;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CCanvas> allCanvases
        {
            get { return _allCanvases; }
            set
            {
                _allCanvases = value;
                OnPropertyChanged("allCanvases");
            }
        }

        public CCanvas this[int index]
        {
            get
            {
                return _allCanvases.Where(c => c.ID == index).ToList()[0];
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

        public CanvasModel()
        {
            allCanvases = new ObservableCollection<CCanvas>();
            Random rand = new Random();
            _id = (int)rand.Next(0, 1000);
        }

        public CCanvas NewCanvas()
        {
            ObservableCollection<CCanvas> NewCanvases = allCanvases;
            CCanvas newCanvas = new CCanvas(NextID());
            NewCanvases.Add(newCanvas);
            allCanvases = NewCanvases;
            return newCanvas;
        }

        public CCanvas CloneCanvas(CCanvas c)
        {
            ObservableCollection<CCanvas> NewCanvases = allCanvases;
            CCanvas newCanvas = new CCanvas(NextID());
            foreach (Stroke s in c.canvas.Strokes)
            {
                newCanvas.canvas.Strokes.Add(s.Clone());
            }

            newCanvas.name = string.Format("{0} - Copy", c.name);

            NewCanvases.Add(newCanvas);
            allCanvases = NewCanvases;
            return newCanvas;
        }

        public void ExportSerialize(string path)
        {
            XmlSerializer x = new XmlSerializer(this.GetType());
            using (XmlWriter xWriter = XmlWriter.Create(path))
            {
                x.Serialize(xWriter, this);
            }

        }

        public void LoadAllCanvases(string path)
        {
            foreach (string file in Directory.EnumerateFiles(path))
            {
                if (File.Exists(file))
                {
                    CCanvas newCanvas = NewCanvas();
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        newCanvas.canvas.Strokes = new StrokeCollection(fs);
                    }
                    allCanvases.Add(newCanvas);
                }

            }
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private int NextID()
        {
            int lastID = allCanvases[allCanvases.Count - 1].ID;
            return lastID + 1;
        }

    }
}
