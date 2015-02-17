using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace SuperDepo_DB
{
    public class Conexion
    {
        
        #region Singleton UserManager       
        
        private Conexion()
        { 
        }

        static Conexion instance = null;

        public static Conexion getInstance() 
        {
            if (instance == null)
                instance = new Conexion();

            return instance;
        }
        #endregion

        public string conectionString()
        { 
            String _strConn = "";
            String _strServer = "";
            _strServer = ConfigurationManager.AppSettings["Server"].ToString();
            _strConn = ConfigurationManager.ConnectionStrings["SuperDepo"].ToString().Replace("[SERVER]", _strServer);
           
            return _strConn;
        }

        public bool Verificar()
        {
            bool connOk = false;
            SqlConnection verifConn = new SqlConnection(this.conectionString());
            
            try
            {
                // Abro Conexion
                verifConn.Open();
                connOk = true;
            }
            catch (Exception)
            {
                // Falla conexion
                connOk = false;
            }
            finally { 
               // Cierro Conexion
                verifConn.Close();
            }

            return connOk;       
        }
    }
}
