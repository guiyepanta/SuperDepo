using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperDepo_CMM;
using SuperDepo_BL;
using SuperDepo_SL;

namespace SuperDepo.ControlesUsuario
{
    public partial class SelectEntity : UserControl
    {
        #region Evento Custom

        public delegate void EntityIdEventHandler();
        public event EntityIdEventHandler EntityIdChanged;
        private void RaiseEntityIdChanged()
        {
            if (EntityIdChanged != null)
                EntityIdChanged();
        }

        #endregion
        
        private bool isExpand = false;
        bool _ShowBotonNew;

        public SelectEntity()
        {
            InitializeComponent();            
        }

        #region Propiedades      
        
        public appGlobals.EntityTipe EntityType { get; set; }
        public Int32 deltaWidth { get; set; }
        public int EntityId { get; set; }
        public bool ShowBotonNew
        {
            get { return _ShowBotonNew; }
            set 
            {
                _ShowBotonNew = value;
                if (!_ShowBotonNew)
                {
                    btnNew.Visible = false;
                    txtDescripcion.Width = btnBuscar.Left + btnBuscar.Width;
                    btnBuscar.Left = btnLimp.Left;
                    btnLimp.Left = btnNew.Left;
                }
                else
                {
                    btnNew.Visible = true;
                    btnNew.Left = this.Width - btnNew.Width;
                    btnLimp.Left = btnNew.Left - btnLimp.Width - 1;
                    btnBuscar.Left = btnLimp.Left - btnBuscar.Width - 1;
                    txtDescripcion.Width = btnBuscar.Left -2;
                }
            }
        }
        public int AssignEntity { set { this.assignEntitytoControl(value); } }
        public Color DescriptionBackColor { get { return this.txtDescripcion.BackColor; } set { this.txtDescripcion.BackColor = value; } }
        
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isExpand)
                {
                    isExpand = true;
                    this.Consultar();
                    this.Height = 200;
                    this.Width += this.deltaWidth;
                    this.FormatearGrilla();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;                
            }
        }

        private void btnLimp_Click(object sender, EventArgs e)
        {
            limpiarTodo();
            RaiseEntityIdChanged();
        }

        private void Limpiar()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (isExpand)
                {
                    isExpand = false;
                    this.Height = this.pnlSelect.Height;
                    this.txtFiltro.Text = "";
                    this.Width -= this.deltaWidth;
                    this.FormatearGrilla();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void limpiarTodo()
        {
            this.txtDescripcion.Tag = null;
            this.txtDescripcion.Text = "";
            this.Limpiar();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            ((DataView)dgvGrilla.DataSource).RowFilter = "Descripcion like '%" + txtFiltro.Text + "%'";
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.SelectedRows.Count > 0 && dgvGrilla.CurrentCellAddress.Y >= 0)
            {
                this.EntityId = Convert.ToInt32(dgvGrilla.Rows[dgvGrilla.CurrentCellAddress.Y].Cells[0].Value.ToString());
                this.txtDescripcion.Text = dgvGrilla.Rows[dgvGrilla.CurrentCellAddress.Y].Cells[2].Value.ToString();
                Limpiar();
                RaiseEntityIdChanged();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            switch (this.EntityType)
            {
                case appGlobals.EntityTipe.Clientes:
                    frmClientes frmCl = new frmClientes();
                    frmCl.StartPosition = FormStartPosition.CenterScreen;
                    frmCl.ShowDialog();
                    frmCl.Dispose();
                    break;
                case appGlobals.EntityTipe.LugaresEvento:
                    frmLugaresEvento frmLe = new frmLugaresEvento();
                    frmLe.StartPosition = FormStartPosition.CenterScreen;
                    frmLe.ShowDialog();
                    frmLe.Dispose();
                    break;
                case appGlobals.EntityTipe.Productos:
                    break;
                case appGlobals.EntityTipe.Tecnicos:
                    break;
                case appGlobals.EntityTipe.Usuarios:
                    break;
                case appGlobals.EntityTipe.Salida:
                    break;
                default:
                    break;
            }
        }

        private void dgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.SelectedRows.Count > 0)
            {
                this.EntityId = Convert.ToInt32(dgvGrilla.Rows[dgvGrilla.CurrentCellAddress.Y].Cells[0].Value.ToString());
                this.txtDescripcion.Text = dgvGrilla.Rows[dgvGrilla.CurrentCellAddress.Y].Cells[2].Value.ToString();
                Limpiar();
                RaiseEntityIdChanged();
            }
        }

        #region Metodos Privados

        private void assignEntitytoControl(int value)
        {
            switch (this.EntityType)
            {
                case appGlobals.EntityTipe.Clientes:
                    Cliente cl = clienteManager.getInstance().getCliente(value);
                    this.EntityId = cl.Id;
                    this.txtDescripcion.Text = cl.Nombre;
                    break;
                case appGlobals.EntityTipe.LugaresEvento:
                    LugarEvento le = lugaresEventoManager.getInstance().getLugarEvento(value);
                    this.EntityId = le.Id;
                    this.txtDescripcion.Text = le.Establecimiento;
                    break;
                case appGlobals.EntityTipe.Productos:
                    break;
                case appGlobals.EntityTipe.Tecnicos:
                    break;
                case appGlobals.EntityTipe.Usuarios:
                    break;
                case appGlobals.EntityTipe.TiposProducto:
                    TipoProducto tp = productoManager.getInstance().getTipoProducto(value);
                    this.EntityId = tp.Id;
                    this.txtDescripcion.Text = tp.tipo;
                    break;
                case appGlobals.EntityTipe.Salida:
                case appGlobals.EntityTipe.SalidaNoAsignada:
                    Salida s = salidaManager.getInstance().getSalida(value);
                    this.EntityId = s.Id;
                    this.txtDescripcion.Text = s.lugarEvento.Establecimiento;
                    break;
                default:
                    break;
            }
            RaiseEntityIdChanged();
        }

        private void Consultar()
        {            
                System.Data.DataSet ds = new DataSet();
                ds = selectEntityManager.getInstance().getDatos(EntityType);
                dgvGrilla.DataSource = ds.Tables[0].DefaultView;
                ds.Dispose();            
        }

        private void FormatearGrilla()
        {
            dgvGrilla.Columns[0].Visible = false;
            dgvGrilla.Columns[1].HeaderText = "Código";
            dgvGrilla.Columns[2].HeaderText = "Descripción";
            dgvGrilla.Columns[1].Width = 50;
            dgvGrilla.Columns[2].Width = this.dgvGrilla.Width - 70;
        }
        #endregion        
    }
}
