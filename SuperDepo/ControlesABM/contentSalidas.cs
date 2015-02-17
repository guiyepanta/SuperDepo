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
    public partial class contentSalidas : UserControl
    {
        public contentSalidas()
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
                this.cargarSalidasAbiertas(campo, criterio);
                this.cargarSalidasVigentes();
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        
        #region Motodos privados

        private void cargarSalidasVigentes()
        {
            try
            {
                DataSet dsSalidas = salidaManager.getInstance().getSalidasVigentes();

                lstSalidasVigentes.Items.Clear();

                if (dsSalidas.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dsSalidas.Tables[0].Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = row[1].ToString();
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, row[2].ToString()));
                        item.Tag = Convert.ToInt32(row[0].ToString());
                        item.Selected = false;
                        lstSalidasVigentes.Items.Add(item);
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarSalidasAbiertas(String campo = "", String criterio = "")
        {
            try
            {
                DataSet dsSalidas = salidaManager.getInstance().getSalidasAbiertas(campo, criterio);

                lstSalidas.Items.Clear();

                if (dsSalidas.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dsSalidas.Tables[0].Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = row[1].ToString();
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, row[2].ToString()));
                        item.Tag = Convert.ToInt32(row["id"].ToString());
                        item.Selected = false;
                        lstSalidas.Items.Add(item);
                    }
                }

                //Cambio el HeaderText de la columna
                if (dsSalidas.Tables[1].Rows.Count > 0)
                    lstSalidas.Columns[0].Text = dsSalidas.Tables[1].Rows[0][0].ToString();
                else
                    lstSalidas.Columns[0].Text = "Cliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void cargarSalida(int idSalida)
        {
            Salida sld = salidaManager.getInstance().getSalida(idSalida);
            grpSalida.Tag = sld;

            btnEliminar.Enabled = !sld.remitida;
            btnModificar.Enabled = !sld.remitida;

            this.txtCliente.Text = sld.Cliente.Nombre;
            this.txtContacto.Text = sld.Contacto;
            this.txtCelular.Text = sld.CelularSalida;
            this.txtTelefono.Text = sld.TelefonoSalida;
            this.txtLugarEvento.Text = sld.lugarEvento.Establecimiento;
            this.txtDireccion.Text = sld.lugarEvento.Direccion;
            this.txtFechaArmado.Text = Convert.ToDateTime(sld.FechaArmado).ToLongDateString();
            this.txtFechaDesarme.Text = Convert.ToDateTime(sld.FechaDesarme).ToLongDateString();
            this.lblNroSalida.Text = sld.Id.ToString();
            this.lblOwner.Text = sld.Usuario.LastName + ", " + sld.Usuario.Name;

            grdDetalleSalida.Rows.Clear();
            grdDetalleSalida.AutoGenerateColumns = false;
            if (sld.Items != null)
                foreach (ItemSalida item in sld.Items)
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
                    cellCant.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

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
                this.cargarSalidasAbiertas(cmbFilterField.Text, txtTextSearch.Text);
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void lstSalidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstSalidas.SelectedItems.Count > 0)
                {
                    int idSalida = (Int32)(lstSalidas.SelectedItems[0].Tag);
                    this.cargarSalida(idSalida);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        
        private void lstSalidasVigentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstSalidasVigentes.SelectedItems.Count > 0)
                {
                    int idSalida = (Int32)(lstSalidasVigentes.SelectedItems[0].Tag);
                    this.cargarSalida(idSalida);
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
                if (((Salida)(grpSalida.Tag)).remitida)
                {
                    if (MessageBox.Show("La Salida que intenta Imprimir ya fue Remitida\r\n¿Desea imprimir un borrardor de todas formas?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.ImprimirBorrador((Salida)(grpSalida.Tag));
                    }
                }
                else
                {
                    this.ImprimirRemito((Salida)(grpSalida.Tag));
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
                    int idSalida = ((Salida)(grpSalida.Tag)).Id;
                    salidaManager.getInstance().EliminarSalida(idSalida);
                    this.cargarSalidasAbiertas(this.cmbFilterField.Text, this.txtTextSearch.Text);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                ABMSalida nSalida = new ABMSalida();
                nSalida.Dock = DockStyle.Fill;
                nSalida.Parent = this.Parent;
                nSalida.BringToFront();
                ((Panel)this.Parent).Controls.Add(nSalida);
                ((Panel)this.Parent).Controls.Remove(this);
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ABMSalida mSalida = new ABMSalida();
                mSalida.IdSalida = ((Salida)grpSalida.Tag).Id;
                mSalida.Dock = DockStyle.Fill;
                mSalida.Parent = this.Parent;
                mSalida.BringToFront();
                ((Panel)this.Parent).Controls.Add(mSalida);
                ((Panel)this.Parent).Controls.Remove(this);
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
