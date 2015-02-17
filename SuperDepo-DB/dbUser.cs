using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_SL;

namespace SuperDepo_DB
{
    public class dbUser
    {
        #region Singleton UserManager    
   
        private dbUser() { }
        
        static dbUser instance = null;

        public static dbUser getInstance() 
        {
            if (instance == null)
                instance = new dbUser();

            return instance;
        }
        #endregion
        
        public User validaLogin(User usrlogin)
        {  
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ValidarUsuario", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                cmnd.Parameters.Add("@userName", SqlDbType.VarChar, 10).Value = usrlogin.UserName;
                cmnd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = usrlogin.Password;

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                DataSet ds = new DataSet();
                adptr.Fill(ds);                
                conn.Close();
                
                // Si trae datos es porque el login existe
                if (ds.Tables[0].Rows.Count > 0)
                {
                    User usr = new User();
                    DataRow row = ds.Tables[0].Rows[0];
                    usr.Id = Convert.ToInt32(row["Id"].ToString());
                    usr.Name = row["Name"].ToString();
                    usr.LastName = row["LastName"].ToString();
                    usr.UserName = row["UserName"].ToString();
                    usr.Password = row["Password"].ToString();
                    usr.Telefono = row["Telefono"].ToString();
                    usr.Dni = row["Dni"].ToString();
                    usr.dh = (row["Dh"].ToString() == "" ? 0 : Convert.ToInt32(row["Dh"]));

                    usr.Accesos = this.getAccesosAsignados(usr.Id);
                    
                    return usr;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public Users getUsers()
        {
            Users _lstUsers = new Users();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerUsuarios", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                DataSet ds = new DataSet();
                adptr.Fill(ds);                
                conn.Close();
                
                // Si trae datos es porque el login existe
                if (ds.Tables[0].Rows.Count > 0)
                {
                    _lstUsers.list = new List<User>();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        User usr = new User();

                        usr.Id = Convert.ToInt32(row["Id"].ToString());
                        usr.Name = row["Name"].ToString();
                        usr.LastName = row["LastName"].ToString();
                        usr.UserName = row["UserName"].ToString();
                        usr.Password = row["Password"].ToString();
                        usr.Dni = row["Dni"].ToString();
                        usr.Telefono = row["Telefono"].ToString();
                        usr.dh = (row["Dh"].ToString() == "" ? 0 : Convert.ToInt32(row["Dh"]));
                        _lstUsers.list.Add(usr);
                    }
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
            return _lstUsers;
        }

        public User getUsers(int idUser)
        {
            User usr = new User();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerUsuario", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                cmnd.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                DataSet ds = new DataSet();
                adptr.Fill(ds);
                conn.Close();

                // Si trae datos es porque el login existe
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    usr.Id = Convert.ToInt32(row["Id"].ToString());
                    usr.Name = row["Name"].ToString();
                    usr.LastName = row["LastName"].ToString();
                    usr.UserName = row["UserName"].ToString();
                    usr.Password = row["Password"].ToString();
                    usr.Dni = row["Dni"].ToString();
                    usr.Telefono = row["Telefono"].ToString();
                    usr.dh = (row["Dh"].ToString() == "" ? 0 : Convert.ToInt32(row["Dh"]));

                }
                return usr;
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

        public int GuardarDatos(User usr)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    SqlCommand cmnd = new SqlCommand("sp_GuardarDatosUsuario", conn);
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Transaction = tran;

                    cmnd.Parameters.Add("@id", SqlDbType.Int).Value = usr.Id;
                    cmnd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = usr.Name;
                    cmnd.Parameters.Add("@lastName", SqlDbType.VarChar, 30).Value = usr.LastName;
                    cmnd.Parameters.Add("@userName", SqlDbType.VarChar, 10).Value = usr.UserName;
                    cmnd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = usr.Password;
                    cmnd.Parameters.Add("@telefono", SqlDbType.VarChar, 25).Value = usr.Telefono;
                    cmnd.Parameters.Add("@dni", SqlDbType.VarChar, 8).Value = usr.Dni;
                    cmnd.Parameters.Add("@dh", SqlDbType.Int).Value = usr.dh;

                    usr.Id = Convert.ToInt32(cmnd.ExecuteScalar());

                    this.EliminarAccesosAmodulos(conn, tran, usr.Id);
                    this.GuardarAccesosAmodulos(conn, tran, usr.Id, usr.Accesos);
                    
                    tran.Commit();

                    return usr.Id;
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

        private void GuardarAccesosAmodulos(SqlConnection conn, SqlTransaction tran, Int32 IdUser, List<Modulo> list)
        {
            foreach (Modulo mod in list)
            {
                SqlCommand cmnd = new SqlCommand("sp_GuardarAccesosAmodulos", conn);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Transaction = tran;

                cmnd.Parameters.Add("@idUser", SqlDbType.Int).Value = IdUser;
                cmnd.Parameters.Add("@idModulo", SqlDbType.Int).Value = mod.Id;
                
                int lint = cmnd.ExecuteNonQuery();
            } 
        }

        private void EliminarAccesosAmodulos(SqlConnection conn, SqlTransaction tran, int idUser)
        {
            SqlCommand cmnd = new SqlCommand("sp_EliminarAccesosAmodulos", conn);
            cmnd.CommandType = CommandType.StoredProcedure;
            cmnd.Transaction = tran;

            cmnd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUser;

            int lint = cmnd.ExecuteNonQuery(); 
        }

        public List<Modulo> getAccesosAsignados(int idUser)
        {
            List<Modulo> lstMod = new List<Modulo>();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerAccesosUsuario", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                cmnd.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                DataSet ds = new DataSet();
                adptr.Fill(ds);
                conn.Close();

                // Si trae datos es porque el login existe
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Modulo mod = new Modulo();
                        mod.Id = Convert.ToInt32(row["Id"].ToString());
                        mod._Modulo = row["Modulo"].ToString();

                        lstMod.Add(mod);   
                    }                    
                }
                return lstMod;
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

        public List<Modulo> getModulos()
        {
            List<Modulo> lstMod = new List<Modulo>();
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_ObtenerModulos", conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;

                DataSet ds = new DataSet();
                adptr.Fill(ds);
                conn.Close();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Modulo mod = new Modulo();
                    mod.Id = Convert.ToInt32(row["Id"].ToString());
                    mod._Modulo = row["Modulo"].ToString();

                    lstMod.Add(mod);
                }
                return lstMod;
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

        public void grabarDigitoHorizontal(int idUser, int dh)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();
                String sql = String.Format("UPDATE Usuario SET dh = {0} WHERE id = {1}", dh, idUser);
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

        public void grabarDigitoVerticalUsuarios(int DV)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());
            try
            {
                conn.Open();
                String sql = String.Format("UPDATE DigitoVertical SET valor = {0} WHERE entidad = 'usuarios'", DV);
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
                String sql = String.Format("SELECT valor FROM DigitoVertical WHERE entidad = 'usuarios'");
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
