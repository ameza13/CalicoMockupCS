using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Ink;
using System.Collections.ObjectModel;
using CalicoMock.Properties;

namespace CalicoMock.Model
{
    public class CCanvas : INotifyPropertyChanged
    {
        #region Fields

        private InkCanvas _canvas;
        private ImageSource _thumbnail;

        private string _name;
        private string _user;
        private string _annotation;
        private DateTime _modified;
        private bool _isInActiveWS;
        private bool _matchesFilter;
        private bool _isFavorite;
        private ObservableCollection<string> _tags;

        #endregion //Fields

        #region Public Properties

        public int ID { get; set; }

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

        // Won't change once set
        public DateTime created { get; set; }

        public DateTime modified
        {
            get { return _modified; }
            set
            {
                _modified = value;
                OnPropertyChanged("modified");
            }
        }

        public bool isInActiveWS
        {
            get { return _isInActiveWS; }
            set
            {
                _isInActiveWS = value;
                OnPropertyChanged("isInActiveWS");
            }
        }

        public bool matchesFilter
        {
            get { return _matchesFilter; }
            set
            {
                _matchesFilter = value;
                OnPropertyChanged("matchesFilter");
            }
        }

        public bool IsFavorite
        {
            get { return _isFavorite; }
            set
            {
                _isFavorite = value;
                OnPropertyChanged("IsFavorite");
            }
        }

        public ObservableCollection<string> tags
        {
            get { return _tags; }
            set
            {
                _tags = value;
                OnPropertyChanged("tags");
            }
        }

        [XmlIgnore]
        public InkCanvas canvas
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

        #endregion //Public Properties

        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructor

        // empty constructor required for serialization
        public CCanvas()
        {
            canvas = new InkCanvas();
            IsFavorite = false;
        }

        public CCanvas(int id)
        {
            ID = id;
            name = String.Format("NewCanvas{0}",id);
            canvas = new InkCanvas();
            created = DateTime.Now;
            modified = created;
            tags = new ObservableCollection<string>();
            user = Environment.UserName;
            annotation = "";
            IsFavorite = false;
        }

        #endregion //Constructor

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ImageSource getThumbnail()
        {
            int srcHeight = (int)Settings.Default.workingAreaHeight;
            int srcWidth = (int)Settings.Default.workingAreaWidth;
            double adjustment = 400.0/srcWidth;
            RenderTargetBitmap rtb = new RenderTargetBitmap(srcWidth, srcHeight, 96d, 96d, PixelFormats.Default);
            //RenderTargetBitmap rtb = new RenderTargetBitmap(650, 400, 96d, 96d, PixelFormats.Default);
            rtb.Render(_canvas);
            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));
            TransformedBitmap tb = new TransformedBitmap(rtb, new ScaleTransform(adjustment, adjustment));
            //Image newThumb = new Image();
            //newThumb.Source = tb;
            return tb;
        }

        public void SaveToFile(string sPath)
        {
            using (FileStream fs = new FileStream(String.Format("{0}\\{1}.isf", sPath, this.ID), FileMode.Create))
            {
                canvas.Strokes.Save(fs);
            }
        }

        public void LoadFromFile(string sPath)
        {
            string path = String.Format("{0}\\{1}.isf", sPath, this.ID);
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    canvas.Strokes = new StrokeCollection(fs);
                }
                thumbnail = getThumbnail();
            }

        }

        public bool MatchesKeyword(string keyword)
        {
            if (name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) > -1)
                return true;
            else if (tags.Any(t => t.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) > -1))
                return true;
            else if (annotation != null)
            {
                if (annotation.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) > -1)
                    return true;
            }
            
            return false;
        }

        public void RefreshThumbnail()
        {
            thumbnail = getThumbnail();
        }
    }
}
