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
    public partial class frmAddReconciliacion : Form
    {
        private List<ItemSalida> mItems;
        private Int32 mIdEntrada;

        public frmAddReconciliacion(List<ItemSalida> Items, Int32 IdEntrada)
        {
            InitializeComponent();
            mItems = Items;
            mIdEntrada = IdEntrada;
        }

        private void frmAddReconciliacion_Load(object sender, EventArgs e)
        {
            if (mItems != null)
            {
                this.CargarItemsSalida();
            }
        }

        private void CargarItemsSalida()
        {
            foreach (ItemSalida item in mItems)
            {
                DataGridViewRow dgRow = new DataGridViewRow();
                DataGridViewCell cellCod = new DataGridViewTextBoxCell();
                DataGridViewCell cellProductoDesc = new DataGridViewTextBoxCell();
                DataGridViewCell cellCant = new DataGridViewTextBoxCell();
                DataGridViewCell cellObse = new DataGridViewTextBoxCell();

                cellCod.Tag = item;
                cellCod.Value = item.Producto.CodigoProducto;
                cellProductoDesc.Value = item.Producto.Descripcion;
                cellCant.Value = item.Cantidad;
                cellObse.ReadOnly = false;


                cellCod.Style.BackColor = Color.Gainsboro;
                cellProductoDesc.Style.BackColor = Color.Gainsboro;
                cellCant.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                cellCant.Style.BackColor = Color.Gainsboro;

                dgRow.Cells.Add(cellCod);
                dgRow.Cells.Add(cellProductoDesc);
                dgRow.Cells.Add(cellCant);
                dgRow.Cells.Add(cellObse);

                grdReconciliacion.Rows.Add(dgRow);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarConsolidacion())
                {
                    List<ItemReconciliacion> lstItem = new List<ItemReconciliacion>();
                    foreach (DataGridViewRow row in this.grdReconciliacion.Rows)
                    {
                        ItemReconciliacion item = new ItemReconciliacion();
                        item.IdEntrada = ((ItemSalida)row.Cells[0].Tag).Id;
                        item.Cantidad = Convert.ToInt32 (row.Cells[2].Value.ToString());
                        item.Observacion = row.Cells[3].Value.ToString();
                        item.Consolidado = false;
                        item.FechaRegistro = DateTime.Now.ToLongDateString();
                        lstItem.Add(item);
                    }

                    entradaManager.getInstance().AddReconciliacion(lstItem, mIdEntrada);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe ingresar una observación en todos los items!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarConsolidacion()
        {
            foreach (DataGridViewRow row in this.grdReconciliacion.Rows)
            {
                if (row.Cells[3].Value == null)
                    return false;
            }
            return true;
        }
    }
}
