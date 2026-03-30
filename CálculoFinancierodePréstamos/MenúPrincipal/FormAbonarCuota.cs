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
    public partial class FormAbonarCuota : Form
    {
        public FormAbonarCuota()
        {
            InitializeComponent();
        }

        private void Btn_VolverMenúPrincipal_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
