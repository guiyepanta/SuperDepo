using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SuperDepo_CMM;
using SuperDepo_BL;
using SuperDepo_SL;

namespace SuperDepo
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                User usrLogin = new User();

                usrLogin.UserName = this.cmbUsuario.SelectedValue.ToString();
                usrLogin.Password = SecurityManager.getInstance().Encriptar(this.txtPassword.Text);

                usrLogin = userManager.getInstance().validaLogin(usrLogin);

                if (usrLogin != null)
                {
                    appGlobals.gUser = usrLogin;
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Usuario o password incorrecto. Ingreselo nuevamente", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblAppName.Text = appGlobals.appName;
            lblVersion.Text = appGlobals.appVersion;
            cargarComboUsuarios();
        }

        private void cargarComboUsuarios()
        {
            try
            {
                Users lstUser = new Users();
                lstUser = userManager.getInstance().GetUsers();

                var dicUsers = new Dictionary<string, string>();

                foreach (User usr in lstUser.list)
                {
                    dicUsers.Add(usr.UserName, usr.LastName + ", " + usr.Name);
                }

                cmbUsuario.DataSource = new BindingSource(dicUsers, null);
                cmbUsuario.ValueMember = "Key";
                cmbUsuario.DisplayMember = "Value";               
                
            }
            catch (Exception)
            {                
                MessageBox.Show("Se ha producido un error\r\nSi persiste llame al administrador");
            }
        }
        
        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
        }
    }
}
