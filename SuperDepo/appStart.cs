using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperDepo_BL;
using SuperDepo_CMM;
using System.IO;

namespace SuperDepo
{
    public partial class appStart : Form
    {
        bool flag = true;
                
        public appStart()
        {
            InitializeComponent();
        }

        private void appStart_Load(object sender, EventArgs e)
        {
            lblAppName.Text = appGlobals.appName;
            lblVersion.Text = appGlobals.appVersion;
            lblData.Text = "System scanning\r\n" + "...";
        }

        public bool systemScan()
        {
            lblData.Text = "System scanning\r\n" + "Verificando Conexion Base de datos...";
            lblData.Refresh();
            if (!appManager.getInstance().VerificarConexion())
            {
                return false;
            }

            lblData.Text = "System scanning\r\n" + "Verificando Integridad datos de Usuarios...";
            lblData.Refresh();
            if (!verificarIntegridadUsuarios())
            {
                return false;
            }

            lblData.Text = "System scanning\r\n" + "Verificando Integridad datos de Productos...";
            lblData.Refresh();
            if (!verificarIntegridadProductos())
            {
                return false;
            }

            if (!VerficarFolderLogs())
            {
                return false;
            }

            return true;
        }

        private bool VerficarFolderLogs()
        {
            try 
	        {	        
		        String ruta = "c:\\SuperDepo\\Logs";

                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                return true;
	        }
	        catch (Exception)
	        {		
		        return false;
	        }           
        }

        private bool verificarIntegridadProductos()
        {
            Int32 digitoVertical = 0;
            Int32 SumDigitoHorizontal = 0;
            List<Producto> prds = productoManager.getInstance().getAllProductos();
            foreach (Producto p in prds)
            {
                SumDigitoHorizontal += p.dh;
            }

            digitoVertical = productoManager.getInstance().getDigitoVertical();

            return (digitoVertical == SumDigitoHorizontal);
        }

        private bool verificarIntegridadUsuarios()
        {
            Int32 digitoVertical = 0;
            Int32 SumDigitoHorizontal = 0;
            Users usrs = userManager.getInstance().GetUsers();
            foreach (User u in usrs.list)
            {
                SumDigitoHorizontal += u.dh;   
            }

            digitoVertical = userManager.getInstance().getDigitoVertical();

            return (digitoVertical == SumDigitoHorizontal);
        }
    }
}
