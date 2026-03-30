using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using LógicaNegocio;

namespace CálculoFinancierodePréstamos.Clientes
{
    public partial class FrmPago : Form
    {

        private int idPrestamo;

        private CuotasParaPago cuotaAD = new CuotasParaPago();
        private PrestamoPago prestamoAD = new PrestamoPago();
        private LógicaNegocio_Pagos Pago = new LógicaNegocio_Pagos();

        public FrmPago(int idPrestamo)
        {
            InitializeComponent();
            this.idPrestamo = idPrestamo;
        }

        private void FrmPago_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
        }


        private void ConfigurarControles()
        {

            txtMontoAnterior.ReadOnly = true;
            txtInteres.ReadOnly = true;
            txtCuota.ReadOnly = true;
            txtMora.ReadOnly = true;
            txtTotalPagar.ReadOnly = true;
            txtMesesRestantes.ReadOnly = true;
            txtMesActual.ReadOnly = true;

            dgvCuotaActual.ReadOnly = true;
            dgvCuotaActual.AllowUserToAddRows = false;
            dgvCuotaActual.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatos()
        {
            var cuota = cuotaAD.ObtenerCuotaPendiente(idPrestamo);


            if (cuota == null)
            {
                MessageBox.Show("Préstamo finalizado");
                btnPagar.Enabled = false;
                dgvCuotaActual.DataSource = null;
                return;
            }

            var prestamo = prestamoAD.ObtenerPrestamo(idPrestamo);

            int mora = 0;

            if (DateTime.Now > cuota.FechaVencimiento)
            {
                mora = (int)(cuota.MontoCuota * 0.10);
            }

            int total = cuota.MontoCuota + mora;

            txtMontoAnterior.Text = cuota.SaldoRemanente.ToString();
            txtInteres.Text = cuota.InteresCuota.ToString();
            txtCuota.Text = cuota.MontoCuota.ToString();
            txtMora.Text = mora.ToString();
            txtTotalPagar.Text = total.ToString();
            txtMesActual.Text = cuota.NumeroDeCuota.ToString();
            txtMesesRestantes.Text = (prestamo.PlazoMeses - cuota.NumeroDeCuota).ToString();
       

            dgvCuotaActual.DataSource = new List<Cuotas> { cuota };

            btnPagar.Enabled = true;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                Pago.ProcesarPago(idPrestamo);

                MessageBox.Show("Pago realizado correctamente");

                CargarDatos(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
    