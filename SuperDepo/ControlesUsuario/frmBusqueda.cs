using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SuperDepo.ControlesUsuario
{
    public partial class frmBusqueda : Form
    {
        string mstrTabla = "";
        string mstrCmd = "";
               
        public frmBusqueda()
        {
            InitializeComponent();
        }

        private string mstrParaProc;
        public string ParametrosWhere
        {
            get { return mstrParaProc; }
            set { mstrParaProc = value; }
        }


        private string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string  Descripcion;
        public string  pDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        private string  Codigo;
        public string  pCodigo
        {
            get { return Codigo; }
            set { Codigo = value; }
        }

        private string Tabla;
        public string pTabla
        {
            get { return Tabla; }
            set { Tabla = value; }
        }

        private string  pCampoBusq;

        public string  CampoBusqueda
        {
            get { return pCampoBusq; }
            set { pCampoBusq = value; }
        }

        private string pCampoID;

        public string CampoID
        {
            get { return pCampoID; }
            set { pCampoID = value; }
        }
        
        private string pCampoCod;

        public string CampoCodigo
        {
            get { return pCampoCod; }
            set { pCampoCod = value; }
        }

        private string pCampoDesc;

        public string CampoDescrip
        {
            get { return pCampoDesc; }
            set { pCampoDesc = value; }
        }
	
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (_ID != "" && _ID != null)
            {  
                _ID = dgvGrilla.Rows[dgvGrilla.CurrentCellAddress.Y].Cells[0].Value.ToString();
                this.pCodigo = dgvGrilla.Rows[dgvGrilla.CurrentCellAddress.Y].Cells[1].Value.ToString();
                this.pDescripcion = dgvGrilla.Rows[dgvGrilla.CurrentCellAddress.Y].Cells[2].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvGrilla_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _ID = dgvGrilla[0, e.RowIndex].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void dgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (_ID != "")
                {
                    _ID = dgvGrilla[0, e.RowIndex].Value.ToString();
                    this.pCodigo = dgvGrilla[1, e.RowIndex].Value.ToString();
                    this.pDescripcion = dgvGrilla[2, e.RowIndex].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void dgvGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _ID = dgvGrilla[0, e.RowIndex].Value.ToString();
            }
        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _ID = dgvGrilla[0, e.RowIndex].Value.ToString();    
            }
            
        }

        private void frm_Load(object sender, EventArgs e)
        {
            mstrTabla = this.Tabla;
            mConsultar(mstrTabla);
            mFormatearGrilla();
        }

        private void mConsultar(string pstrTabla)
        {
            this.Cursor = Cursors.WaitCursor;
            System.Data.DataSet ds = new DataSet();

            mstrCmd = "Select " + pCampoID + "," + pCampoCod + "," + pCampoDesc + " From " + pstrTabla;
            if (mstrParaProc != null) mstrCmd += " Where " + mstrParaProc;

            ds = null;//TODO clsAccess.gExecuteQuery(mstrConn, mstrCmd);
            dgvGrilla.DataSource = ds.Tables[0].DefaultView;
            ds.Dispose();
            
            this.Cursor = Cursors.Default;
        }

        private void mFormatearGrilla()
        {
            dgvGrilla.Columns[0].Visible = false;
            dgvGrilla.Columns[1].HeaderText = "Nro.";
            dgvGrilla.Columns[2].HeaderText = "Descripción";
            dgvGrilla.Columns[1].Width = 60;
            dgvGrilla.Columns[2].Width = 345;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            ((DataView)dgvGrilla.DataSource).RowFilter = pCampoBusq + " like '%" + txtFiltro.Text + "%'";
            
        }
    }
}