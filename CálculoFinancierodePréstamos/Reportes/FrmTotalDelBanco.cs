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

namespace CálculoFinancierodePréstamos.Reportes
{
    public partial class FrmTotalDelBanco : Form
    {
        public DataTable DatosReporte { get; set; }
        public FrmTotalDelBanco()
        {
            InitializeComponent();
        }

        private void FrmTotalDelBanco_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("DataSet1", DatosReporte);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
