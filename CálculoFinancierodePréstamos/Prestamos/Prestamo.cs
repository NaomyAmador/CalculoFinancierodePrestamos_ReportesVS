using LógicaNegocio;
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

namespace CálculoFinancierodePréstamos.Prestamos
{
    public partial class Prestamo : Form
    {
        public Prestamo()
        {
            InitializeComponent();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            LogicaNegocios_Prestamos guardar = new LogicaNegocios_Prestamos();
            
          
        }
    }
}
