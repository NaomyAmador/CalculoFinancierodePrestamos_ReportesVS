using AccesoDatos;
using System;
using System.Windows.Forms;

namespace CálculoFinancierodePréstamos.HistorialPrestamosForms
{
    public partial class FrmHistorialPrestamos : Form
    {
        public FrmHistorialPrestamos()
        {
            InitializeComponent();
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            int idCliente = int.Parse(Txt_IdCliente.Text);

            HistorialPrestamos historial = new HistorialPrestamos();

            var lista = historial.ObtenerHistorialPrestamos(idCliente);

            dataGridViewPrestamos.DataSource = lista;
        }

        private void Btn_VolverMenúPrincipal_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
