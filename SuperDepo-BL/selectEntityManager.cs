using System;
using System.Collections.Generic;
using System.Text;
using SuperDepo_DB;

namespace SuperDepo_BL
{
    public class selectEntityManager
    {
        #region Singleton selectEntityManager       
        
        private selectEntityManager()
        { 
        }

        static selectEntityManager instance = null;

        public static selectEntityManager getInstance() 
        {
            if (instance == null)
                instance = new selectEntityManager();

            return instance;
        }
        #endregion

        public System.Data.DataSet getDatos(SuperDepo_CMM.appGlobals.EntityTipe EntityType)
        {
            try
            {
                return dbSelectEntity.getInstance().getDatos(EntityType);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
