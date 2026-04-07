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

namespace CálculoFinancierodePréstamos.Clientes
{
    public partial class FrmReporteInfoCliente : Form
    {
        public FrmReporteInfoCliente()
        {
            InitializeComponent();
        }

        private void FrmReporteInfoCliente_Load(object sender, EventArgs e)
        {
            VerClientes servicio = new VerClientes();

            string user = SesionUsuario.IdUsuarioLogueado;

       
            DataTable dtTodo = servicio.ObtenerDatosReportePorNombreUsuario(user);

            if (dtTodo.Rows.Count > 0)
            {
                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetInfocliente", dtTodo));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetInfoClienteDatosPrestamo", dtTodo));

                reportViewer1.RefreshReport();
            }
        }
                        
        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
