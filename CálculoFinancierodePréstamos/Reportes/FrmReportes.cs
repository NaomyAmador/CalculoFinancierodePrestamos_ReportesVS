using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CálculoFinancierodePréstamos.Reportes
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void btn_Reporte3_Click(object sender, EventArgs e)
        {
            string consultaNaomy3 = @"SELECT 
                             SUM(MontoCapital) AS TotalPrestado,
                             SUM(MontoTotal - MontoCapital) AS TotalGanancia
                             FROM Prestamos";

           
            string miConexion = @"Data Source=LAPTOP-PHTCMGVS\SQLEXPRESS;Initial Catalog=CalculoFinancierodeReportes;Integrated Security=True";

            DataTable dt = new DataTable();

            try
            {
               
                using (SqlConnection conexion = new SqlConnection(miConexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter(consultaNaomy3, conexion);
                    da.Fill(dt);
                }

                if (dt.Rows.Count > 0 && dt.Rows[0]["TotalPrestado"] == DBNull.Value)
                {
                    MessageBox.Show("No hay préstamos registrados todavía.", "Aviso");
                    return;
                }

               
                FrmTotalDelBanco visor = new FrmTotalDelBanco();
                visor.DatosReporte = dt; 
                visor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message);
            }

        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {

        }

        private void btn_Reporte4_Click(object sender, EventArgs e)
        {
            // 1. La consulta (Asegúrate que 'TotalMora' no tenga espacios)
            string sql = @"SELECT c.NombreCompleto AS Cliente, COUNT(m.IdMora) AS CantidadMora
                   FROM Moras m 
                   INNER JOIN Clientes c ON m.IdCliente = c.IdCliente 
                   GROUP BY c.NombreCompleto";

            // 2. Tu conexión (Ya con tu servidor: LAPTOP-PHTCMGVS\SQLEXPRESS)
            string cadena = @"Data Source=LAPTOP-PHTCMGVS\SQLEXPRESS;Initial Catalog=CalculoFinancierodeReportes;Integrated Security=True";

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay moras registradas en el sistema.");
                    return;
                }

                // 3. Configurar y abrir el Visor
                FrmCantidadMoras visor = new FrmCantidadMoras();

                // Estas dos líneas funcionarán SI ya agregaste las propiedades en FrmCantidadMoras.cs
                visor.DatosReporte = dt;
                visor.NombreDataSet = "DataSetMorosos";

                visor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message);
            }
        }
    }
}
