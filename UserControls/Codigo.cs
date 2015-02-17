using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace UserControls
{
    public partial class Codigo : UserControl
    {
        public delegate void CodigoEventHandler();

        public event CodigoEventHandler CodigoChanged;        

        #region Propiedades
        
        private string _ConnectionString;
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        private string _ID;
        public string ID
        {
            get { return _ID; }
            set
            {
                _ID = value;

                if( _ID != "" )
                    this.gConsultar();
            }
        }

        private Boolean mbooFocus;
        public Boolean setFocus
        {
            get{ return mbooFocus;}
            set
            {
                mbooFocus = value;
                if (value)
                    txtCodigo.Focus();
            }
        }	

        private string _Codi;
        public string Codi
        {
            get {return _Codi; }
           set {
               _Codi = value;
               if (_Codi != "")
               {
                OjectInfo objBusq = BuscarObjeto(_Codi);
                if (objBusq != null)
                {
                    this.txtCodigo.Text = objBusq.Codigo;
                    this._ID = objBusq.ID;
                    this.txtDescripcion.Text = objBusq.Descripcion;
                    mRaiseCodigoChanged(false);
                }
               }
               }
        }

        public string Descripcion
        {
            get { return txtDescripcion.Text; }
        }

        private string _Tabla;
        public string Tabla_Consulta
        {
            get { return _Tabla; }
            set { _Tabla = value; }
        }

        private string mstrParaProc;
        public string ParametrosWhere
        {
            get { return mstrParaProc; }
            set { mstrParaProc = value; }
        }

        private string pCampoBusq;

        public string CampoBusqueda
        {
            get { return pCampoBusq; }
            set { pCampoBusq = value; }
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

        private string pCampoID;

        public string CampoID
        {
            get { return pCampoID; }
            set { pCampoID = value; }
        }
        #endregion	
        
        public Codigo()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            _ID = "";
        }

        private void Codigo_Resize(object sender, EventArgs e)
        {
            try
            {
                int sep1 = 3;
                int sep2 = 2;
                int sep3 = 2;

                txtDescripcion.Left = txtCodigo.Width + sep1 + btnBuscar.Width + sep2 + sep3 + btnLimp.Width;
                btnBuscar.Left = txtCodigo.Width + sep1;
                btnLimp.Left = txtCodigo.Width + sep1 + sep2 + btnBuscar.Width;
                txtDescripcion.Width = (this.Width - txtDescripcion.Left)-1;
                if( this.Width < 200 ) this.Width = 200;
                this.Height = 24;
            }
            catch
            {
            }
        }

        public int CodigoWidth
        {
            get { return txtCodigo.Width; }
            set 
            { 
                try
                {
                    txtCodigo.Width = value;
                    btnBuscar.Left = txtCodigo.Width + 2;
                    txtDescripcion.Left = txtCodigo.Width + 27;
                    txtDescripcion.Width = this.Width - ( txtCodigo.Width + 28 );
                }
                catch
                {
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBusqueda ofrm = new frmBusqueda();
            ofrm.pTabla = this._Tabla;
            ofrm.ParametrosWhere = mstrParaProc;
            ofrm.CampoBusqueda = pCampoBusq;
            ofrm.CampoID = pCampoID;
            ofrm.CampoCodigo = pCampoCod;
            ofrm.CampoDescrip = pCampoDesc;
            if (ofrm.ShowDialog() == DialogResult.OK)
            {
                this._ID = ofrm.ID;
                this.txtDescripcion.Text = ofrm.pDescripcion;
                this.txtCodigo.Text = ofrm.pCodigo;
                mRaiseCodigoChanged(true);
            }
            
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (txtCodigo.Text != "")
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    OjectInfo objBusq = BuscarObjeto(txtCodigo.Text);
                    if (objBusq == null)
                    {
                        frmBusqueda ofrm = new frmBusqueda();
                        ofrm.ParametrosWhere = mstrParaProc;
                        ofrm.CampoBusqueda = pCampoBusq;
                        ofrm.pTabla = this._Tabla;
                        ofrm.CampoID = pCampoID;
                        ofrm.CampoDescrip = pCampoDesc;
                        ofrm.CampoCodigo = pCampoCod;
                        if (ofrm.ShowDialog() == DialogResult.OK)
                        {
                            this._ID = ofrm.ID;
                            this.txtDescripcion.Text = ofrm.pDescripcion;
                            this.txtCodigo.Text = ofrm.pCodigo;
                            //mRaiseCodigoChanged();
                        }
                        else
                        {
                            this._ID = null;
                        }
                    }
                    else //encontró el objeto
                    {
                        this.txtCodigo.Text = objBusq.Codigo;
                        this._ID = objBusq.ID;
                        this._Codi = objBusq.Codigo;
                        this.txtDescripcion.Text = objBusq.Descripcion;
                        //mRaiseCodigoChanged();
                    }
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        e.Handled = true;
                        SendKeys.Send("{TAB}");
                    }
                }               
                
            }            
            else
            { 
                txtDescripcion.Text = ""; 
            }
        }

        public void gConsultar()
        {
            try
            {
                if (_Tabla == null)
                    return;

                this.Cursor = Cursors.WaitCursor;
                System.Data.DataSet ds = new DataSet();

                string lstrCmd = "Select " + pCampoID + "," + pCampoCod + "," + pCampoDesc + " From " + _Tabla;
                string lstrWhere = "";
                if (_ID !="")
                    lstrWhere = " where " + pCampoID + "=" + _ID;
                if (lstrWhere != "")
                {
                    lstrCmd += lstrWhere;
                    if (mstrParaProc != null && mstrParaProc != "") lstrCmd += " and " + mstrParaProc;
                }
                else
                    if (mstrParaProc != null && mstrParaProc != "") lstrCmd += " Where " + mstrParaProc;

                //ds = clsAccess.gExecuteQuery(_ConnectionString, lstrCmd);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    if (ID == "")
                        ID = ds.Tables[0].Rows[0][0].ToString();
                    txtCodigo.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDescripcion.Text = ds.Tables[0].Rows[0][2].ToString();
                }

                if (ds != null)
                    ds.Dispose();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Codigo_Load(object sender, EventArgs e)
        {
            //mfrmBusqueda = new frmBusqueda();
        }

        private OjectInfo BuscarObjeto(string pCodigo)
        {
            string lstrCmd = "";
            OjectInfo obj = null;
            if (_Tabla != null)
            {

                lstrCmd = "Select " + pCampoID + "," + pCampoCod + "," + pCampoDesc + " From " + _Tabla;
                lstrCmd += " Where " + pCampoCod + "=" + pCodigo;

                if (mstrParaProc != null && mstrParaProc != "") lstrCmd += " and " + mstrParaProc;

                DataSet ds = null; //TODO clsAccess.gExecuteQuery(_ConnectionString, lstrCmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    obj = new OjectInfo(ds.Tables[0].Rows[0][pCampoID].ToString(), ds.Tables[0].Rows[0][pCampoCod].ToString(), ds.Tables[0].Rows[0][pCampoBusq].ToString());
            }
            return obj;
        }

        private void mRaiseCodigoChanged(bool pbooTab)
        {
            try
            {
                if (CodigoChanged != null)
                CodigoChanged();
                if (pbooTab)
                    SendKeys.Send("{tab}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private class OjectInfo
        {
            public string ID;
            public string Codigo;
            public string Descripcion;
            public OjectInfo(string pID, string pCodigo, string pDescripcion)
            {
                ID = pID;
                Codigo = pCodigo;
                Descripcion = pDescripcion;
            }
        }

        private void btnLimp_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtCodigo.Focus();
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                OjectInfo objBusq = BuscarObjeto(txtCodigo.Text);
                if (objBusq == null)
                {
                    frmBusqueda ofrm = new frmBusqueda();
                    ofrm.ParametrosWhere = mstrParaProc;
                    ofrm.CampoBusqueda = pCampoBusq;
                    ofrm.CampoID = pCampoID;
                    ofrm.CampoCodigo = pCampoCod;
                    ofrm.CampoDescrip = pCampoDesc;
                    ofrm.pTabla = this._Tabla;
                    if (ofrm.ShowDialog() == DialogResult.OK)
                    {
                        this._ID = ofrm.ID;
                        this.txtDescripcion.Text = ofrm.pDescripcion;
                        this.txtCodigo.Text = ofrm.pCodigo;
                        mRaiseCodigoChanged(false);
                    }
                    else
                    {
                        this._ID = null;
                    }
                }
                else //encontró el objeto
                {
                    this.txtCodigo.Text = objBusq.Codigo;
                    this._ID = objBusq.ID;
                    this._Codi = objBusq.Codigo;
                    this.txtDescripcion.Text = objBusq.Descripcion;
                    mRaiseCodigoChanged(false);
                } 
            }
            else
                txtDescripcion.Text = "";
            
        }       

    }
}
