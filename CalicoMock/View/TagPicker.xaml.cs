using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CalicoMock.View
{
    /// <summary>
    /// Interaction logic for TagPicker.xaml
    /// </summary>
    public partial class TagPicker : Window
    {
        public ObservableCollection<string> allTags { get; set; }
        public List<string> chkTags { get; set; }

        public TagPicker(List<string> tagList, List<string> checkedTags)
        {
            allTags = new ObservableCollection<string>();

            foreach (string tag in tagList)
                allTags.Add(tag);

            InitializeComponent();

            lbTags.ItemsSource = allTags;

            foreach (string item in lbTags.Items)
            {
                if (checkedTags.Contains(item))
                {
                    lbTags.SelectedItems.Add(item);
                }
            }
        }

        private void cmdAddTags_Click(object sender, RoutedEventArgs e)
        {
            List<string> newTags = txtCustomTags.Text.Split(',').Select(s=>s.Trim()).ToList();

            foreach (string tag in newTags)
            {
                if (!allTags.Contains(tag))
                    allTags.Add(tag);
            }

        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            chkTags = new List<string>();

            foreach (string item in lbTags.SelectedItems)
            {
                chkTags.Add(item);
            }

            this.Hide();
        }

    }
}
