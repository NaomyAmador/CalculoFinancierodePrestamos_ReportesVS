using CálculoFinancierodePréstamos.ActualizarClientes;
using CálculoFinancierodePréstamos.Clientes;
using CálculoFinancierodePréstamos.HistorialPrestamosForms;
using CálculoFinancierodePréstamos.Pagos;
using CálculoFinancierodePréstamos.Prestamos;
using CálculoFinancierodePréstamos.Principal;
using CálculoFinancierodePréstamos.Reportes;
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

namespace CálculoFinancierodePréstamos.MenúPrincipal
{
    public partial class FormMenúPrincipal : Form
    {
        private User_Login _usuarioLogueado;
        public FormMenúPrincipal(User_Login usuario)
        {
            InitializeComponent();
            _usuarioLogueado = usuario;
        }

        private void Btn_FormSolicitudPréstamos_Click(object sender, EventArgs e)
        {
            //el null se utilizo aquí porque en el FrmPrestamo recibe valores en una variable.
            //Como no se usa indique que esta no recibiera nada (se quedara vacía con null, pero no la borré).
            Prestamo FormBotónNúmero2 = new Prestamo(_usuarioLogueado);
            FormBotónNúmero2.Owner = this;
            FormBotónNúmero2.Show();
            this.Hide();
        }

        private void Btn_FormAbonarCuota_Click(object sender, EventArgs e)
        {
            frmDatosParaPago FormBotónNúmero3 = new frmDatosParaPago();
            FormBotónNúmero3.Owner = this;
            FormBotónNúmero3.Show();
            this.Hide();
        }

        private void Btn_FormVerClientes_Click(object sender, EventArgs e)
        {
            FrmActualizarCliente FormBotónNúmero4 = new FrmActualizarCliente();
            FormBotónNúmero4.Owner = this;
            FormBotónNúmero4.Show();
            this.Hide();
        }

        private void Btn_FormPréstamosTomados_Click(object sender, EventArgs e)
        {
            FrmHistorialPrestamos FormBotónNúmero5 = new FrmHistorialPrestamos();
            FormBotónNúmero5.Owner = this;
            FormBotónNúmero5.Show();
            this.Hide();
        }

        private void Btn_FormReportes_Click(object sender, EventArgs e)
        {
            FrmReportes FormBotónNúmero6 = new FrmReportes();
            FormBotónNúmero6.Owner = this;
            FormBotónNúmero6.Show();
            this.Hide();
        }

        private void Btn_FrmClientes_Click(object sender, EventArgs e)
        {
            FrmClientes FormBotónNúmero1 = new FrmClientes();
            FormBotónNúmero1.Owner = this;
            FormBotónNúmero1.Show();
            this.Hide();
        }

        private void Btn_CerrarSesión_Click(object sender, EventArgs e)
        {
            FrmLogin VolveralLogin = new FrmLogin();
            VolveralLogin.Show();
            this.Hide();        
        }
    }
}
