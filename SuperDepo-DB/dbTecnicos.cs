using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_SL;

namespace SuperDepo_DB
{
    public class dbTecnico
    {
        #region Singleton dbTecnico    
   
        private dbTecnico() { }

        static dbTecnico instance = null;

        public static dbTecnico getInstance() 
        {
            if (instance == null)
                instance = new dbTecnico();

            return instance;
        }
        #endregion
        
        public List<Tecnico> listaTecnicos()
        {
            List<Tecnico> _lstTec = new List<Tecnico>();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerTecnicos", conn);
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
                        Tecnico tec = new Tecnico();
                        tec.Id = Convert.ToInt32(row["Id"].ToString());
                        tec.Nombre = row["Nombre"].ToString();
                        tec.Cargo = row["Cargo"].ToString();
                        tec.Dni = row["Dni"].ToString();
                        tec.Telefono = row["Telefono"].ToString();
                        tec.Estado = Convert.ToInt32(row["Estado"].ToString());
                        _lstTec.Add(tec);
                    }
                }
                return _lstTec;
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

        public void GuardarDatos(Tecnico tec)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_GuardarDatosTecnico", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                cmnd.Parameters.Add("@idTecnico", SqlDbType.Int).Value = tec.Id;
                cmnd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = tec.Nombre;
                cmnd.Parameters.Add("@cargo", SqlDbType.VarChar, 50).Value = tec.Cargo;
                cmnd.Parameters.Add("@telefono", SqlDbType.VarChar, 25).Value = tec.Telefono;
                cmnd.Parameters.Add("@dni", SqlDbType.VarChar, 10).Value = tec.Dni;
                cmnd.Parameters.Add("@estado", SqlDbType.Int).Value = tec.Estado;

                int lint = cmnd.ExecuteNonQuery();
                
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
    }
}
