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

namespace User_Control
{
    public partial class SelectEntity : UserControl
    {
        public SelectEntity()
        {
            InitializeComponent();
        }

        private bool isExpand = false;
        public String EntityName { get; set; }
        public Int32 deltaWidth { get; set; }

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
            this.txtDescripcion.Tag = null;
            this.txtDescripcion.Text = "";
            limpiar();
        }

        private void limpiar()
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

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            ((DataView)dgvGrilla.DataSource).RowFilter = "Descripcion like '%" + txtFiltro.Text + "%'";
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.SelectedRows.Count > 0)
            {
                this.txtDescripcion.Tag = dgvGrilla.Rows[dgvGrilla.CurrentCellAddress.Y].Cells[0].Value.ToString();
                this.txtDescripcion.Text = dgvGrilla.Rows[dgvGrilla.CurrentCellAddress.Y].Cells[2].Value.ToString();
                limpiar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        #region Metodos Privados

        private void Consultar()
        {            
                System.Data.DataSet ds = new DataSet();
                ds = selectEntityManager.getInstance().getDatos(EntityName);
                dgvGrilla.DataSource = ds.Tables[0].DefaultView;
                ds.Dispose();            
        }

        private void FormatearGrilla()
        {
            dgvGrilla.Columns[0].Visible = false;
            dgvGrilla.Columns[1].HeaderText = "ID";
            dgvGrilla.Columns[2].HeaderText = "Descripción";
            dgvGrilla.Columns[1].Width = 50;
            dgvGrilla.Columns[2].Width = this.dgvGrilla.Width - 70;
        }
        #endregion        

    }
}
