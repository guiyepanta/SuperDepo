using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperDepo.ControlesUsuario
{
    public partial class inputBox : Form
    {
        public inputBox()
        {
            InitializeComponent();
        }

        public String Value { get; set; }
        public String Message { get; set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Value = (this.txtValue.Valor != "" ? this.txtValue.Valor : "1");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void inputBox_Load(object sender, EventArgs e)
        {
            if (this.Message != "")
                this.lblMessage.Text = this.Message;

            this.Height = this.lblMessage.Top + this.lblMessage.Height + this.txtValue.Height + this.btnOk.Height + 6;
            this.txtValue.Focus();
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk.PerformClick();
        }
    }
}
