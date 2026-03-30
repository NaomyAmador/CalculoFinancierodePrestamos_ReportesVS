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
        public FormMenúPrincipal()
        {
            InitializeComponent();
        }

        private void Btn_FormSolicitudPréstamos_Click(object sender, EventArgs e)
        {
            FormSolicitudPréstamos FormBotónNúmero1 = new FormSolicitudPréstamos();
            FormBotónNúmero1.Owner = this;
            FormBotónNúmero1.Show();
            this.Hide();
        }

        private void Btn_FormAbonarCuota_Click(object sender, EventArgs e)
        {
            FormAbonarCuota FormBotónNúmero2 = new FormAbonarCuota();
            FormBotónNúmero2.Owner = this;
            FormBotónNúmero2.Show();
            this.Hide();
        }

        private void Btn_FormVerClientes_Click(object sender, EventArgs e)
        {
            FormVerCientes FormBotónNúmero3 = new FormVerCientes();
            FormBotónNúmero3.Owner = this;
            FormBotónNúmero3.Show();
            this.Hide();
        }

        private void Btn_FormPréstamosTomados_Click(object sender, EventArgs e)
        {
            FormPréstamosTomados FormBotónNúmero4 = new FormPréstamosTomados();
            FormBotónNúmero4.Owner = this;
            FormBotónNúmero4.Show();
            this.Hide();
        }

        private void Btn_FormReportes_Click(object sender, EventArgs e)
        {
            Reportes FormBotónNúmero5 = new Reportes();
            FormBotónNúmero5.Owner = this;
            FormBotónNúmero5.Show();
            this.Hide();
        }
    }
}
