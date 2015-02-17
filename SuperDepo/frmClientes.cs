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
    public partial class frmClientes : Form
    {
        List<Cliente> mlstClientes;
        
        public frmClientes()
        {
            InitializeComponent();
        }

        #region Propiedades

        
        #endregion

        #region Eventos Controles
        
        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbCampoFiltro.SelectedIndex = 0;
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
                this.lstClientes.Items.Clear();
                this.FiltrarDatosClientes(cmbCampoFiltro.Text, txtCriterio.Text);
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
            if (MessageBox.Show("Esta seguro que desea Eliminar", "Atencion!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("Falta implementar BAJA LOGICA");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try 
	        {
                if (this.lstClientes.SelectedItems.Count > 0)
                {
                    Cliente cl = (Cliente)this.lstClientes.SelectedItems[0].Tag;
                    this.Datos2UI(cl);
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
            this.LimpiarTodo();
            this.enableEdicion(true);
        }

        private void enableEdicion(bool enable)
        {
            this.grpListado.Enabled = !enable;
            this.grpDatos.Enabled = enable;
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validarDatos())
                {
                    Cliente cl = this.UI2Datos();
                    clienteManager.getInstance().GuardarDatos(cl);
                    this.cmbCampoFiltro.SelectedIndex = 0;
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

        private void lstClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {            
                if (this.lstClientes.SelectedItems.Count > 0)
                {
                    Cliente cl = (Cliente)this.lstClientes.SelectedItems[0].Tag;
                    this.Datos2UI(cl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }
        
        #endregion

        private void LimpiarTodo()
        {
            this.grpDatos.Tag = null;
            this.txtNombre.Text = "";
            this.txtContacto.Text = "";
            this.txtTelefono.Text = "";
            this.txtCelular.Text = "";
            this.txtDireccion.Text = "";
            this.txtCodPostal.Text = "";
            this.Localidad.Text = "";
            this.cmbCondicion.SelectedIndex = 0;
            this.txtCuil.Text = "";
            this.txtEmail.Text = "";
            this.txtObservaciones.Text = "";
            this.grpDatos.Enabled = false;
        }

        private void cargarlistado()
        {
            mlstClientes = new List<Cliente>();
            mlstClientes = clienteManager.getInstance().listaClientes();

            this.FiltrarDatosClientes(this.cmbCampoFiltro.SelectedText, this.txtCriterio.Text);
        }

        private void FiltrarDatosClientes(string campo, string criterio)
        {
            if (criterio == "")
            {
                var qAll = from c in mlstClientes
                           orderby c.Nombre
                           select c;

                this.FillListaClientes(qAll);
            }
            else
                if (campo == "Nombre")
                {
                    var qNom = from c in mlstClientes
                               where (c.Nombre.ToLower().Contains(criterio.ToLower()))
                               orderby c.Nombre
                               select c;

                    FillListaClientes(qNom);
                }
                else
                {
                    var qCon = from c in mlstClientes
                               where (c.Contacto.ToLower().Contains(criterio.ToLower()))
                               orderby c.Nombre
                               select c;

                    FillListaClientes(qCon);
                }
        }

        private void FillListaClientes(IOrderedEnumerable<Cliente> q)
        {
            this.lstClientes.Items.Clear();   
            foreach (Cliente cl in q)
            {
                ListViewItem item = new ListViewItem();
                item.Text = cl.Nombre;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, cl.telContacto));
                item.Tag = cl;
                item.Selected = false;
                lstClientes.Items.Add(item);
            }
        }

        private void Datos2UI(Cliente cl)
        {
            this.grpDatos.Tag = cl.Id;
            this.txtNombre.Text = cl.Nombre;
            this.txtContacto.Text = cl.Contacto;
            this.txtTelefono.Text = cl.telContacto;
            this.txtCelular.Text = cl.telCelular;
            this.txtDireccion.Text = cl.Direccion;
            this.txtCodPostal.Text = cl.CodigoPostal;
            this.Localidad.Text = cl.Localidad;

            if (cl.Condicion != "")
                this.cmbCondicion.SelectedText = cl.Condicion;
            else
                this.cmbCondicion.SelectedIndex = 0;

            this.txtCuil.Text = cl.Cuil;
            this.txtEmail.Text = cl.Email;
            this.txtObservaciones.Text = cl.Observaciones;
        }

        private Cliente UI2Datos() 
        {
            Cliente cl = new Cliente();

            cl.Id = (this.grpDatos.Tag != null ? (Int32)this.grpDatos.Tag : 0);
            cl.Nombre =this.txtNombre.Text;
            cl.Contacto = this.txtContacto.Text;
            cl.telContacto = this.txtTelefono.Text;
            cl.telCelular = this.txtCelular.Text;
            cl.Direccion = this.txtDireccion.Text;
            cl.CodigoPostal = this.txtCodPostal.Text;
            cl.Localidad = this.Localidad.Text;
            cl.Condicion = this.cmbCondicion.Text;
            cl.Cuil = this.txtCuil.Text;
            cl.Email = this.txtEmail.Text;
            cl.Observaciones = this.txtObservaciones.Text;

            return cl;
        }

        private bool validarDatos()
        {
            if (this.txtNombre.Text == "")
                return false;
            if (this.txtTelefono.Text == "")
                return false;
            if (this.txtCuil.Text == "")
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
