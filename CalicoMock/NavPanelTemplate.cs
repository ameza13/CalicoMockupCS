using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;

namespace CalicoMock
{
    public class NavPanelTemplate : INotifyPropertyChanged
    {
        private double _headerAngle;
        private ExpandDirection _expDirection;

        public double HeaderAngle
        {
            get { return _headerAngle; }
            set
            {
                _headerAngle = value;
                OnPropertyChanged("HeaderAngle");
            }
        }

        public ExpandDirection ExpDirection
        {
            get { return _expDirection; }
            set
            {
                _expDirection = value;
                OnPropertyChanged("ExpDirection");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NavPanelTemplate()
        {
            SetExpanded();
        }

        public void SetExpanded()
        {
            HeaderAngle = 0.0;
            ExpDirection = ExpandDirection.Down;
        }

        public void SetCollapsed()
        {
            HeaderAngle = -90.0;
            ExpDirection = ExpandDirection.Right;
        }

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
