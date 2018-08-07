using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CalicoMock.ViewModel
{
    public class Singleton
    {
        private static Singleton objInstancia;
        public MySqlConnection objConexion;
        private MySqlDataAdapter daBaseDatos;
        private MySqlCommandBuilder cbBaseDatos;
        protected Singleton(string strConn)
        {
            //Se inicializa conexion
            objConexion = new MySqlConnection();
            objConexion.ConnectionString = strConn;
        }

        public static Singleton ObtenerInstancia(string strConn)
        {
            if (objInstancia == null)
            {
                objInstancia = new Singleton(strConn);
            }
            return objInstancia;
        }
    }
}
