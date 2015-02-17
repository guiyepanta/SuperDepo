using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_SL;

namespace SuperDepo_DB
{
    public class dbLugarEvento
    {
        #region Singleton dbLugarEvnto    
   
        private dbLugarEvento() { }

        static dbLugarEvento instance = null;

        public static dbLugarEvento getInstance() 
        {
            if (instance == null)
                instance = new dbLugarEvento();

            return instance;
        }
        #endregion
        
        public List<LugarEvento> listaLugaresEvento()
        {
            List<LugarEvento> _lstLugares = new List<LugarEvento>();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerLugaresEvento", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                DataSet ds = new DataSet();
                adptr.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {                    
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        LugarEvento lgr = new LugarEvento();
                        lgr.Id = Convert.ToInt32(row["Id"].ToString());
                        lgr.Establecimiento = row["Establecimiento"].ToString();
                        lgr.Direccion = row["Direccion"].ToString();
                        lgr.Estado = (row["Estado"].ToString() == "1" ? 1 : 0);
                        _lstLugares.Add(lgr);
                    }
                }
                return _lstLugares;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public void guardarDatos(LugarEvento l)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_GuardarDatosLugaresEvento", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                cmnd.Parameters.Add("@id", SqlDbType.Int).Value = l.Id;
                cmnd.Parameters.Add("@Establecimiento", SqlDbType.VarChar, 255).Value = l.Establecimiento;
                cmnd.Parameters.Add("@Direccion", SqlDbType.VarChar, 255).Value = l.Direccion;
                cmnd.Parameters.Add("@estado", SqlDbType.Int).Value = l.Estado;
                
                cmnd.ExecuteNonQuery();
                conn.Close();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public LugarEvento getLugarEvento(int idLugar)
        {
            LugarEvento le = new LugarEvento();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerLugaresEvento", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;
                cmnd.Parameters.Add("@idLugar", SqlDbType.Int).Value = idLugar;

                DataSet ds = new DataSet();
                adptr.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    le.Id = Convert.ToInt32(row["id"]);
                    le.Establecimiento = row["Establecimiento"].ToString();
                    le.Direccion = row["Direccion"].ToString();
                }

                return le;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
