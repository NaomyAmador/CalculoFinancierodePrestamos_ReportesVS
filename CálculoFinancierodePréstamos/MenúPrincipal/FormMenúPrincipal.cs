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
            
        }

        private void Btn_FormVerClientes_Click(object sender, EventArgs e)
        {
            
        }
    }
}
