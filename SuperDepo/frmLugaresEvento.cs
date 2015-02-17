using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperDepo_CMM;
using SuperDepo_BL;
using SuperDepo_SL;

namespace SuperDepo
{
    public partial class frmLugaresEvento : Form
    {
        List<LugarEvento> mlstLugares;
        public frmLugaresEvento()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.cargarlistado();
                this.cargarEstados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }

        private void txtCriterio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.FiltrarListaLugares(txtCriterio.Text);
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el Producto seleccionado?", "Atencion!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                    lugaresEventoManager.getInstance().elimimarLugarEvento(Convert.ToInt32(grpDatos.Tag));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstLugares.SelectedItems.Count > 0)
                {
                    LugarEvento l = (LugarEvento)this.lstLugares.SelectedItems[0].Tag;
                    this.Datos2UI(l);
                    this.enableEdicion(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }

        private void Datos2UI(LugarEvento l)
        {
            grpDatos.Tag = l.Id;
            this.txtEstablecimiento.Text = l.Establecimiento;
            this.txtDireccion.Text = l.Direccion;
            this.cmbEstado.SelectedValue = l.Estado;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.LimpiarTodo();
            this.enableEdicion(true);
        }

        private void enableEdicion(bool enable)
        {
            this.grpListado.Enabled = !enable;
            this.grpDatos.Enabled = enable;
        }

        private void LimpiarTodo()
        {
            this.grpDatos.Tag = null;
            this.txtEstablecimiento.Text = "";
            this.txtDireccion.Text = "";
            this.cmbEstado.SelectedIndex = 0;
        }
        
        private void cargarlistado()
        {
            this.mlstLugares = new List<LugarEvento>();
            this.mlstLugares = lugaresEventoManager.getInstance().listaLugaresEnvento();
            this.FiltrarListaLugares(this.txtCriterio.Text);
        }

        private void cargarEstados()
        {
            cmbEstado.DataSource = new BindingSource(appManager.getInstance().getSystemEstate(), null);
            cmbEstado.DisplayMember = "Value";
            cmbEstado.ValueMember = "Key";
        }

        private void FiltrarListaLugares(string criterio)
        {
            if (criterio == "")
            {
                var qAll = from l in mlstLugares
                           orderby l.Establecimiento
                           select l;

                this.FillListaLugares(qAll);
            }
            else
            {
                var qEst = from l in mlstLugares
                           where (l.Establecimiento.ToLower().Contains(criterio.ToLower()))
                           orderby l.Establecimiento
                           select l;

                this.FillListaLugares(qEst);
            }
                
        }

        private void FillListaLugares(IOrderedEnumerable<LugarEvento> q)
        {
            this.lstLugares.Items.Clear();
            foreach (LugarEvento l in q)
            {
                ListViewItem item = new ListViewItem();
                item.Text = l.Establecimiento;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, l.Direccion));
                item.Tag = l;
                item.Selected = false;
                if (l.Estado == 0)
                    item.ForeColor = Color.Red;
                lstLugares.Items.Add(item);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validarDatos())
                {
                    LugarEvento l = this.UI2Datos();
                    lugaresEventoManager.getInstance().GuardarDatos(l);
                    this.cargarlistado();
                    this.LimpiarTodo();
                    this.grpDatos.Enabled = false;
                    this.grpListado.Enabled = true;
                }
                else
                    MessageBox.Show("Error:\r\n" + "Debe completar los campos resaltados", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }

        private LugarEvento UI2Datos()
        {
            LugarEvento l = new LugarEvento();
            l.Id = (this.grpDatos.Tag != null ? (Int32)this.grpDatos.Tag : 0);
            l.Establecimiento = this.txtEstablecimiento.Text;
            l.Direccion = this.txtDireccion.Text;
            l.Estado = Convert.ToInt32(this.cmbEstado.SelectedValue);

            return l;
        }

        private bool validarDatos()
        {
            bool result = true;

            if (this.txtEstablecimiento.Text == "")
                result = false;
            
            return result;
        }

        private void lstLugares_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lstLugares.SelectedItems.Count > 0)
                {
                    LugarEvento l = (LugarEvento)this.lstLugares.SelectedItems[0].Tag;
                    this.Datos2UI(l);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarTodo();
            this.enableEdicion(false);
        }
    }
}
