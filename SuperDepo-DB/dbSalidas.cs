using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_SL;

namespace SuperDepo_DB
{
    public class dbSalida
    {
        #region Singleton dbSalida    
   
        private dbSalida() { }
        
        static dbSalida instance = null;

        public static dbSalida getInstance() 
        {
            if (instance == null)
                instance = new dbSalida();

            return instance;
        }
        #endregion

        public DataSet getSalidasAbiertas(String campo = "", String criterio = "")
        {
            DataSet dsSalidas = new DataSet();                
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerSalidasAbiertas", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                if (campo != "")
                {
                    cmnd.Parameters.Add("@campo", SqlDbType.VarChar, 25).Value = campo;
                    cmnd.Parameters.Add("@criterio", SqlDbType.VarChar, 30).Value = criterio;
                }

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                adptr.Fill(dsSalidas);                
                conn.Close();
                
                // Si trae datos es porque el login existe
                return dsSalidas;
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

        public Salida getSalida(int idSalida)
        {
            Salida _Salida = new Salida();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerSalida", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@idSalida", SqlDbType.Int).Value = idSalida;
                
                SqlDataAdapter adptr = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adptr.SelectCommand = cmnd;
                adptr.Fill(ds);
                conn.Close();

                // Si trae datos es porque la SALIDA existe
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    _Salida.Id = Convert.ToInt32(row["id"].ToString());
                    _Salida.Contacto = row["contactoSalida"].ToString();
                    _Salida.TelefonoSalida = row["telefonoSalida"].ToString();
                    _Salida.CelularSalida = row["celularSalida"].ToString();
                    _Salida.FechaArmado = row["fechaArmado"].ToString();
                    _Salida.FechaDesarme = row["fechaDesarme"].ToString();
                    _Salida.Observacion = row["observacion"].ToString();
                    _Salida.remitida = (row["remitida"].ToString() == "True");
                    // Cliente
                    Cliente cl = new Cliente();
                    cl.Id = Convert.ToInt32(row["idCliente"].ToString());
                    cl.CodigoPostal = row["codigoPostal"].ToString();
                    cl.Condicion = row["condicion"].ToString();
                    cl.Contacto = row["contactoCliente"].ToString();
                    cl.Cuil = row["cuil"].ToString();
                    cl.Direccion = row["direccion"].ToString();
                    cl.Email = row["emailCliente"].ToString();
                    cl.Localidad = row["localidad"].ToString();
                    cl.Nombre = row["nombreCliente"].ToString();
                    cl.Observaciones = row["observacionCliente"].ToString();
                    cl.telCelular = row["celularCliente"].ToString();
                    cl.telContacto = row["telefonoCliente"].ToString();
                    _Salida.Cliente = cl;
                    //Usuario
                    User usr = new User();
                    usr.Id = Convert.ToInt32(row["idUser"].ToString());
                    usr.LastName = row["lastName"].ToString();
                    usr.Name = row["name"].ToString();
                    usr.Password = row["password"].ToString();
                    usr.UserName = row["userName"].ToString();
                    usr.Dni = row["dni"].ToString();
                    usr.dh = (row["dhUser"].ToString() == "" ? 0 : Convert.ToInt32(row["dhUser"].ToString()));
                    _Salida.Usuario = usr;
                    //LugarEvento
                    LugarEvento le = new LugarEvento();
                    le.Id = Convert.ToInt32(row["idLugarEvento"].ToString());
                    le.Establecimiento = row["establecimiento"].ToString();
                    le.Direccion = row["direccionEstablecimiento"].ToString();
                    _Salida.lugarEvento = le;
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    _Salida.Items = new List<ItemSalida>();
                    foreach (DataRow rD in ds.Tables[1].Rows)
                    {
                        ItemSalida itemS = new ItemSalida();
                        itemS.Id = Convert.ToInt32(rD["id"].ToString());
                        itemS.IdSalida = Convert.ToInt32(rD["idSalida"].ToString());
                        itemS.Cantidad = Convert.ToInt32(rD["cantidad"].ToString());
                        itemS.Observacion = rD["Observacion"].ToString();
                        itemS.Return = Convert.ToBoolean(rD["Return"].ToString());

                        Producto prd = new Producto();
                        prd.CodigoProducto = rD["CodigoProducto"].ToString();
                        prd.IdTipoProducto = (rD["idTipoProducto"].ToString() == "" ? 0 : Convert.ToInt32(rD["idTipoProducto"]));
                        prd.TipoProducto = rD["TipoProducto"].ToString();
                        prd.TipoExigeCantidad = (rD["ExigeCantidad"].ToString() == "True");
                        prd.Descripcion = rD["Descripcion"].ToString();
                        prd.CategoriaProducto = rD["CategoriaProducto"].ToString();
                        prd.MarcaProducto = rD["MarcaProducto"].ToString();
                        prd.ModeloProducto = rD["ModeloProducto"].ToString();
                        prd.SerieProducto = rD["serieProducto"].ToString();
                        prd.Horas = (rD["Horas"].ToString() == "" ? 0 : Convert.ToInt32(rD["Horas"]));
                        prd.Peso = rD["Peso"].ToString();
                        prd.Medidas = rD["Medidas"].ToString();
                        prd.Observacion = rD["ObservacionProducto"].ToString();
                        prd.Cantidad = (rD["Cantidad"].ToString() == "" ? 0 : Convert.ToInt32(rD["Cantidad"]));
                        itemS.Producto = prd;

                        _Salida.Items.Add(itemS);                        
                    }
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    _Salida.Tecnicos = new List<Tecnico>();
                    foreach (DataRow rT in ds.Tables[2].Rows)
                    {
                        Tecnico tec = new Tecnico();
                        tec.Id = Convert.ToInt32(rT["Id"].ToString());
                        tec.Nombre = rT["Nombre"].ToString();
                        tec.Cargo = rT["Cargo"].ToString();
                        tec.Dni = rT["Dni"].ToString();
                        tec.Telefono = rT["Telefono"].ToString();
                        _Salida.Tecnicos.Add(tec);
                    }
                }
                return _Salida;
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

        public DataSet getSalidasVigentes(String campo = "", String criterio = "")
        {
            DataSet dsSalidas = new DataSet();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_obtenerSalidasVigentes", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                if (campo != "")
                {
                    cmnd.Parameters.Add("@campo", SqlDbType.VarChar, 25).Value = campo;
                    cmnd.Parameters.Add("@criterio", SqlDbType.VarChar, 30).Value = criterio;
                }
                
                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                adptr.Fill(dsSalidas);
                conn.Close();

                return dsSalidas;
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

        public Int32 Grabar(Salida Salida, bool actualizarDetalle = true)
        {
            int _Idsalida;
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    SqlCommand cmnd = new SqlCommand("sp_GuardarDatosSalida", conn);
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Transaction = tran;

                    cmnd.Parameters.Add("@id", SqlDbType.Int).Value = Salida.Id;
                    cmnd.Parameters.Add("@idCliente", SqlDbType.Int).Value = Salida.Cliente.Id;
                    cmnd.Parameters.Add("@contacto", SqlDbType.VarChar, 35).Value = Salida.Contacto;
                    cmnd.Parameters.Add("@celularSalida", SqlDbType.VarChar, 30).Value = Salida.CelularSalida;
                    cmnd.Parameters.Add("@telefonoSalida", SqlDbType.VarChar, 30).Value = Salida.TelefonoSalida;
                    cmnd.Parameters.Add("@idLugarEvento", SqlDbType.Int).Value = Salida.lugarEvento.Id;
                    cmnd.Parameters.Add("@fechaArmado", SqlDbType.DateTime).Value = Salida.FechaArmado;
                    cmnd.Parameters.Add("@fechaDesarme", SqlDbType.DateTime, 50).Value = Salida.FechaDesarme;
                    cmnd.Parameters.Add("@observaciones", SqlDbType.VarChar, 8000).Value = Salida.Observacion;
                    cmnd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = Salida.Usuario.Id;
                    cmnd.Parameters.Add("@remitida", SqlDbType.Bit).Value = Salida.remitida;

                    _Idsalida = Convert.ToInt32(cmnd.ExecuteScalar());

                    if (actualizarDetalle)
                    {
                        this.EliminarItemsSalida(conn, tran, _Idsalida);
                        this.EliminarTecnicosSalida(conn, tran, _Idsalida);

                        this.GrabarItemsSalida(conn, tran, _Idsalida, Salida.Items, Salida.Usuario.Id);
                        this.GrabarTecnicosSalida(conn, tran, _Idsalida, Salida.Tecnicos);
                    }
                    
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
                return _Idsalida;
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

        private void EliminarTecnicosSalida(SqlConnection conn, SqlTransaction tran, int _Idsalida)
        {
            SqlCommand cmnd = new SqlCommand("sp_EliminarTecnicosSalida", conn);
            cmnd.CommandType = CommandType.StoredProcedure;
            cmnd.Transaction = tran;

            cmnd.Parameters.Add("@idSalida", SqlDbType.Int).Value = _Idsalida;

            int lint = cmnd.ExecuteNonQuery(); 
        }

        private void EliminarItemsSalida(SqlConnection conn, SqlTransaction tran, int _Idsalida)
        {
            SqlCommand cmnd = new SqlCommand("sp_EliminarItemsSalida", conn);
            cmnd.CommandType = CommandType.StoredProcedure;
            cmnd.Transaction = tran;

            cmnd.Parameters.Add("@idSalida", SqlDbType.Int).Value = _Idsalida;

            int lint = cmnd.ExecuteNonQuery(); 
        }

        private void GrabarTecnicosSalida(SqlConnection conn, SqlTransaction tran, int _Idsalida, List<Tecnico> tecsSalida)
        {
            foreach (Tecnico tec in tecsSalida)
            {
                SqlCommand cmnd = new SqlCommand("sp_GuardarDatosTecnicoSalida", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Transaction = tran;
                
                cmnd.Parameters.Add("@idSalida", SqlDbType.Int).Value = _Idsalida;
                cmnd.Parameters.Add("@idTecnico", SqlDbType.Int).Value = tec.Id;
                
                int lint = cmnd.ExecuteNonQuery(); 
            }
            
        }

        private void GrabarItemsSalida(SqlConnection conn, SqlTransaction tran, int _Idsalida, List<ItemSalida> itemsSalida, int idUsuario)
        {
            foreach (ItemSalida item in itemsSalida)
            {
                SqlCommand cmnd = new SqlCommand("sp_GuardarDatosItemSalida", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Transaction = tran;

                cmnd.Parameters.Add("@idSalida", SqlDbType.Int).Value = _Idsalida;
                cmnd.Parameters.Add("@codigoProducto", SqlDbType.VarChar, 100).Value = item.Producto.CodigoProducto;
                cmnd.Parameters.Add("@cantidad", SqlDbType.Int).Value = item.Cantidad;
                cmnd.Parameters.Add("@idUser", SqlDbType.Int).Value = appGlobals.gUser.Id;
                cmnd.Parameters.Add("@Observacion", SqlDbType.VarChar, 255).Value = item.Observacion;
                cmnd.Parameters.Add("@return", SqlDbType.Bit).Value = item.Return;
                
                int lint = cmnd.ExecuteNonQuery(); 
            }            
        }

        public void EliminarSalida(int idSalida)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_eliminarSalida", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@idSalida", SqlDbType.Int).Value = idSalida;

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

        public DataTable getReporteSalidasVigentes()
        {
            DataSet dsSalidas = new DataSet();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ReporteSalidasVigentes", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                
                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                adptr.Fill(dsSalidas);
                conn.Close();

                return dsSalidas.Tables[0];
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

        public DataTable DatosRemito(Int32 idSalida, bool remitoLegal)
        {
            DataSet dsSalidas = new DataSet();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();
                
                SqlCommand cmnd;
                if (remitoLegal)
                    cmnd = new SqlCommand("sp_RemitoLegal", conn);
                else
                    cmnd = new SqlCommand("sp_RemitoDetallado", conn);

                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.Add("@idSalida", SqlDbType.Int).Value = idSalida;                    

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                adptr.Fill(dsSalidas);
                conn.Close();

                return dsSalidas.Tables[0];
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


        public object getReporteSalidasConEntrada()
        {
            DataSet dsSalidas = new DataSet();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ReporteSalidasConEntrada", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                adptr.Fill(dsSalidas);
                conn.Close();

                return dsSalidas.Tables[0];
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
