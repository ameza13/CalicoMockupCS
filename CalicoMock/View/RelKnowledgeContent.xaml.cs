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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Data;
using CalicoMock.ViewModel;

namespace CalicoMock.View
{
    /// <summary>
    /// Interaction logic for KnowledgeContent.xaml
    /// </summary>
    public partial class RelKnowledgeContent : Window
    {
        EditorView parent;
        int idKnowledge;
        public RelKnowledgeContent(EditorView w, int id)
        {
            InitializeComponent();
            parent = w;
            this.Top = 50;
            this.Left = 50;
            this.idKnowledge = id;
        }

        public void LoadKnowledge()
        {
            DataTable dtTemp = new DataTable();
            dtTemp = DBOperations.GetKnowledgeById(idKnowledge.ToString());

            string keywords = "";
           // int type = -1;
            string notes = "";

            if (dtTemp.Rows.Count>0)
            {
                //idKnowledge = Int32.Parse(dtTemp.Rows[0]["idKnowledge"].ToString());
                keywords = dtTemp.Rows[0]["keywords"].ToString();
                //type = Int32.Parse(dtTemp.Rows[0]["type"].ToString());
                notes = dtTemp.Rows[0]["description"].ToString();
                //checkedKnowledge = Int32.Parse(dtTemp.Rows[0]["checked"].ToString());
                //usefulKnowledge = Int32.Parse(dtTemp.Rows[0]["useful"].ToString());
            }

            txtKeywords.Text = keywords;
            txtNotes.Text = notes;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadKnowledge();
        }

        private void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
