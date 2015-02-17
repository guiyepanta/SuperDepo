using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_SL;

namespace SuperDepo_DB
{
    public class dbTiposProducto
    {
        #region Singleton dbTiposProducto    
   
        private dbTiposProducto() { }

        static dbTiposProducto instance = null;

        public static dbTiposProducto getInstance() 
        {
            if (instance == null)
                instance = new dbTiposProducto();

            return instance;
        }
        #endregion
        
        public List<TipoProducto> listaTiposProducto()
        {
            List<TipoProducto> _lstTipos = new List<TipoProducto>();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerTiposProductos", conn);
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
                        TipoProducto tipo = new TipoProducto();
                        tipo.Id = Convert.ToInt32(row["Id"].ToString());
                        tipo.tipo = row["tipo"].ToString();
                        tipo.exigeCantidad = (row["exigeCantidad"].ToString() == "True");
                        tipo.agruparEnReportes = (row["agruparEnReporte"].ToString() == "True");
                        _lstTipos.Add(tipo);
                    }
                }
                return _lstTipos;
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

        public void GuardarDatos(TipoProducto tipo)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_GuardarDatosTiposProductos", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                cmnd.Parameters.Add("@idTipo", SqlDbType.Int).Value = tipo.Id;
                cmnd.Parameters.Add("@tipo", SqlDbType.VarChar, 50).Value = tipo.tipo;
                cmnd.Parameters.Add("@agruparEnReportes", SqlDbType.Bit).Value = tipo.agruparEnReportes;
                cmnd.Parameters.Add("@exigeCantidad", SqlDbType.Bit).Value = tipo.exigeCantidad;

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
