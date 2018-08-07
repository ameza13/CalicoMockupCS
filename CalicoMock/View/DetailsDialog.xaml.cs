using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CalicoMock.Model;

namespace CalicoMock.View
{
    /// <summary>
    /// Interaction logic for DetailsDialog.xaml
    /// </summary>
    public partial class DetailsDialog : Window
    {
        private CanvasModel _cm;
        private CCanvas _activeCanvas;
        // Used to save state between calls to the tag picker
        private List<string> _allTags;
        private List<string> _currentTags;

        public DetailsDialog(CCanvas activeCanvas, CanvasModel cm)
        {
            InitializeComponent();
            this.DataContext = activeCanvas;
            _activeCanvas = activeCanvas;
            _allTags = cm.allTags;
            _currentTags = _activeCanvas.tags.ToList();
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtTags_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TagPicker tp = new TagPicker(_allTags, _currentTags);
            tp.Owner = Window.GetWindow(this);
            tp.ShowDialog();

            _currentTags = tp.chkTags;
            if (_currentTags != null)
            {
                _allTags = tp.allTags.ToList();
                tp.Close();

                this.txtTags.Text = String.Join(",", _currentTags);
            }
            
        }
    }
}
