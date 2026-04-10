using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using LógicaNegocio;

namespace CálculoFinancierodePréstamos.Pagos
{
    public partial class frmDatosParaPago : Form
    {
        BuscarPrestamo busquedaAD = new BuscarPrestamo();
        int idPrestamo = 0;
        private User_Login _idPrestamo;
        public frmDatosParaPago()
        {
            InitializeComponent();
        }

        private void frmDatosParaPago_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Continuar_Click(object sender, EventArgs e)
        {
            idPrestamo = busquedaAD.ObtenerIdPrestamo(txtUsuario.Text, txtNombreCliente.Text );

            if (idPrestamo == 0)
            {
                MessageBox.Show("No se encontró un préstamo activo");
                return;
            }

            else
            {
                FrmPago DirigirseFormPago = new FrmPago(idPrestamo);
                DirigirseFormPago.Show();
                this.Hide();
            }
        }
    }
}
