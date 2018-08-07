using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;
using System.Xml.Serialization;
using CalicoMock.Properties;

namespace CalicoMock.Model
{
    public class SketchThumbnail : INotifyPropertyChanged
    {
        private double _x;
        private double _y;
        private double _z;
        private int _width;
        private int _height;
        private int _canvasID;
        private bool _isSelected;
        private bool _matchesFilter;
        private string _name;
        private double _scale;
        private CCanvas _canvas;
        private ImageSource _thumbnail;

        public event PropertyChangedEventHandler PropertyChanged;

        //Default constructor to allow serialization
        public SketchThumbnail()
        {
            Scale = 1.0;
        }

        public SketchThumbnail(CCanvas c, double zindex)
        {
            _canvasID = c.ID;
            _canvas = c;
            _matchesFilter = true;
            name = c.name;
            x = 50;
            y = 50;
            z = zindex;
            width = 100 * (int)Settings.Default.workingAreaWidth / (int)Settings.Default.workingAreaHeight;
            height = 100;
            Scale = 1.0;
            thumbnail = c.thumbnail;
        }

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("name");
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

        public double x
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged("x");
            }
        }

        public double y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged("y");
            }
        }

        public double z
        {
            get { return _z; }
            set
            {
                _z = value;
                OnPropertyChanged("z");
            }
        }

        public int width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged("width");
            }
        }

        public int height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged("height");
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public bool MatchesFilter
        {
            get { return _matchesFilter; }
            set
            {
                _matchesFilter = value;
                OnPropertyChanged("MatchesFilter");
            }
        }

        public int canvasID
        {
            get { return _canvasID; }
            set
            {
                _canvasID = value;
                OnPropertyChanged("canvasID");
            }
        }

        public CCanvas canvas
        {
            get { return _canvas; }
            set
            {
                _canvas = value;
                OnPropertyChanged("canvas");
            }
        }

        [XmlIgnore]
        public ImageSource thumbnail
        {
            get { return _thumbnail; }
            set
            {
                _thumbnail = value;
                OnPropertyChanged("thumbnail");
            }
        }

        public SketchThumbnail Clone()
        {
            SketchThumbnail newSketchThumb = new SketchThumbnail()
            {
                canvasID = this.canvasID, 
                thumbnail = this.thumbnail,
                name = this.name,
                canvas = this.canvas,
                z = this.z, 
                x = this.x,
                y = this.y,
                height = this.height,
                width = this.width,
                IsSelected = this.IsSelected,
                MatchesFilter = this.MatchesFilter,
                Scale = this.Scale
            };

            return newSketchThumb;
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

    }
}
