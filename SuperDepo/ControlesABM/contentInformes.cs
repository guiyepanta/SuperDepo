using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SuperDepo_CMM;
using SuperDepo_BL;
using SuperDepo_SL;

namespace SuperDepo.ControlesABM
{
    public partial class contentInformes : UserControl
    {
        public contentInformes()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                this.cargarInforme();
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarInforme() 
        {
            switch (this.cmbInformes.Text)
            {
                case "Salidas":
                    this.cargarInformeSalidas();
                    break;
                case "Salidas con Entrada":
                    this.cargarInformeSalidasConEntrada();
                    break;
                case "Productos Disponibles":
                    this.cargarProductosDisponibles();
                    break;
                case "Productos en Uso":
                    this.cargarProductosEnUso();
                    break;
                case "Productos en Reparacion":
                    this.cargarProductosEnReparacion();
                    break;
                case "Productos Fuera de servicio":
                    this.cargarProductosFueraServicio();
                    break;
                default:
                    break;
            }

        }

        private void cargarProductosFueraServicio()
        {
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "ProductosFueraServicio";
            rds.Value = productoManager.getInstance().getReporteProductosFueraServicio();

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);
            reportViewer.LocalReport.ReportPath = appGlobals.appReportFolder + "\\rptProductosFueraServicio.rdlc";
            reportViewer.LocalReport.Refresh();
            reportViewer.RefreshReport();
        }

        private void cargarProductosEnReparacion()
        {
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "ProductosEnReparacion";
            rds.Value = productoManager.getInstance().getReporteProductosEnReparacion();

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);
            reportViewer.LocalReport.ReportPath = appGlobals.appReportFolder + "\\rptProductosEnReparacion.rdlc";
            reportViewer.LocalReport.Refresh();
            reportViewer.RefreshReport();
        }

        private void cargarProductosEnUso()
        {
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "ProductosEnUso";
            rds.Value = productoManager.getInstance().getReporteProductosEnUso();

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);
            reportViewer.LocalReport.ReportPath = appGlobals.appReportFolder + "\\rptProductosEnUso.rdlc";
            reportViewer.LocalReport.Refresh();
            reportViewer.RefreshReport();
        }

        private void cargarProductosDisponibles()
        {
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "ProductosDisponibles";
            rds.Value = productoManager.getInstance().getReporteProductosDisponibles();

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);
            reportViewer.LocalReport.ReportPath = appGlobals.appReportFolder + "\\rptProductosDisponibles.rdlc";
            reportViewer.LocalReport.Refresh();
            reportViewer.RefreshReport();
        }

        private void cargarInformeSalidas()
        {
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "SalidasVigentes";
            rds.Value = salidaManager.getInstance().getReporteSalidasVigentes();

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);
            reportViewer.LocalReport.ReportPath = appGlobals.appReportFolder + "\\rptSalidasVigentes.rdlc";
            reportViewer.LocalReport.Refresh();
            reportViewer.RefreshReport();
        }

        private void cargarInformeSalidasConEntrada()
        {
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsSalidasConEntreda";
            rds.Value = salidaManager.getInstance().getReporteSalidasConEntrada();

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);
            reportViewer.LocalReport.ReportPath = appGlobals.appReportFolder + "\\rptSalidasConEntrada.rdlc";
            reportViewer.LocalReport.Refresh();
            reportViewer.RefreshReport();
        }
    }
}
