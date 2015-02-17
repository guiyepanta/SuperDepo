using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SuperDepo_CMM;
using SuperDepo_BL;
using SuperDepo_SL;

namespace SuperDepo
{
    public partial class mdiStart : Form
    {
        public mdiStart()
        {
            InitializeComponent();
        }

        private void mdiStart_Load(object sender, EventArgs e)
        {
            this.Inicializar();
        }

        private void Inicializar()
        {
            try
            {
                appStart Start = new appStart();
                frmLogin Login = new frmLogin();
                Start.MdiParent = this;

                initializeSystem();
                Start.BringToFront();
                Start.Show();
                if (Start.systemScan())
                {
                    Start.Close();
                    Login.BringToFront();
                    if (Login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.ChequearAccesos();
                        sbUser.Text = appGlobals.gUser.LastName + ", " + appGlobals.gUser.Name;
                        sbServer.Text = appGlobals.appServer;
                        mnuIngreso.Text = "Salir";
                    }
                }
                else
                    MessageBox.Show("El sistema fue adulterado.\r\nComuniquese con el administrador", "Atencion...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChequearAccesos()
        {
            foreach (Modulo  mod in appGlobals.gUser.Accesos)
            {
                this.HabilitarAccesos(mod._Modulo);
            }
        }

        private void HabilitarAccesos(String Modulo)
        {
            mnuUsuarios.Enabled = true;

            switch (Modulo)
            {
                case "ABM Salidas":
                    mnuSalidas.Enabled = true;
                    btnSalidas.Enabled = true;
                    break;
                case "ABM Entradas":
                    mnuEntradas.Enabled = true;
                    btnEntradas.Enabled = true;
                    break;
                case "ABM Clientes":
                    mnuClientes.Enabled = true;
                    break;
                case "ABM Producos":
                    mnuProductos.Enabled = true;
                    break;
                case "ABM Lugares Eventos":
                    mnuLugares.Enabled = true;
                    break;
                case "ABM Tecnicos":
                    mnuTecnicos.Enabled = true;
                    break;
                case "Consolidar":
                    btnconsolidar.Enabled = true;
                    break;
                case "Informes":
                    btnInformes.Enabled = true;
                    break;                    
                default:
                    break;
            }
        }

        private void initializeSystem()
        {
            appManager.getInstance().setModuleVersionFromAssemblyDescription();           
        }

        public void CargarContent(String contentName)
        {
            this.pnlContent.Controls.Clear();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                switch (contentName)
                {
                    case "ContentSalidas":
                        ControlesABM.contentSalidas contSalidas = new ControlesABM.contentSalidas();
                        contSalidas.Dock = DockStyle.Fill;
                        contSalidas.Parent = this.pnlContent;
                        this.pnlContent.Controls.Add(contSalidas);
                        break;
                    case "ContentEntradas":
                        ControlesABM.contentEntradas contEntradas = new ControlesABM.contentEntradas();
                        contEntradas.Dock = DockStyle.Fill;
                        contEntradas.Parent = this.pnlContent;
                        this.pnlContent.Controls.Add(contEntradas);
                        break;
                    case "ContentInformes":
                        ControlesABM.contentInformes contInformes = new ControlesABM.contentInformes();
                        contInformes.Dock = DockStyle.Fill;
                        contInformes.Parent = this.pnlContent;
                        this.pnlContent.Controls.Add(contInformes);
                        break;
                    case "ContentConsolidar":
                        frmConciliacion frmCons = new frmConciliacion();
                        frmCons.StartPosition = FormStartPosition.CenterScreen;
                        frmCons.ShowInTaskbar = false;
                        frmCons.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error\r\n{0} {1}", ex.Message, ex.StackTrace), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
            
        private void btnSalidas_Click(object sender, EventArgs e)
        {
            CargarContent("ContentSalidas");
        }        

        private void mnuClientes_Click(object sender, EventArgs e)
        {
            frmClientes frmCl = new frmClientes();
            frmCl.StartPosition = FormStartPosition.CenterScreen;
            frmCl.ShowDialog();
            frmCl.Dispose();
        }

        private void mnuLugares_Click(object sender, EventArgs e)
        {
            frmLugaresEvento frmLe = new frmLugaresEvento();
            frmLe.StartPosition = FormStartPosition.CenterScreen;
            frmLe.ShowDialog();
            frmLe.Dispose();
        }

        private void mnuSalidas_Click(object sender, EventArgs e)
        {
            CargarContent("ContentSalidas");
        }

        private void mnuEntradas_Click(object sender, EventArgs e)
        {
            CargarContent("ContentEntradas");
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            CargarContent("ContentEntradas");
        }

        private void mnuProductos_Click(object sender, EventArgs e)
        {
            frmProductos frmPrd = new frmProductos();
            frmPrd.ShowInTaskbar = false;
            frmPrd.ShowDialog();
            frmPrd.Dispose();
        }

        private void mnuTecnicos_Click(object sender, EventArgs e)
        {
            frmTecnicos frmTec = new frmTecnicos();
            frmTec.ShowInTaskbar = false;
            frmTec.ShowDialog();
            frmTec.Dispose();
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            CargarContent("ContentInformes");
        }

        private void btnconsolidar_Click(object sender, EventArgs e)
        {
            CargarContent("ContentConsolidar");
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frmU = new frmUsuarios();
            frmU.StartPosition = FormStartPosition.CenterScreen;
            frmU.ShowInTaskbar = false;
            frmU.ShowDialog();
            frmU.Dispose();
        }

        private void mnuIngreso_Click(object sender, EventArgs e)
        {
            if (mnuIngreso.Text == "Salir") { this.Close(); }
            else { this.Inicializar(); }
        }

        private void mnuTiposProducto_Click(object sender, EventArgs e)
        {
            frmTiposProducto frmTp = new frmTiposProducto();
            frmTp.StartPosition = FormStartPosition.CenterScreen;
            frmTp.ShowInTaskbar = false;
            frmTp.ShowDialog();
            frmTp.Dispose();
        }
    }
}
