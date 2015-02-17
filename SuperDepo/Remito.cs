using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SuperDepo_CMM;
using SuperDepo_BL;
using System.Threading;

namespace SuperDepo
{
    public partial class frmRemito : Form
    {
        public frmRemito()
        {
            InitializeComponent();
        }
        public Salida  Salida { get; set; }
        public bool  RemitoLegal { get; set; }

        private void frmRemito_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource();

            if (RemitoLegal)
                rds.Name = "dsRemitoDetallado";
            else
                rds.Name = "dsRemitoCompacto"; 

            rds.Value = salidaManager.getInstance().DatosRemito(Salida.Id, RemitoLegal);

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);
            if (RemitoLegal)
                reportViewer.LocalReport.ReportPath = @appGlobals.appReportFolder + "\\rptRemitoLegal.rdlc";
            else
                reportViewer.LocalReport.ReportPath = @appGlobals.appReportFolder + "\\rptRemitoDetallado.rdlc";

            reportViewer.LocalReport.Refresh();
            reportViewer.RefreshReport();
            Thread.Sleep(2000);
            lblCantidadHojas.Text = "Coloque en la impresora " + reportViewer.GetTotalPages().ToString() + " hojas para imprimir remito Legal";
            pnlHojas.Left = (this.Width / 2) - (pnlHojas.Width / 2);
            pnlHojas.Top = (this.Height / 2) - (pnlHojas.Height / 2);
        }

        private void frmRemito_Resize(object sender, EventArgs e)
        {
            pnlHojas.Left = (this.Width / 2) - (pnlHojas.Width / 2);
            pnlHojas.Top = (this.Height / 2) - (pnlHojas.Height / 2);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                pnlHojas.Visible = false;
                if (reportViewer.PrintDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Salida.remitida = true;
                    salidaManager.getInstance().Grabar(Salida, false);
                    this.Close();
                }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("fallo la impresion");
            }                
        }
    }
}
