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
    public partial class KnowledgeContent : Window
    {
        EditorView parent;
        int checkedKnowledge;
        int usefulKnowledge;
        int idKnowledge;
        public KnowledgeContent(EditorView w)
        {
            InitializeComponent();
            parent = w;
            this.Top = 50;
            this.Left = 50;
            checkedKnowledge = 0; //No revisado
            usefulKnowledge = 0; //No sabe
            idKnowledge = -1; //No existe
            
        }

        public void LoadKnowledge()
        {
            DataTable dtTemp = new DataTable();
            dtTemp = DBOperations.GetKnowledgeByFlag();
            
            string keywords = "";
            int type = -1;
            string notes = "";

            if (dtTemp.Rows.Count>0)
            {
                idKnowledge = Int32.Parse(dtTemp.Rows[0]["idKnowledge"].ToString());
                keywords = dtTemp.Rows[0]["keywords"].ToString();
                type = Int32.Parse(dtTemp.Rows[0]["type"].ToString());
                notes = dtTemp.Rows[0]["description"].ToString();
                checkedKnowledge = Int32.Parse(dtTemp.Rows[0]["checked"].ToString());
                usefulKnowledge = Int32.Parse(dtTemp.Rows[0]["useful"].ToString());
            }

            txtKeywords.Text = keywords;
            txtNotes.Text = notes;
            /*foreach (DataRow row in dtTemp.Rows)
            {            
                id = Int32.Parse(row["idKnowledge"].ToString());
                keywords = row["keywords"].ToString();
                type = Int32.Parse(row["type"].ToString());
                notes = row["description"].ToString();
                flag = Int32.Parse(row["checked"].ToString());
            }*/
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            DBOperations.UpdateFlag(idKnowledge, 1, 1);//Update checked in DB to TRUE(1)
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            DBOperations.UpdateFlag(idKnowledge, 1, 0);//Update useful in DB to TRUE(1)      
            DBOperations.UpdateFlag(idKnowledge, 1, 1);//Update checked in DB to TRUE(1)
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
    }
}
