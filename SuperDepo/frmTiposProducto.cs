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
    public partial class frmTiposProducto : Form
    {
        List<TipoProducto> mlstTipos;

        public frmTiposProducto()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.cargarlistado();
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
                this.FiltrarListaTiposProducto(txtCriterio.Text);
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
                if (this.lstTiposPrd.SelectedItems.Count > 0)
                {
                    TipoProducto tp = (TipoProducto)this.lstTiposPrd.SelectedItems[0].Tag;
                    this.Datos2UI(tp);
                    this.enableEdicion(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }

        private void Datos2UI(TipoProducto tp)
        {
            grpDatos.Tag = tp.Id;
            this.txtTipoProducto.Text = tp.tipo;
            this.chkExigeCantidad.Checked = tp.exigeCantidad;
            this.chkAgrupar.Checked = tp.agruparEnReportes;
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
            this.txtTipoProducto.Text = "";
            this.chkExigeCantidad.Checked=false;
            this.chkAgrupar.Checked = false;
        }
        
        private void cargarlistado()
        {
            this.mlstTipos = new List<TipoProducto>();
            this.mlstTipos = tiposProductoManager.getInstance().listaTiposProductos();
            this.FiltrarListaTiposProducto(this.txtCriterio.Text);
        }

        private void FiltrarListaTiposProducto(string criterio)
        {
            if (criterio == "")
            {
                var qAll = from tp in mlstTipos
                           orderby tp.tipo
                           select tp;

                this.FillListaTiposProducto(qAll);
            }
            else
            {
                var qEst = from tp in mlstTipos
                           where (tp.tipo.ToLower().Contains(criterio.ToLower()))
                           orderby tp.tipo
                           select tp;

                this.FillListaTiposProducto(qEst);
            }
                
        }

        private void FillListaTiposProducto(IOrderedEnumerable<TipoProducto> q)
        {
            this.lstTiposPrd.Items.Clear();
            foreach (TipoProducto tp in q)
            {
                ListViewItem item = new ListViewItem();
                item.Text = tp.tipo;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (tp.exigeCantidad == true ? "Si" : "No")));
                item.Tag = tp;
                item.Selected = false;
                lstTiposPrd.Items.Add(item);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validarDatos())
                {
                    TipoProducto tp = this.UI2Datos();
                    tiposProductoManager.getInstance().GuardarDatos(tp);
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

        private TipoProducto UI2Datos()
        {
            TipoProducto tp = new TipoProducto();
            tp.Id = (this.grpDatos.Tag != null ? (Int32)this.grpDatos.Tag : 0);
            tp.tipo = this.txtTipoProducto.Text;
            tp.exigeCantidad = this.chkExigeCantidad.Checked;
            tp.agruparEnReportes = this.chkAgrupar.Checked;

            return tp;
        }

        private bool validarDatos()
        {
            bool result = true;

            if (this.txtTipoProducto.Text == "")
                result = false;
            
            return result;
        }

        private void lstTiposPrd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lstTiposPrd.SelectedItems.Count > 0)
                {
                    TipoProducto tp = (TipoProducto)this.lstTiposPrd.SelectedItems[0].Tag;
                    this.Datos2UI(tp);
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
