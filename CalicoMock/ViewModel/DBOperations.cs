using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace CalicoMock.ViewModel
{
    public static class DBOperations
    {
        static Singleton objSingleton;
        static int iFilas = 0;
        public static void SetUpConnection()
        {
            string strConn = "Server=amezadevelopment.online;Database=amezadev_hc;Uid=ameza_hc;Pwd=HClinico123!;";
            objSingleton = Singleton.ObtenerInstancia(strConn);
        }

        public static DataTable GetKnowledgeById(string id)
        {
            string query = "SELECT idKnowledge, keywords, type, description, checked, useful FROM devknowledge WHERE idKnowledge = " + id;
            MySqlCommand cmd = new MySqlCommand(query, objSingleton.objConexion);
            Debug.WriteLine("query: "+query);
            MySqlDataAdapter dataAdapter;
            DataTable dtTable = new DataTable();
            try
            {
                cmd.Connection.Open();
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dtTable);
                cmd.Connection.Close();
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dtTable;
        }
        public static DataTable GetUsefulKnowledge()
        {
            string query = "SELECT idKnowledge, keywords FROM devknowledge WHERE useful = 1 and checked = 1"; //Nuevo conocimiento
            MySqlCommand cmd = new MySqlCommand(query, objSingleton.objConexion);
            Debug.WriteLine("query: " + query);
            MySqlDataAdapter dataAdapter;
            DataTable dtTable = new DataTable();
            try
            {
                cmd.Connection.Open();
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dtTable);
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
            }
            finally
            {              
                cmd.Connection.Close();
            }
            return dtTable;
        }
        public static DataTable GetKnowledgeByFlag()
        {
            string query = "SELECT idKnowledge, keywords, type, description, checked, useful FROM devknowledge WHERE checked = 0"; //Nuevo conocimiento
            MySqlCommand cmd = new MySqlCommand(query, objSingleton.objConexion);
            Debug.WriteLine("query: " + query);
            MySqlDataAdapter dataAdapter;
            DataTable dtTable = new DataTable();
            try
            {
                cmd.Connection.Open();
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dtTable);
                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
            }
            finally
            {              
                cmd.Connection.Close();
            }
            return dtTable;
        }
        public static int CheckNewKnowledge()
        {
            string query = "SELECT count(*) FROM devknowledge WHERE checked = 0"; //Nuevo conocimiento
            MySqlCommand cmd = new MySqlCommand(query, objSingleton.objConexion);
            Debug.WriteLine("query: " + query);
            int result = 0;
            try
            {
                cmd.Connection.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Dispose();
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
            }
            finally
            {
                cmd.Connection.Close();
            }
            return result;
        }
        public static void UpdateFlag(int id, int val, int flagType)
        {
            string query;
            if (flagType == 1)  
            {
                //update devknowledge set checked = 1 where idKnowledge = 1
                query = "update devknowledge set checked = "+ val +" where idKnowledge = " + id;
            }else
            {
                //update devknowledge set useful = 1 where idKnowledge = 1
                query = "update devknowledge set useful = "+ val +" WHERE idKnowledge = " + id;
            }
            
            MySqlCommand cmd = new MySqlCommand(query, objSingleton.objConexion);
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = query;               
                cmd.ExecuteNonQuery();               
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

    }
}
