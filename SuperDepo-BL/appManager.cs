using System;
using System.Collections.Generic;
using System.Text;
using SuperDepo_CMM;
using SuperDepo_DB;
using System.Configuration;

namespace SuperDepo_BL
{
    public class appManager
    {
        #region Singleton UserManager       
        
        private appManager()
        { 
        }

        static appManager instance = null;

        public static appManager getInstance() 
        {
            if (instance == null)
                instance = new appManager();

            return instance;
        }
        #endregion

        public bool VerificarConexion()
        {
            return Conexion.getInstance().Verificar();
        }

        public void setModuleVersionFromAssemblyDescription()
        {
            String assemblyDescription = System.Reflection.Assembly.GetEntryAssembly().FullName;

            appGlobals.appName = assemblyDescription.Split(Convert.ToChar(","))[0].ToString().Replace("=", ": ");
            appGlobals.appVersion = assemblyDescription.Split(Convert.ToChar(","))[1].ToString().Replace("=", ": ");
            appGlobals.appServer = ConfigurationManager.AppSettings["Server"].ToString();
            appGlobals.appReportFolder = ConfigurationManager.AppSettings["ReportFolder"].ToString();
        }

        public Dictionary<Int32, String> getSystemEstate()
        {
            Dictionary<Int32, String> SystemState = new Dictionary<int, string>();
            SystemState.Add(1, "Activo");
            SystemState.Add(0, "Inactivo");

            return SystemState;
        }
    }
}
