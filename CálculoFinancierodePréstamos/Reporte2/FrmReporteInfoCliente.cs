using AccesoDatos;
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

namespace CálculoFinancierodePréstamos.Reporte2
{
    public partial class FrmReporteInfoCliente : Form
    {
        public int IdClienteRecibido { get; set; }
        public FrmReporteInfoCliente()
        {
            InitializeComponent();
        }

        private void FrmReporteInfoCliente_Load(object sender, EventArgs e)
        {
            VerClientes servicio = new VerClientes();

            
            reportViewer1.LocalReport.ReportEmbeddedResource =
                "CálculoFinancierodePréstamos.Reporte2.ReporteInfoCliente.rdlc";

            DataTable dtTodo = servicio.ObtenerDatosReportePorIdCliente(IdClienteRecibido);

            if (dtTodo.Rows.Count > 0)
            {
                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("DataSetInfocliente", dtTodo));

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("DataSetInfoClienteDatosPrestamo", dtTodo));

                reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("No hay datos para este cliente");
            }
        }
                        
        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
