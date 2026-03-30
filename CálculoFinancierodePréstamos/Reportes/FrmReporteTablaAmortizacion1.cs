using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CálculoFinancierodePréstamos.Reportes;

namespace CálculoFinancierodePréstamos.Reportes
{
    public partial class FrmReporteTablaAmortizacion1 : Form
    {
        private dsReporteTableAdapters.PrestamosTableAdapter prestamosAdapter = new dsReporteTableAdapters.PrestamosTableAdapter();
        private dsReporteTableAdapters.CuotasTableAdapter cuotasAdapter = new dsReporteTableAdapters.CuotasTableAdapter();
        private dsReporte datosReporte = new dsReporte();
        public int IdPrestamoRecibido { get; set; }
        public List<Cuotas> ListaAmortizacionSubida { get; set; }
        public FrmReporteTablaAmortizacion1()
        {
            InitializeComponent();
        }

        private void FrmReporteTablaAmortizacion1_Load(object sender, EventArgs e)
        {
            
            try
            {
                datosReporte.EnforceConstraints = false;
                datosReporte.Prestamos.Clear();

                if (IdPrestamoRecibido <= 0)
                {
                    MessageBox.Show("No se recibió un ID de préstamo válido.");
                    return;
                }

                prestamosAdapter.FillByIdPrestamo(datosReporte.Prestamos, IdPrestamoRecibido);
                cuotasAdapter.FillByPrestamoId(datosReporte.Cuotas, IdPrestamoRecibido);

             
                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrestamos", (DataTable)this.datosReporte.Prestamos));

                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetCuotas1", (DataTable)this.datosReporte.Cuotas));

   
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetTablarAmor1", ListaAmortizacionSubida));

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error de Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
          
     
}
