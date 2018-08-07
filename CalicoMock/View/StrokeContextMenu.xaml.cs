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
    /// Interaction logic for StrokeContextMenu.xaml
    /// </summary>
    public partial class StrokeContextMenu : Window
    {
        private EditorView _parent;

        public StrokeContextMenu(EditorView parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void cboCopyStroke_Click(object sender, RoutedEventArgs e)
        {
            _parent.copySelectedStroke();
        }
    }
}
