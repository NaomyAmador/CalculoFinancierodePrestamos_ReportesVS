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
    public partial class FrmCantidadMoras : Form
    {
        public System.Data.DataTable DatosReporte { get; set; }
        public string NombreDataSet { get; set; }
        public FrmCantidadMoras()
        {
            InitializeComponent();
        }

        private void FrmCantidadMoras_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Limpiamos cualquier dato viejo
                this.reportViewer1.LocalReport.DataSources.Clear();

                // 2. Decidimos qué nombre usar (si no mandamos nada, usamos DataSet1)
                string dsNombre = string.IsNullOrEmpty(NombreDataSet) ? "DataSet1" : NombreDataSet;

                // 3. Creamos el origen de datos con la tabla que recibimos del botón
                Microsoft.Reporting.WinForms.ReportDataSource rds =
                    new Microsoft.Reporting.WinForms.ReportDataSource(dsNombre, DatosReporte);

                // 4. Lo añadimos al visor y refrescamos
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el visor: " + ex.Message);
            }
        }
    }
}
