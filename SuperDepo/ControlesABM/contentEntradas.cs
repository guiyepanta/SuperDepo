using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SuperDepo_CMM;
using SuperDepo_BL;
using SuperDepo_SL;

namespace SuperDepo.ControlesABM
{
    public partial class contentEntradas : UserControl
    {
        public contentEntradas()
        {
            InitializeComponent();
        }

        private void contentSalidas_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbFilterField.SelectedIndex = 0;
                String campo = cmbFilterField.Text;
                String criterio = txtTextSearch.Text;
                this.cargarEntradasEnConfeccion(campo, criterio);
                this.cargarEntradasCerradas();
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        
        #region Motodos privados

        private void cargarEntradasCerradas()
        {
            DataSet dsEntradas = entradaManager.getInstance().getEntradasCerradas();

            lstOrdenesCerradas.Items.Clear();

            if (dsEntradas.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsEntradas.Tables[0].Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = row[1].ToString();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, row[2].ToString()));
                    item.Tag = Convert.ToInt32(row["id"].ToString());
                    item.Selected = false;
                    lstOrdenesCerradas.Items.Add(item);
                }
            }
        }
        private void cargarEntradasEnConfeccion(String campo = "", String criterio = "")
        {
            DataSet dsEntradas = entradaManager.getInstance().getEntradasAbiertas(campo, criterio);

            lstEntradas.Items.Clear();

            if (dsEntradas.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsEntradas.Tables[0].Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = row[1].ToString();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, row[2].ToString()));
                    item.Tag = Convert.ToInt32(row["id"].ToString());
                    item.Selected = false;
                    lstEntradas.Items.Add(item);
                }
            }

            //Cambio el HeaderText de la columna
            if (dsEntradas.Tables[1].Rows.Count > 0)
                lstEntradas.Columns[0].Text = dsEntradas.Tables[1].Rows[0][0].ToString();
            else
                lstEntradas.Columns[0].Text = "Cliente";          
        }

        private void cargarEntrada(int idEntrada)
        {
            Entrada ent = entradaManager.getInstance().getEntrada(idEntrada);
            this.grpEntrada.Tag = ent;

            btnEliminar.Enabled = !ent.Cerrada;
            btnModificar.Enabled = !ent.Cerrada;

            this.txtCliente.Text = ent.Cliente.Nombre;
            this.txtContacto.Text = ent.Salida.Contacto;
            this.txtCelular.Text = ent.Salida.CelularSalida;
            this.txtTelefono.Text = ent.Salida.TelefonoSalida;
            this.txtLugarEvento.Text = ent.Salida.lugarEvento.Establecimiento;
            this.txtDireccion.Text = ent.Salida.lugarEvento.Direccion;
            this.txtFechaArmado.Text = ent.Salida.FechaArmado;
            this.txtFechaDesarme.Text = ent.Salida.FechaDesarme;
            this.lblNroSalida.Text = ent.Salida.Id.ToString();
            this.lblOwner.Text = ent.Usuario.LastName + ", " + ent.Usuario.Name;

            grdDetalleSalida.Rows.Clear();
            grdDetalleSalida.AutoGenerateColumns = false;
            if (ent.Salida.Items != null)
                foreach (ItemSalida item in ent.Items)
                {
                     
                    DataGridViewRow dgRow = new DataGridViewRow();
                    DataGridViewCell cellId = new DataGridViewTextBoxCell();
                    DataGridViewCell cellCod = new DataGridViewTextBoxCell();
                    DataGridViewCell cellTipo = new DataGridViewTextBoxCell();
                    DataGridViewCell cellDesc = new DataGridViewTextBoxCell();
                    DataGridViewCell cellMarca = new DataGridViewTextBoxCell();
                    DataGridViewCell cellModelo = new DataGridViewTextBoxCell();
                    DataGridViewCell cellSerie = new DataGridViewTextBoxCell();
                    DataGridViewCell cellCant = new DataGridViewTextBoxCell();

                    cellId.Value = item.Id;
                    cellCod.Value = item.Producto.CodigoProducto;
                    cellTipo.Value = item.Producto.TipoProducto;
                    cellDesc.Value = item.Producto.Descripcion;
                    cellMarca.Value = item.Producto.MarcaProducto;
                    cellModelo.Value = item.Producto.ModeloProducto;
                    cellSerie.Value = item.Producto.SerieProducto;
                    cellCant.Value = item.Cantidad;

                    dgRow.Cells.Add(cellId);
                    dgRow.Cells.Add(cellCod);
                    dgRow.Cells.Add(cellTipo);
                    dgRow.Cells.Add(cellDesc);
                    dgRow.Cells.Add(cellMarca);
                    dgRow.Cells.Add(cellModelo);
                    dgRow.Cells.Add(cellSerie);
                    dgRow.Cells.Add(cellCant);

                    grdDetalleSalida.Rows.Add(dgRow);
                }
            
        }

        private void ImprimirBorrador(Salida salida)
        {
            throw new NotImplementedException();
        }

        private void ImprimirRemito(Salida salida)
        {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Eventos Controles

        private void txtTextSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.cargarEntradasEnConfeccion(cmbFilterField.Text, txtTextSearch.Text);
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void lstEntradas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstEntradas.SelectedItems.Count > 0)
                {

                    this.btnEliminar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnNuevo.Enabled = true;
                    this.btnModificar.Enabled = true;

                    int idEntrada = (Int32)(lstEntradas.SelectedItems[0].Tag);
                    this.cargarEntrada(idEntrada);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        
               
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (((Salida)(grpEntrada.Tag)).remitida)
                {
                    if (MessageBox.Show("La Salida que intenta Imprimir ya fue Remitida\r\n¿Desea imprimir un borrardor de todas formas?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.ImprimirBorrador((Salida)(grpEntrada.Tag));
                    }
                }
                else
                {
                    this.ImprimirRemito((Salida)(grpEntrada.Tag));
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro de Eliminar la Salida seleccionada?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    salidaManager.getInstance().EliminarSalida(((Salida)(grpEntrada.Tag)).Id);
                    this.cargarEntradasEnConfeccion(this.cmbFilterField.Text, this.txtTextSearch.Text);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.grpEntrada.Tag != null)
            {
                desingEntrada dEntreda = new desingEntrada((Entrada)this.grpEntrada.Tag);
                dEntreda.Dock = DockStyle.Fill;
                dEntreda.Parent = this.Parent;
                dEntreda.BringToFront();
                ((Panel)this.Parent).Controls.Add(dEntreda);
                ((Panel)this.Parent).Controls.Remove(this);                 
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            desingEntrada dEntreda = new desingEntrada();
            dEntreda.Dock = DockStyle.Fill;
            dEntreda.Parent = this.Parent;
            dEntreda.BringToFront();
            ((Panel)this.Parent).Controls.Add(dEntreda);
            ((Panel)this.Parent).Controls.Remove(this);
        }

        private void lstOrdenesCerradas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstOrdenesCerradas.SelectedItems.Count > 0)
                {
                    this.btnEliminar.Enabled = false;
                    this.btnModificar.Enabled = false;
                    int idEntrada = (Int32)(lstOrdenesCerradas.SelectedItems[0].Tag);
                    this.cargarEntrada(idEntrada);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion             
    }
}
