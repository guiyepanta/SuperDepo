using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_SL;

namespace SuperDepo_DB
{
    public class dbEntrada
    {
        #region Singleton dbEntrada

        private dbEntrada() { }

        static dbEntrada instance = null;

        public static dbEntrada getInstance() 
        {
            if (instance == null)
                instance = new dbEntrada();

            return instance;
        }

        #endregion
        
        public Entrada getEntrada(int idEntrada)
        {
            Entrada ent = new Entrada();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerEntrada", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@idEntrada", SqlDbType.Int).Value = idEntrada;
                
                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                conn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];

                    ent.Id = Convert.ToInt32(row["id"]);
                    ent.Salida = new Salida();
                    ent.Salida.Id = Convert.ToInt32(row["idSalida"]);
                    ent.Cliente = new Cliente();
                    ent.Cliente.Id = Convert.ToInt32(row["idCliente"]);
                    ent.Observacion = row["Observaciones"].ToString();
                    ent.FechaEntrada = row["fecha"].ToString();
                    ent.Usuario = new User();
                    ent.Usuario.Id = Convert.ToInt32(row["idUsuario"]);
                    ent.Cerrada = (row["cerrada"].ToString() == "True");
                }

                return ent;
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

        public DataSet getEntradasAbiertas(string campo, string criterio)
        {
            DataSet dsEntradas = new DataSet();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerEntradasAbiertas", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                if (campo != "")
                {
                    cmnd.Parameters.Add("@campo", SqlDbType.VarChar, 25).Value = campo;
                    cmnd.Parameters.Add("@criterio", SqlDbType.VarChar, 30).Value = criterio;
                }

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                adptr.Fill(dsEntradas);
                conn.Close();

                return dsEntradas;
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

        public DataSet getEntradasCerradas()
        {
            DataSet dsEntradas = new DataSet();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerEntradasCerradas", conn);
                cmnd.CommandType = CommandType.StoredProcedure;                

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                adptr.Fill(dsEntradas);
                conn.Close();

                return dsEntradas;
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

        public int grabar(Entrada ent)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlCommand cmnd = new SqlCommand("sp_GuardarDatosEntrada", conn);
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Transaction = tran;

                    cmnd.Parameters.Add("@id", SqlDbType.Int).Value = ent.Id;
                    cmnd.Parameters.Add("@idSalida", SqlDbType.Int).Value = ent.Salida.Id;
                    cmnd.Parameters.Add("@idCliente", SqlDbType.Int).Value = ent.Cliente.Id;
                    cmnd.Parameters.Add("@observaciones", SqlDbType.VarChar, 8000).Value = ent.Observacion;
                    cmnd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = ent.Usuario.Id;
                    cmnd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = DateTime.Now;
                    if (ent.Cerrada)
                        cmnd.Parameters.Add("@cerrada", SqlDbType.Int).Value = 1;
                    else
                        cmnd.Parameters.Add("@cerrada", SqlDbType.Int).Value = 0;

                    ent.Id = Convert.ToInt32(cmnd.ExecuteScalar());

                    this.EliminarItemsEntrada(conn, tran, ent);
                    this.GrabarItemsEntrada(conn, tran, ent);

                    this.EliminarTecnicosEntrada(conn, tran, ent.Id);
                    this.GrabarTecnicosEntrada(conn, tran, ent.Id, ent.Tecnicos);
                    
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
                return ent.Id;
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

        private void GrabarTecnicosEntrada(SqlConnection conn, SqlTransaction tran, int idEntrada, List<Tecnico> lstTecnicos)
        {
            foreach (Tecnico tec in lstTecnicos)
            {
                SqlCommand cmnd = new SqlCommand("sp_GuardarDatosTecnicoEntrada", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Transaction = tran;

                cmnd.Parameters.Add("@idEntrada", SqlDbType.Int).Value = idEntrada;
                cmnd.Parameters.Add("@idTecnico", SqlDbType.Int).Value = tec.Id;

                int lint = cmnd.ExecuteNonQuery();
            }
        }

        private void EliminarTecnicosEntrada(SqlConnection conn, SqlTransaction tran, int idEntrada)
        {
            SqlCommand cmnd = new SqlCommand("sp_EliminarTecnicosEntrada", conn);
            cmnd.CommandType = CommandType.StoredProcedure;
            cmnd.Transaction = tran;

            cmnd.Parameters.Add("@idEntrada", SqlDbType.Int).Value = idEntrada;

            int lint = cmnd.ExecuteNonQuery();
        }

        private void GrabarItemsEntrada(SqlConnection conn, SqlTransaction tran, Entrada currentEntrada)
        {
            foreach (ItemSalida item in currentEntrada.Items)
            {
                SqlCommand cmnd = new SqlCommand("sp_GuardarDatosItemEntrada", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Transaction = tran;

                cmnd.Parameters.Add("@idEntrada", SqlDbType.Int).Value = currentEntrada.Id;
                cmnd.Parameters.Add("@idSalida", SqlDbType.Int).Value = currentEntrada.Salida.Id;
                cmnd.Parameters.Add("@idItemSalida", SqlDbType.Int).Value = item.Id;
                cmnd.Parameters.Add("@codigoProducto", SqlDbType.VarChar, 100).Value = item.Producto.CodigoProducto;
                cmnd.Parameters.Add("@cantidad", SqlDbType.Int).Value = item.Cantidad;
                cmnd.Parameters.Add("@idUser", SqlDbType.Int).Value = appGlobals.gUser.Id;
                if (currentEntrada.Cerrada)
                    cmnd.Parameters.Add("@cerrada", SqlDbType.Int).Value = 1;
                else
                    cmnd.Parameters.Add("@cerrada", SqlDbType.Int).Value = 0;

                int lint = cmnd.ExecuteNonQuery();
            }    
        }

        private void EliminarItemsEntrada(SqlConnection conn, SqlTransaction tran, Entrada currentEntrada)
        {
            SqlCommand cmnd = new SqlCommand("sp_EliminarItemsEntrada", conn);
            cmnd.CommandType = CommandType.StoredProcedure;
            cmnd.Transaction = tran;

            cmnd.Parameters.Add("@idEntrada", SqlDbType.Int).Value = currentEntrada.Id;
            cmnd.Parameters.Add("@cerrada", SqlDbType.Bit).Value = currentEntrada.Cerrada;

            int lint = cmnd.ExecuteNonQuery(); 
        }

        public void AddReconciliacion(List<ItemReconciliacion> lstItems, int idEntrada)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    foreach (ItemReconciliacion item in lstItems)
                    {
                        SqlCommand cmnd = new SqlCommand("sp_GuardarDatosReconciliacion", conn);
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Transaction = tran;

                        cmnd.Parameters.Add("@IdItemSalida", SqlDbType.Int).Value = item.IdEntrada;
                        cmnd.Parameters.Add("@IdEntrada", SqlDbType.Int).Value = idEntrada;
                        cmnd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
                        cmnd.Parameters.Add("@Consolidado", SqlDbType.Bit).Value = false;
                        cmnd.Parameters.Add("@cantidad", SqlDbType.Int).Value = item.Cantidad;
                        cmnd.Parameters.Add("@IdUser", SqlDbType.Int).Value = appGlobals.gUser.Id;
                        cmnd.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = item.Observacion;

                        int lint = cmnd.ExecuteNonQuery();
                        cmnd.Dispose();
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
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

        public List<ItemSalida> getItemsEntrada(int idEntrada)
        {
            DataSet dsItems = new DataSet();
            List<ItemSalida> list = new List<ItemSalida>();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerItemsEntrada", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@idEntrada", SqlDbType.Int).Value = idEntrada;
                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                adptr.Fill(dsItems);
                conn.Close();

                foreach (DataRow row in dsItems.Tables[0].Rows)
                {
                    ItemSalida item = new ItemSalida();

                    item.Id = Convert.ToInt32(row["id"].ToString());
                    item.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                    item.Observacion = row["Observacion"].ToString();
                    item.Return = Convert.ToBoolean(row["Return"].ToString());

                    Producto prd = new Producto();
                    prd.CodigoProducto = row["CodigoProducto"].ToString();
                    prd.IdTipoProducto = (row["idTipoProducto"].ToString() == "" ? 0 : Convert.ToInt32(row["idTipoProducto"]));
                    prd.TipoProducto = row["TipoProducto"].ToString();
                    prd.TipoExigeCantidad = (row["ExigeCantidad"].ToString() == "True");
                    prd.Descripcion = row["Descripcion"].ToString();
                    prd.CategoriaProducto = row["CategoriaProducto"].ToString();
                    prd.MarcaProducto = row["MarcaProducto"].ToString();
                    prd.ModeloProducto = row["ModeloProducto"].ToString();
                    prd.SerieProducto = row["serieProducto"].ToString();
                    prd.Horas = (row["Horas"].ToString() == "" ? 0 : Convert.ToInt32(row["Horas"]));
                    prd.Peso = row["Peso"].ToString();
                    prd.Medidas = row["Medidas"].ToString();
                    prd.Observacion = row["ObservacionProducto"].ToString();
                    prd.Cantidad = (row["Cantidad"].ToString() == "" ? 0 : Convert.ToInt32(row["Cantidad"]));
                    item.Producto = prd;

                    list.Add(item);
                }

                return list;
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
        
        public void terminar(int idEntrada)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_cerrarEntrada", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@idEntrada", SqlDbType.Int).Value = idEntrada;

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

        public List<ItemReconciliacion> getItemsReconciliacion()
        {
            List<ItemReconciliacion> items = new List<ItemReconciliacion>();
            DataSet dsItems = new DataSet();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();
                SqlCommand cmnd = new SqlCommand("sp_ObtenerItemsReconciliacion", conn);
                cmnd.CommandType = CommandType.StoredProcedure;             

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                adptr.Fill(dsItems);
                conn.Close();

                foreach (DataRow row in dsItems.Tables[0].Rows)
                {
                    ItemReconciliacion ir = new ItemReconciliacion();
                    ir.Id = Convert.ToInt32(row["id"].ToString());
                    ir.IdEntrada = Convert.ToInt32(row["idEntrada"].ToString());
                    ir.IdUser = Convert.ToInt32(row["IdUser"].ToString());
                    ir.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());                    
                    ir.Consolidado = (row["Consolidado"].ToString() == "True");
                    ir.FechaRegistro = row["FechaRegistro"].ToString();
                    ir.Observacion = row["Observacion"].ToString();
                    ir.DescripcionSalidad = row["descripcionSalida"].ToString();

                    ItemSalida isa = new ItemSalida();
                    isa.Id = Convert.ToInt32(row["idItemSalida"].ToString());
                    isa.IdSalida = Convert.ToInt32(row["idSalida"].ToString());
                    isa.Cantidad = Convert.ToInt32(row["CantidadItemSalida"].ToString());
                    isa.Observacion = row["ObservacionItemSalida"].ToString();
                    isa.Return = Convert.ToBoolean(row["Return"].ToString());

                    Producto prd = new Producto();
                    prd.CodigoProducto = row["CodigoProducto"].ToString();
                    prd.IdTipoProducto = (row["idTipoProducto"].ToString() == "" ? 0 : Convert.ToInt32(row["idTipoProducto"]));
                    prd.TipoProducto = row["TipoProducto"].ToString();
                    prd.TipoExigeCantidad = (row["ExigeCantidad"].ToString() == "True");
                    prd.Descripcion = row["Descripcion"].ToString();
                    prd.CategoriaProducto = row["CategoriaProducto"].ToString();
                    prd.MarcaProducto = row["MarcaProducto"].ToString();
                    prd.ModeloProducto = row["ModeloProducto"].ToString();
                    prd.SerieProducto = row["serieProducto"].ToString();
                    prd.Horas = (row["Horas"].ToString() == "" ? 0 : Convert.ToInt32(row["Horas"]));
                    prd.Peso = row["Peso"].ToString();
                    prd.Medidas = row["Medidas"].ToString();
                    prd.Observacion = row["ObservacionProducto"].ToString();
                    prd.Cantidad = (row["CantidadProducto"].ToString() == "" ? 0 : Convert.ToInt32(row["Cantidad"]));
                    isa.Producto = prd;

                    ir.ItemSalida =isa;
                    items.Add(ir);
                }
                return items;
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

        public void reconciliar(ItemReconciliacion item)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlCommand cmnd = new SqlCommand("sp_ReconciliarItem", conn);
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Transaction = tran;

                    cmnd.Parameters.Add("@idReconciliacion", SqlDbType.Int).Value = item.Id;
                    cmnd.Parameters.Add("@idSalidaDestino", SqlDbType.Int).Value = item.IdSalidaDestino;
                    cmnd.Parameters.Add("@codigoProducto", SqlDbType.VarChar, 100).Value = item.ItemSalida.Producto.CodigoProducto;
                    cmnd.Parameters.Add("@cantidadReconciliacion", SqlDbType.Int).Value = item.Cantidad;
                    cmnd.Parameters.Add("@idUser", SqlDbType.Int).Value = appGlobals.gUser.Id;
                    cmnd.Parameters.Add("@tipoReconciliacion", SqlDbType.VarChar, 20).Value = item.tipo;
                    cmnd.ExecuteScalar();                   

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }                
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
