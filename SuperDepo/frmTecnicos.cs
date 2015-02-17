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
    public partial class frmTecnicos : Form
    {
        List<Tecnico> mTecnicos;
        public frmTecnicos()
        {
            InitializeComponent();
        }

        private void txtCriterio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.FiltrarListaTecnicos(this.cmbCampoFiltro.Text, this.txtCriterio.Text);
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void cmbCampoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstTecnicos.SelectedItems.Count > 0)
                {
                    Tecnico t = (Tecnico)this.lstTecnicos.SelectedItems[0].Tag;
                    this.Datos2UI(t);
                    this.enableEdicion(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }

        private void Datos2UI(Tecnico tec)
        {
            this.grpDatos.Tag = tec.Id;
            this.txtNombre.Text = tec.Nombre;
            this.txtCargo.Text = tec.Cargo;
            this.txtTelefono.Text = tec.Telefono;
            this.txtDni.Text = tec.Dni;
            this.cmbEstado.SelectedValue = tec.Estado;
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
            this.txtNombre.Text = "";
            this.txtCargo.Text = "";
            this.txtTelefono.Text = "";
            this.txtDni.Text = "";
            this.cmbEstado.SelectedIndex = 0;
        }

        private void frmClientes_Load(object sender, EventArgs e)
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
            cmbEstado.DataSource = new BindingSource(appManager.getInstance().getSystemEstate(), null);
            cmbEstado.DisplayMember = "Value";
            cmbEstado.ValueMember = "Key";
        }

        private void cargarlistado()
        {
            this.mTecnicos = new List<Tecnico>();
            this.mTecnicos = tecnicoManager.getInstance().listaTecnicos();
            this.FiltrarListaTecnicos(this.cmbCampoFiltro.Text, this.txtCriterio.Text);
        }

        private void FiltrarListaTecnicos(string Campo, string Criterio)
        {
            if (Criterio == "")
            {
                var qAll = from t in mTecnicos
                           orderby t.Nombre
                           select t;

                this.FillListaTecnicos(qAll);
            }
            else
            {
                if (Campo == "Nombre")
                {
                    var qNom = from t in mTecnicos
                               where (t.Nombre.ToLower().Contains(Criterio.ToLower()))
                               orderby t.Nombre
                               select t;

                    this.FillListaTecnicos(qNom);
                }
                else if (Campo == "Nombre")
                {
                    var qCar = from t in mTecnicos
                               where (t.Cargo.ToLower().Contains(Criterio.ToLower()))
                               orderby t.Nombre
                               select t;

                    this.FillListaTecnicos(qCar);
                }
            }
        }

        private void FillListaTecnicos(IOrderedEnumerable<Tecnico> q)
        {
            this.lstTecnicos.Items.Clear();
            foreach (Tecnico t in q)
            {
                ListViewItem item = new ListViewItem();
                item.Text = t.Nombre;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, t.Cargo));
                item.Tag = t;
                item.Selected = false;
                if (t.Estado == 0)
                    item.ForeColor = Color.FromArgb(255, 0, 0);
                lstTecnicos.Items.Add(item);
            }
        }

        private void lstTecnicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lstTecnicos.SelectedItems.Count > 0)
                {
                    Tecnico tec = (Tecnico)this.lstTecnicos.SelectedItems[0].Tag;
                    this.Datos2UI(tec);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validarDatos())
                {
                    Tecnico tec = this.UI2Datos();
                    tecnicoManager.getInstance().GuardarDatos(tec);
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

        private Tecnico UI2Datos()
        {
            Tecnico tec = new Tecnico();
            tec.Id = (this.grpDatos.Tag == null ? 0 : Convert.ToInt32(this.grpDatos.Tag));
            tec.Nombre = this.txtNombre.Text;
            tec.Cargo = this.txtCargo.Text;
            tec.Telefono = this.txtTelefono.Text;
            tec.Dni = this.txtDni.Text;
            tec.Estado = Convert.ToInt32(this.cmbEstado.SelectedValue);

            return tec;
        }

        private bool validarDatos()
        {
            if (this.txtNombre.Text == "")
                return false;
            if (this.txtCargo.Text == "")
                return false;
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarTodo();
            this.enableEdicion(false);
        }
    }
}
