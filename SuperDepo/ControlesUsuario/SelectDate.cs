using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperDepo.ControlesUsuario
{
    public partial class SelectDate : UserControl
    {
        #region Evento Custom

        public delegate void SelectDateEventHandler();
        public event SelectDateEventHandler SelectDateChanged;
        private void RaiseSelectDateChanged()
        {
            if (SelectDateChanged != null)
                SelectDateChanged();
        }

        #endregion
        
        public SelectDate()
        {
            InitializeComponent();
        }

        public DateTime SeletedDate { get { return this.Calendar.SelectionEnd; } set { this.txtDate.Text = value.ToLongDateString(); this.Calendar.SetDate(value); } }
             

        private void btnShowCalendar_Click(object sender, EventArgs e)
        {
            if (this.btnShowCalendar.Tag == null)
            {
                this.btnShowCalendar.Image = Properties.Resources.btnOk;
                this.btnShowCalendar.Tag = "Ok";
                this.Height = 190;
                
                if (this.Width < 188)
                    this.Width = 188;

                this.Calendar.Left = (this.Width - this.Calendar.Width) / 2;
                this.Calendar.Visible = true;
                this.Update();
                this.Refresh();
            }
            else
            {
                this.btnShowCalendar.Image = Properties.Resources.Calendar;
                this.btnShowCalendar.Tag = null;
                this.txtDate.Text = this.Calendar.SelectionEnd.ToLongDateString();
                this.Height = this.txtDate.Height + 1;
                this.Calendar.Visible = false;
                RaiseSelectDateChanged();
            }
        }

        private void btnShowCalendar_Resize(object sender, EventArgs e)
        {
                this.btnShowCalendar.Height = this.txtDate.Height + 2;
        }
    }
}
