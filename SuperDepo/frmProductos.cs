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
    public partial class frmProductos : Form
    {
        List<Producto> mlstProductos;
        bool mModifyMode = false;
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbCampoFiltro.SelectedIndex = 0;
                this.cargarlistado();
                this.cargarEstados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }

        private void cargarEstados()
        {
            DataSet dsEstados = productoManager.getInstance().getEstadosProducto();
            this.cmbEstado.DataSource = dsEstados.Tables[0];
            this.cmbEstado.DisplayMember = "detalle";
            this.cmbEstado.ValueMember = "id";
            this.cmbEstado.SelectedIndex = 0;
        }

        private void txtCriterio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.FiltrarListaProductos(this.cmbCampoFiltro.Text, this.txtCriterio.Text);
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
                    productoManager.getInstance().elimimarProducto(this.txtCodigo.Text);
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
                if (this.lstProductos.SelectedItems.Count > 0)
                {
                    mModifyMode = true;
                    Producto prd = (Producto)this.lstProductos.SelectedItems[0].Tag;
                    this.Datos2UI(prd);
                    this.enableEdicion(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            mModifyMode = false;
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
            this.cmbEstado.SelectedIndex = 0;
            this.tabProducto.SelectedIndex = 0;
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
            this.selTipoPrd.limpiarTodo();
            this.txtCantidad.Text = "";
            this.txtMarca.Text = "";
            this.txtModelo.Text = "";
            this.txtNroSerie.Text = "";
            this.txtPeso.Text = "";
            this.txtHoras.Text = "";
            this.txtMedidas.Text = "";
            this.txtCantidad.Text = "";
            this.txtObservacion.Text = "";
            this.grdHistorial.DataSource = null;
            this.grdHistorial.Refresh();
        }

        #region Metodos Privados

        private void cargarlistado()
        {
            mlstProductos = new List<Producto>();
            mlstProductos = productoManager.getInstance().getAllProductos();
            this.FiltrarListaProductos(this.cmbCampoFiltro.Text, this.txtCriterio.Text);
        }

        private void FiltrarListaProductos(String campo, String criterio)
        {
            if (criterio == "")
            {
                var qAll = from p in mlstProductos
                           orderby p.Descripcion
                           select p;

                this.FillListaProductos(qAll);
            }
            else
                if (campo == "Codigo")
                {
                    var qCod = from p in mlstProductos
                               where (p.CodigoProducto.ToUpper().Contains(criterio.ToUpper()))
                               orderby p.Descripcion
                               select p;

                    this.FillListaProductos(qCod);
                }
                else
                {
                    var qDes = from p in mlstProductos
                               where (p.Descripcion.ToUpper().Contains(criterio.ToUpper()))
                               orderby p.Descripcion
                               select p;

                    this.FillListaProductos(qDes);
                }
        }

        private void FillListaProductos(IOrderedEnumerable<Producto> q)
        {
            this.lstProductos.Items.Clear();
            foreach (Producto pr in q)
            {
                ListViewItem item = new ListViewItem();
                item.Text = pr.CodigoProducto;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, pr.Descripcion));
                item.Tag = pr;
                item.Selected = false;
                if (pr.idEstado == 2)
                    item.ForeColor = Color.Blue;
                else if (pr.idEstado == 3)
                    item.ForeColor = Color.Red;
                lstProductos.Items.Add(item);
            }
        }   

        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validarDatos())
                {
                    Producto prd = this.UI2Datos();
                    productoManager.getInstance().GuardarDatos(prd, mModifyMode);
                    this.cargarlistado();
                    this.LimpiarTodo();
                    this.grpDatos.Enabled = false;
                    this.cargarlistado();
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

        private Producto UI2Datos()
        {
            Producto prd = new Producto();

            prd.CodigoProducto = this.txtCodigo.Text;
            prd.Descripcion = this.txtDescripcion.Text;
            prd.IdTipoProducto = this.selTipoPrd.EntityId;
            prd.CategoriaProducto = this.txtCategoria.Text;
            prd.MarcaProducto = this.txtMarca.Text;
            prd.ModeloProducto = this.txtModelo.Text;
            prd.SerieProducto = this.txtNroSerie.Text;
            prd.Peso = this.txtPeso.Text;
            prd.Horas = (this.txtHoras.Text == "" ? 0 : Convert.ToInt32(this.txtHoras.Text));
            prd.Medidas = this.txtMedidas.Text;
            prd.Cantidad = (this.txtCantidad.Text == "" ? 0 : Convert.ToInt32(this.txtCantidad.Text));
            prd.Observacion = this.txtObservacion.Text;
            prd.idEstado = Convert.ToInt32(this.cmbEstado.SelectedValue);

            return prd;
        }

        private bool validarDatos()
        {
            if (this.txtCodigo.Text == "")
                return false;
            if (!mModifyMode && !productoManager.getInstance().validarCodigoProducto(this.txtCodigo.Text))
                return false;
            if (this.selTipoPrd.EntityId == 0)
                return false;

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarTodo();
            this.enableEdicion(false);
        }

        private void lstProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lstProductos.SelectedItems.Count > 0)
                {
                    Producto p = (Producto)this.lstProductos.SelectedItems[0].Tag;
                    this.Datos2UI(p);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }

        private void Datos2UI(Producto prd)
        {            
            this.txtCodigo.Text = prd.CodigoProducto;
            this.txtDescripcion.Text = prd.Descripcion;
            this.selTipoPrd.AssignEntity = prd.IdTipoProducto;
            this.txtCantidad.Text = prd.CategoriaProducto;
            this.txtMarca.Text = prd.MarcaProducto;
            this.txtModelo.Text = prd.ModeloProducto;
            this.txtNroSerie.Text = prd.SerieProducto;
            this.txtPeso.Text = prd.Peso;
            this.txtHoras.Text = prd.Horas.ToString();
            this.txtMedidas.Text = prd.Medidas;
            this.txtCantidad.Text = prd.Cantidad.ToString();
            this.txtObservacion.Text = prd.Observacion;
            this.cmbEstado.SelectedValue = prd.idEstado;
        }

        private void cargarHistorialProducto()
        {
            if (grdHistorial.Rows.Count <= 0)
            {
                DataSet dsHistory = productoManager.getInstance().getHistorial(this.txtCodigo.Text);
                grdHistorial.DataSource = dsHistory.Tables[0];
   
            }
        }

        private void tabProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabProducto.SelectedTab.Name == "tabHistorial")
                {
                    this.cargarHistorialProducto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
               
        }    
    }
}
