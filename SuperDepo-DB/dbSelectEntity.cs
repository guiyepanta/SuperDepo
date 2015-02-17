using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_SL;

namespace SuperDepo_DB
{
    public class dbSelectEntity
    {
        #region Singleton dbSelectEntity

        private dbSelectEntity() { }
        
        static dbSelectEntity instance = null;

        public static dbSelectEntity getInstance() 
        {
            if (instance == null)
                instance = new dbSelectEntity();

            return instance;
        }
        #endregion

        public DataSet getDatos(SuperDepo_CMM.appGlobals.EntityTipe EntityType)
        {
            SqlConnection conn = new SqlConnection(Conexion.getInstance().conectionString());

            try
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("sp_Datos" + appGlobals.getEntityName(EntityType), conn);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adptr = new SqlDataAdapter();
                adptr.SelectCommand = cmnd;
                
                DataSet ds = new DataSet();
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
    }
}
