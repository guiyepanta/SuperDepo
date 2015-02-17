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
    public partial class frmConciliacion : Form
    {
        #region Variables

        List<ItemReconciliacion> mListItems = new List<ItemReconciliacion>();

        #endregion

        public frmConciliacion()
        {
            InitializeComponent();           
        }

        #region Propiedades


        #endregion

        #region Eventos Controles

        private void frmConciliacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbCampoFiltro.SelectedIndex = 0;
                this.cmbAcciones.SelectedIndex = 0;
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
                this.FiltrarListaItems(this.cmbCampoFiltro.Text, this.txtCriterio.Text);
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

        private void btnConciliar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstItems.SelectedItems.Count > 0)
                {
                    this.grpDatos.Enabled = true;
                    this.DataToUI(this.lstItems.SelectedItems[0]);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lstItems.SelectedItems.Count > 0)
                {
                    this.DataToUI(this.lstItems.SelectedItems[0]);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.grpDatos.Enabled = false;
            if (this.lstItems.Items.Count > 0)
                this.lstItems.Items[0].Selected = true;
            else
                this.LimpiarCampos();
            this.grpListado.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbAcciones.Text != "" && this.cmbAcciones.Text != "Seleccionar Acción")
                {
                    ItemReconciliacion item = (ItemReconciliacion)this.grpDatos.Tag;
                    item.tipo = this.getTipoReconciliacion();
                    item.IdSalidaDestino = this.selSalidaDestino.EntityId;
                    entradaManager.getInstance().reconciliar(item);
                    this.cargarlistado();
                    this.btnCancelar.PerformClick();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una acción", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ItemReconciliacion.tiposReconciliacion getTipoReconciliacion()
        {
            if (cmbAcciones.Text == "Enviar a reparación")
            {
                return ItemReconciliacion.tiposReconciliacion.EnviarReparacion;
            }
            else if (cmbAcciones.Text == "Sacar de servicio")
            {
                return ItemReconciliacion.tiposReconciliacion.SacarDeServicio;
            }
            else if (cmbAcciones.Text == "Asignar nueva Salida")
            {
                return ItemReconciliacion.tiposReconciliacion.AsignarNuevaSalida;
            }
            return ItemReconciliacion.tiposReconciliacion.None;
        }
               
        #endregion   
     
        private void FiltrarListaItems(String campo, String criterio)
        {
            if (criterio == "" || criterio == "Descripción")
            {
                var qAll = from item in mListItems
                           orderby item.ItemSalida.Producto.Descripcion
                           select item;

                this.FillListaItems(qAll);
            }
            else
                if (campo == "Codigo")
                {
                    var qCod = from item in mListItems
                               where (item.ItemSalida.Producto.CodigoProducto.ToUpper().Contains(criterio.ToUpper()))
                               orderby item.ItemSalida.Producto.Descripcion
                               select item;

                    this.FillListaItems(qCod);
                }
                else
                {
                    var qDes = from item in mListItems
                               where (item.ItemSalida.Producto.TipoProducto.ToUpper().Contains(criterio.ToUpper()))
                               orderby item.ItemSalida.Producto.Descripcion
                               select item;

                    this.FillListaItems(qDes);
                }
        }

        private void FillListaItems(IOrderedEnumerable<ItemReconciliacion> q)
        {
            this.lstItems.Items.Clear();
            foreach (ItemReconciliacion ir in q)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ir.ItemSalida.Producto.CodigoProducto + " - " + ir.ItemSalida.Producto.TipoProducto;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ir.ItemSalida.Producto.Descripcion));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ir.Cantidad.ToString()));
                item.Tag = ir;
                item.Selected = false;                
                lstItems.Items.Add(item);
            }
        }

        private void cargarlistado()
        {
            mListItems = entradaManager.getInstance().getItemsReconciliacion();
            this.FiltrarListaItems(this.cmbCampoFiltro.Text, this.txtCriterio.Text);
        }

        private void DataToUI(ListViewItem lvItem)
        {
            ItemReconciliacion item = (ItemReconciliacion)lvItem.Tag;
            this.grpDatos.Tag = item;
            this.txtProducto.Text = item.ItemSalida.Producto.Descripcion;
            this.txtTipo.Text = item.ItemSalida.Producto.TipoProducto;
            this.txtSalida.Text = item.DescripcionSalidad;
            this.txtFechaEntrada.Text = item.FechaRegistro;
            this.txtObservaciones.Text = item.Observacion;

        }

        private void LimpiarCampos()
        {
            this.txtProducto.Text = "";
            this.txtSalida.Text = "";
            this.txtTipo.Text = "";
            this.txtFechaEntrada.Text = "";
            this.txtObservaciones.Text = "";
            this.selSalidaDestino.limpiarTodo();
        }

        private void cmbAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAcciones.Text != "Seleccionar Acción")
            {
                switch (cmbAcciones.Text)
	            {
                    case "Enviar a reparación":
                        this.selSalidaDestino.Enabled = false;
                        break;
                    case "Sacar de servicio":
                        this.selSalidaDestino.Enabled = false;
                        break;
                    case "Asignar nueva Salida":
                        this.selSalidaDestino.Enabled = true;
                        break;
                    default:
                        break;
	            }      
            }
        }
    }
}
