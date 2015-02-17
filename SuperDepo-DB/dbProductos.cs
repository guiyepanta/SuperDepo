using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_SL;

namespace SuperDepo_DB
{
    public class dbProducto
    {
        #region Singleton dbProducto    
   
        private dbProducto() { }

        static dbProducto instance = null;

        public static dbProducto getInstance() 
        {
            if (instance == null)
                instance = new dbProducto();

            return instance;
        }
        #endregion
        
        public void EliminarProducto(String CodigoProducto)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_EliminarProducto", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@codProducto", SqlDbType.VarChar, 100).Value = CodigoProducto;
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

        public List<Producto> productosDisponibles(string campo, string criterio)
        {
            List<Producto> _lstPrd = new List<Producto>();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerProductosDisponibles", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@campo", SqlDbType.VarChar).Value = campo;
                cmnd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = criterio;

                SqlDataAdapter adptr = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adptr.SelectCommand = cmnd;
                adptr.Fill(ds);
                conn.Close();

                // Si trae datos es porque hay Productos Disponibles
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Producto prd = new Producto();
                        prd.CodigoProducto = dr["codigo"].ToString();
                        prd.Descripcion = dr["descripcion"].ToString();
                        //Tipo
                        prd.IdTipoProducto = Convert.ToInt32(dr["tipoProducto"].ToString());
                        prd.TipoProducto = dr["tipo"].ToString();
                        prd.TipoExigeCantidad = (dr["ExigeCantidad"].ToString() == "True");
                        //----
                        prd.CategoriaProducto = dr["categoria"].ToString();
                        prd.MarcaProducto = dr["marca"].ToString();
                        prd.ModeloProducto = dr["modelo"].ToString();
                        prd.SerieProducto = dr["numeroSerie"].ToString();
                        prd.Horas = (dr["horas"].ToString() == "" ? 0 : Convert.ToInt32(dr["horas"].ToString()));
                        prd.Peso = dr["peso"].ToString();
                        prd.Medidas = dr["medidas"].ToString();
                        prd.Observacion = dr["observacion"].ToString();
                        prd.Cantidad = Convert.ToInt32(dr["cantidad"].ToString());
                        //Estado
                        prd.Estado = dr["detalle"].ToString();
                        prd.idEstado = Convert.ToInt32(dr["estado"].ToString());
                        //------
                        _lstPrd.Add(prd);
                    }
                }
                return _lstPrd;
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

        public List<Producto> getAllProductos(string campo = "", string criterio = "")
        {
            List<Producto> _lstPrd = new List<Producto>();
            ExceptionManager.log("ConnString",Conexion.getInstance().conectionString());

            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerProductos", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@campo", SqlDbType.VarChar).Value = campo;
                cmnd.Parameters.Add("@criterio", SqlDbType.VarChar).Value = criterio;

                SqlDataAdapter adptr = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adptr.SelectCommand = cmnd;
                adptr.Fill(ds);
                conn.Close();

                // Si trae datos es porque hay Productos Disponibles
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Producto prd = new Producto();
                        prd.CodigoProducto = dr["codigo"].ToString();
                        prd.Descripcion = dr["descripcion"].ToString();
                        //Tipo
                        prd.IdTipoProducto = Convert.ToInt32(dr["tipoProducto"].ToString());
                        prd.TipoProducto = dr["tipo"].ToString();
                        prd.TipoExigeCantidad = (dr["ExigeCantidad"].ToString() == "True");
                        //----
                        prd.CategoriaProducto = dr["categoria"].ToString();
                        prd.MarcaProducto = dr["marca"].ToString();
                        prd.ModeloProducto = dr["modelo"].ToString();
                        prd.SerieProducto = dr["numeroSerie"].ToString();
                        prd.Horas = (dr["horas"].ToString() == "" ? 0 : Convert.ToInt32(dr["horas"].ToString()));
                        prd.Peso = dr["peso"].ToString();
                        prd.Medidas = dr["medidas"].ToString();
                        prd.Observacion = dr["observacion"].ToString();
                        prd.Cantidad = (dr["cantidad"].ToString() == "" ? 0 : Convert.ToInt32(dr["cantidad"].ToString()));
                        prd.dh = (dr["dh"].ToString() == "" ? 0 : Convert.ToInt32(dr["dh"].ToString()));
                        //Estado
                        prd.Estado = dr["detalle"].ToString();
                        prd.idEstado = Convert.ToInt32(dr["estado"].ToString());
                        //------
                        _lstPrd.Add(prd);
                    }
                }
                return _lstPrd;
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message , ex.StackTrace);
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public object getProduto(string codProducto)
        {
            Producto prd = null;
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerProducto", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@codProducto", SqlDbType.VarChar, 100).Value = codProducto;

                SqlDataAdapter adptr = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adptr.SelectCommand = cmnd;
                adptr.Fill(ds);
                conn.Close();

                // Si trae datos es porque hay Producto con el codigo Ingresado
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        prd = new Producto();
                        prd.CodigoProducto = dr["codigo"].ToString();
                        prd.Descripcion = dr["descripcion"].ToString();
                        //Tipo
                        prd.IdTipoProducto = Convert.ToInt32(dr["tipoProducto"].ToString());
                        prd.TipoProducto = dr["tipo"].ToString();
                        prd.TipoExigeCantidad = (dr["ExigeCantidad"].ToString() == "True");
                        //----
                        prd.CategoriaProducto = dr["categoria"].ToString();
                        prd.MarcaProducto = dr["marca"].ToString();
                        prd.ModeloProducto = dr["modelo"].ToString();
                        prd.SerieProducto = dr["numeroSerie"].ToString();
                        prd.Horas = (dr["horas"].ToString() == "" ? 0 : Convert.ToInt32(dr["horas"].ToString()));
                        prd.Peso = dr["peso"].ToString();
                        prd.Medidas = dr["medidas"].ToString();
                        prd.Observacion = dr["observacion"].ToString();
                        prd.Cantidad = Convert.ToInt32(dr["cantidad"].ToString());
                        prd.dh = Convert.ToInt32(dr["dh"].ToString());
                        //Estado
                        prd.Estado = dr["detalle"].ToString();
                        prd.idEstado = Convert.ToInt32(dr["estado"].ToString());
                        //------
                    }
                }
                return prd;
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

        public DataSet getEstadosProducto()
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerEstadosProducto", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adptr.SelectCommand = cmnd;
                adptr.Fill(ds);
                conn.Close();

                return ds;
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

        public void guardarProducto(Producto prd, bool modifyMode)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_GuardarDatosPorductos", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@codigo", SqlDbType.VarChar, 100).Value = prd.CodigoProducto;
                cmnd.Parameters.Add("@tipoProducto", SqlDbType.Int).Value = prd.IdTipoProducto;
                cmnd.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = prd.Descripcion;
                cmnd.Parameters.Add("@categoria", SqlDbType.VarChar, 255).Value = prd.CategoriaProducto;
                cmnd.Parameters.Add("@marca", SqlDbType.VarChar, 255).Value = prd.MarcaProducto;
                cmnd.Parameters.Add("@modelo", SqlDbType.VarChar, 255).Value = prd.ModeloProducto;
                cmnd.Parameters.Add("@numeroSerie", SqlDbType.VarChar, 100).Value = prd.SerieProducto;
                cmnd.Parameters.Add("@horas", SqlDbType.Int).Value = prd.Horas;
                cmnd.Parameters.Add("@peso", SqlDbType.VarChar, 255).Value = prd.Peso;
                cmnd.Parameters.Add("@medidas", SqlDbType.VarChar, 255).Value = prd.Medidas;
                cmnd.Parameters.Add("@observacion", SqlDbType.VarChar, 255).Value = prd.Observacion;
                cmnd.Parameters.Add("@cantidad", SqlDbType.Int).Value = prd.Cantidad;
                cmnd.Parameters.Add("@estado", SqlDbType.Int).Value = prd.idEstado;
                cmnd.Parameters.Add("@modifyMode", SqlDbType.Bit).Value = (modifyMode ? 1 : 0);
                cmnd.Parameters.Add("@dh", SqlDbType.Int).Value = prd.dh;
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

        public DataSet getHistorial(string codProducto)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerHistorialProducto", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@codProducto", SqlDbType.VarChar, 100).Value = codProducto;

                SqlDataAdapter adptr = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adptr.SelectCommand = cmnd;
                adptr.Fill(ds);
                conn.Close();

                return ds;
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

        public TipoProducto getTipoProducto(int idTipoProducto)
        {
            TipoProducto tp = null;
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerTipoProducto", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@idTipoProducto", SqlDbType.VarChar, 100).Value = idTipoProducto;

                SqlDataAdapter adptr = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adptr.SelectCommand = cmnd;
                adptr.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    tp = new TipoProducto();
                    DataRow dr = ds.Tables[0].Rows[0];

                    tp.Id = Convert.ToInt32(dr["id"]);
                    tp.tipo = dr["tipo"].ToString();
                    tp.exigeCantidad = (dr["exigeCantidad"].ToString() == "True");
                    tp.agruparEnReportes = (dr["agruparEnReporte"].ToString() == "True");

                }

                return tp;
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

        public DataTable getReporteProductosDisponibles()
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ReporteProductosDisponibles", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adptr.SelectCommand = cmnd;
                adptr.Fill(ds);
                conn.Close();

                return ds.Tables[0];
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

        public DataTable getReporteProductosEnUso()
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ReporteProductosEnUso", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adptr.SelectCommand = cmnd;
                adptr.Fill(ds);
                conn.Close();

                return ds.Tables[0];
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

        public DataTable getReporteProductosFueraServicio()
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ReporteProductosFueraServicio", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adptr.SelectCommand = cmnd;
                adptr.Fill(ds);
                conn.Close();

                return ds.Tables[0];
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

        public DataTable getReporteProductosEnReparacion()
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ReporteProductosEnReparacion", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adptr.SelectCommand = cmnd;
                adptr.Fill(ds);
                conn.Close();

                return ds.Tables[0];
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

        public void grabarDigitoHorizontal(string codigoProducto, int dh)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();
                String sql = String.Format("UPDATE Productos SET dh = {0} WHERE codigo = '{1}'", dh, codigoProducto);
                SqlCommand cmnd = new SqlCommand(sql, conn);
                cmnd.CommandType = CommandType.Text;
                
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

        public void grabarDigitoVerticalProductos(int DV)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();
                String sql = String.Format("UPDATE DigitoVertical SET valor = {0} WHERE entidad = 'productos'", DV);
                SqlCommand cmnd = new SqlCommand(sql, conn);
                cmnd.CommandType = CommandType.Text;

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

        public int getDigitoVertical()
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();
                String sql = String.Format("SELECT valor FROM DigitoVertical WHERE entidad = 'productos'");
                SqlCommand cmnd = new SqlCommand(sql, conn);
                cmnd.CommandType = CommandType.Text;
                return (Int32)cmnd.ExecuteScalar();
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
