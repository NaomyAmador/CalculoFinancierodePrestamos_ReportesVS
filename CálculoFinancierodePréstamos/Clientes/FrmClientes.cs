using Entidades;
using LógicaNegocio;
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
using CálculoFinancierodePréstamos.Principal;

namespace CálculoFinancierodePréstamos.Clientes
{
    public partial class FrmClientes : Form
    {
        //Variables en uso
        int Intentos = 3;
        int Tiempo = 0;
        public FrmClientes(string usuario)
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogicaNegocio_Clientes lNClientes = new LogicaNegocio_Clientes();
            Entidades.Clientes clientes = new Entidades.Clientes();
            clientes.IdUsuario = int.Parse(textBoxuser.Text);
            clientes.NombreCompleto = textBox1.Text;
            clientes.Correo = textBox2.Text;
            clientes.Direccion = textBox3.Text;
            clientes.Telefono = textBox4.Text;
            clientes.SueldoMensual = int.Parse(textboxx.Text);

            lNClientes.RegistrarCliente(clientes);
            MessageBox.Show("¡Usuario creado correctamente!");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LogicaNegocio_Clientes lNClientes = new LogicaNegocio_Clientes();
            //Entidades.Clientes clientes = new Entidades.Clientes();
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void textBoxuser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
