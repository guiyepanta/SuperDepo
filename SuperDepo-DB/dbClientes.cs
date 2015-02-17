using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_SL;

namespace SuperDepo_DB
{
    public class dbCliente
    {
        #region Singleton dbCliente    
   
        private dbCliente() { }

        static dbCliente instance = null;

        public static dbCliente getInstance() 
        {
            if (instance == null)
                instance = new dbCliente();

            return instance;
        }
        #endregion
        
        public List<Cliente> listaClientes()
        {
            List<Cliente> _lstCliente = new List<Cliente>();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerClientes", conn);
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
                        // Cliente
                        Cliente cl = new Cliente();
                        cl.Id = Convert.ToInt32(row["id"].ToString());
                        cl.CodigoPostal = row["codigoPostal"].ToString();
                        cl.Condicion = row["condicion"].ToString();
                        cl.Contacto = row["contacto"].ToString();
                        cl.Cuil = row["cuil"].ToString();
                        cl.Direccion = row["direccion"].ToString();
                        cl.Email = row["email"].ToString();
                        cl.Localidad = row["localidad"].ToString();
                        cl.Nombre = row["nombre"].ToString();
                        cl.Observaciones = row["observaciones"].ToString();
                        cl.telCelular = row["telCelular"].ToString();
                        cl.telContacto = row["telContacto"].ToString();
                        _lstCliente.Add(cl);                       
                    }
                }
                return _lstCliente;
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

        public void GuardarDatos(Cliente cl)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_GuardarDatosCliente", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                cmnd.Parameters.Add("@id", SqlDbType.Int).Value = cl.Id;
                cmnd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = cl.Nombre;
                cmnd.Parameters.Add("@contacto", SqlDbType.VarChar, 50).Value = cl.Contacto;
                cmnd.Parameters.Add("@telContacto", SqlDbType.VarChar, 50).Value = cl.telContacto;
                cmnd.Parameters.Add("@telCelular", SqlDbType.VarChar, 50).Value = cl.telCelular;
                cmnd.Parameters.Add("@direccion", SqlDbType.VarChar, 80).Value = cl.Direccion;
                cmnd.Parameters.Add("@codigoPostal", SqlDbType.VarChar, 20).Value = cl.CodigoPostal;
                cmnd.Parameters.Add("@localidad", SqlDbType.VarChar, 50).Value = cl.Localidad;
                cmnd.Parameters.Add("@cuil", SqlDbType.VarChar, 15).Value = cl.Cuil;
                cmnd.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = cl.Condicion;
                cmnd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = cl.Email;
                cmnd.Parameters.Add("@observaciones", SqlDbType.VarChar, 255).Value = cl.Observaciones;

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

        public Cliente getCliente(int idCliente)
        {
            Cliente cl = new Cliente();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerCliente", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;
                cmnd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

                DataSet ds = new DataSet();
                adptr.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    // Cliente
                    cl.Id = Convert.ToInt32(row["id"].ToString());
                    cl.CodigoPostal = row["codigoPostal"].ToString();
                    cl.Condicion = row["condicion"].ToString();
                    cl.Contacto = row["contacto"].ToString();
                    cl.Cuil = row["cuil"].ToString();
                    cl.Direccion = row["direccion"].ToString();
                    cl.Email = row["email"].ToString();
                    cl.Localidad = row["localidad"].ToString();
                    cl.Nombre = row["nombre"].ToString();
                    cl.Observaciones = row["observaciones"].ToString();
                    cl.telCelular = row["telCelular"].ToString();
                    cl.telContacto = row["telContacto"].ToString();                   
                }
                return cl;
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
