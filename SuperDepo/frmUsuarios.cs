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
    public partial class frmUsuarios : Form
    {
        Users mUsers = new Users();
        bool conAcceso = false;
        
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void txtCriterio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.FiltrarListaTecnicos(this.txtCriterio.Text);
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstUsers.SelectedItems.Count > 0)
                {
                    User u = (User)this.lstUsers.SelectedItems[0].Tag;
                    this.Datos2UI(u);
                    this.enableEdicion(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }

        private void Datos2UI(User user)
        {
            this.grpDatos.Tag = user.Id;
            this.txtName.Text = user.Name;
            this.txtLastName.Text = user.LastName;
            this.txtUserName.Text = user.UserName;
            this.txtPassword.Text = SecurityManager.getInstance().Desencriptar(user.Password);
            this.txtRePassword.Text = this.txtPassword.Text;
            this.txtDni.Text = user.Dni;
            this.txtTelefono.Text = user.Telefono;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.LimpiarTodo();
                this.enableEdicion(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }                
        }

        private void enableEdicion(bool enable)
        {
            this.grpListado.Enabled = !enable;
            this.grpDatos.Enabled = enable;
        }

        private void LimpiarTodo()
        {
            this.grpDatos.Tag = null;
            this.txtName.Text = "";
            this.txtLastName.Text = "";
            this.txtUserName.Text = "";
            this.txtPassword.Text = "";
            this.txtRePassword.Text = "";
            this.txtDni.Text = "";
            this.txtTelefono.Text = "";
            this.tbUsuario.SelectedIndex = 0;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.conAcceso = this.tieneAcceso();
                if (this.conAcceso)
                {
                    this.cargarlistado();
                }
                else
                {
                    this.Datos2UI(appGlobals.gUser);
                    this.enableEdicion(true);  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }
        }

        private bool tieneAcceso()
        {
            foreach (Modulo mod in appGlobals.gUser.Accesos)
            {
                if (mod._Modulo == "ABM Usuarios")
                    return true;
            }

            return false;
        }

        
        private void cargarlistado()
        {
            this.mUsers = userManager.getInstance().GetUsers();
            this.FiltrarListaTecnicos(this.txtCriterio.Text);
        }

        private void FiltrarListaTecnicos(string Criterio)
        {            
            var qAll = from u in mUsers.list
                        orderby u.Name 
                        select u;

            this.FillListaTecnicos(qAll);           
        }

        private void FillListaTecnicos(IOrderedEnumerable<User> q)
        {
            this.lstUsers.Items.Clear();
            foreach (User u in q)
            {
                ListViewItem item = new ListViewItem();
                item.Text = u.Name + ", " + u.LastName;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, u.Telefono));
                item.Tag = u;
                item.Selected = false;                
                lstUsers.Items.Add(item);
            }
        }

        private void lstTecnicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lstUsers.SelectedItems.Count > 0)
                {
                    User u = (User)this.lstUsers.SelectedItems[0].Tag;
                    this.Datos2UI(u);
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
                    User u = this.UI2Datos();
                    u.Id = userManager.getInstance().GuardarDatos(u);

                    if (this.conAcceso)
                    {
                        this.cargarlistado();
                        this.LimpiarTodo();
                        this.grpDatos.Enabled = false;
                        this.grpListado.Enabled = true;
                    }
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

        private User UI2Datos()
        {
            User u = new User();
            u.Id = (this.grpDatos.Tag == null ? 0 : Convert.ToInt32(this.grpDatos.Tag));
            u.Name = this.txtName.Text;
            u.LastName = this.txtLastName.Text;
            u.UserName  = this.txtUserName.Text;
            u.Password = SecurityManager.getInstance().Encriptar(this.txtPassword.Text);
            u.Dni = this.txtDni.Text;
            u.Telefono = this.txtTelefono.Text;
            u.Accesos = this.getAccesosAModulos();
            return u;
        }

        private List<Modulo> getAccesosAModulos()
        {
            List<Modulo> modulos = new List<Modulo>();

            foreach (ListViewItem item in this.lstAsignados.Items)
            {
                Modulo mod = (Modulo)item.Tag;
                modulos.Add(mod);
            }

            return modulos;
        }

        private bool validarDatos()
        {
            if (this.txtName.Text == "")
                return false;
            if (this.txtLastName.Text == "")
                return false;
            if (this.txtPassword.Text == "")
                return false;
            if (this.txtPassword.Text != this.txtRePassword.Text)
                return false;

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.conAcceso)
            {
                this.LimpiarTodo();
                this.enableEdicion(false);
            }
            else
                this.Close();
        }

        private void tbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbUsuario.SelectedTab.Name == "tabAccesos")
                {
                    this.cargarAccesos();

                    // Si no tienen Permiso de Admin
                    // solo puede ver que accesos tiene su Usuario
                    this.lstAsignados.Enabled = this.conAcceso;
                    this.lstDisponibles.Enabled = this.conAcceso;
                    this.btnAddModulo.Enabled = this.conAcceso;
                    this.btnRemoveModulo.Enabled = this.conAcceso;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionManager.log(ex.Message, ex.StackTrace);
            }              
        }

        private void cargarAccesos()
        {
            this.CargarAccessosAsignados();
            this.CargarAccesosDisponibles();
        }

        private void CargarAccesosDisponibles()
        {
            List<Modulo> lstModulos = userManager.getInstance().getModulos();
            this.lstDisponibles.Items.Clear();
            foreach (Modulo mod in lstModulos)
            {
                if (!this.ModuloAsignado(mod.Id))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = mod._Modulo;
                    item.Tag = mod;
                    item.Selected = false;
                    this.lstDisponibles.Items.Add(item);
                }
            }
        }

        private bool ModuloAsignado(int idModulo)
        {
            foreach (ListViewItem item in this.lstAsignados.Items)
            {
                int idModAsinado = ((Modulo)item.Tag).Id;
                if (idModAsinado == idModulo)
                    return true;
            }
            return false;
        }

        private void CargarAccessosAsignados()
        {
            if (this.grpDatos.Tag != null)
            {
                List<Modulo> lstModAsign = userManager.getInstance().getAccesosAsignados((Int32)this.grpDatos.Tag);
                this.lstAsignados.Items.Clear();

                foreach (Modulo  mod in lstModAsign)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = mod._Modulo;
                    item.Tag = mod;
                    item.Selected = false;
                    this.lstAsignados.Items.Add(item);
                }
            }            
        }

        private void btnAddModulo_Click(object sender, EventArgs e)
        {
            if (this.lstDisponibles.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this.lstDisponibles.SelectedItems)
                {
                    this.lstDisponibles.Items.Remove(item);                    
                    this.lstAsignados.Items.Add(item);
                }
            }
        }

        private void btnRemoveModulo_Click(object sender, EventArgs e)
        {
            if (this.lstAsignados.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this.lstAsignados.SelectedItems)
                {
                    this.lstAsignados.Items.Remove(item);
                    item.Selected = false;
                    this.lstDisponibles.Items.Add(item);
                }
            }
        }
    }
}
