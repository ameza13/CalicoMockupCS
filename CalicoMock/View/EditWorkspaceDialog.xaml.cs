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
    public partial class EditWorkspaceDialog : Window
    {
        private Workspace _activeWorkspace;

        public EditWorkspaceDialog(bool newWS, Workspace ws)
        {
            InitializeComponent();
            _activeWorkspace = ws;

            _initDialog(newWS);
        }

        private void _initDialog(bool newWS)
        {
            if (newWS)
                this.Title = "New Workspace";
            else
                this.Title = "Edit Workspace";

            _setBindings();
        }

        private void _setBindings()
        {
            // Bind all controls
            Binding newBinding = new Binding();
            // Name
            newBinding = new Binding("name");
            newBinding.Source = _activeWorkspace;
            txtName.SetBinding(TextBox.TextProperty, newBinding);
            // Notes
            newBinding = new Binding("annotation");
            newBinding.Source = _activeWorkspace;
            txtNotes.SetBinding(TextBox.TextProperty, newBinding);
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
