using CálculoFinancierodePréstamos.Clientes;
using Entidades;
using LógicaNegocio;
using System;
using System.Windows.Forms;

namespace CálculoFinancierodePréstamos.Principal
{
    public partial class FrmLogin : Form
    {
        //Variables a Usar
        int Intentos = 3;
        int Tiempo = 0;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Timer_ProgressBar.Interval = 100;
            ProgressBar_Fallos.Minimum = 0;
            ProgressBar_Fallos.Maximum = 150;
            ProgressBar_Fallos.Value = 0;
        }

        private void Btn_Crear_Click(object sender, EventArgs e)
        {
            LógicaNegocio_Usuario LNUsuario = new LógicaNegocio_Usuario();
            User_Login UsuarioCreado = new User_Login();
            UsuarioCreado.usuario = TxtBox_Usuario.Text;
            UsuarioCreado.Contraseña = TxtBox_Contraseña.Text;

            LNUsuario.CrearUsuario(UsuarioCreado);
            MessageBox.Show("¡Usuario creado correctamente!");
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            LógicaNegocio_Usuario usuario = new LógicaNegocio_Usuario();

            bool existe = usuario.LoginUsuario(TxtBox_Usuario.Text, TxtBox_Contraseña.Text);

            if (existe)
            {
                FrmClientes form = new FrmClientes(TxtBox_Usuario.Text);
                this.Hide();
                form.Show();
                Intentos = 3;
            }
            else
            {
                Intentos--;
                MessageBox.Show("Usuario o contraseña incorrectos, ¡asegúrate de que estén bien escritos!");
            }

            if (Intentos == 0)
            {
                TxtBox_Usuario.Enabled = false;
                TxtBox_Contraseña.Enabled = false;
                Btn_VerContraseña.Enabled = false;
                Btn_NoVerContraseña.Enabled = false;
                Btn_Login.Enabled = false;
                Btn_Crear.Enabled = false;
                Btn_Cerrar.Enabled = false;
                ProgressBar_Fallos.Value = 0;
                Tiempo = 0;
                Lbl_TextoBarradeEspera.Text = "Espere unos 15 segundos...";
                Timer_ProgressBar.Start();
            }
        }

        private void Timer_ProgressBar_Tick(object sender, EventArgs e)
        {
            Tiempo++;
            ProgressBar_Fallos.Value = Math.Min(Tiempo, ProgressBar_Fallos.Maximum);

            if (Tiempo >= ProgressBar_Fallos.Maximum)
            {
                TxtBox_Usuario.Enabled = true;
                TxtBox_Contraseña.Enabled = true;
                Btn_VerContraseña.Enabled = true;
                Btn_NoVerContraseña.Enabled = true;
                Btn_Login.Enabled = true;
                Btn_Crear.Enabled = true;
                Btn_Cerrar.Enabled = true;
                Intentos = 3;
                ProgressBar_Fallos.Value = 0;
                Tiempo = 0;
                Lbl_TextoBarradeEspera.Text = "Puede intentar nuevamente";
                Timer_ProgressBar.Stop();
            }
        }

        private void ProgressBar_Fallos_Click(object sender, EventArgs e)
        {

        }

        private void Btn_VerContraseña_Click(object sender, EventArgs e)
        {
            if (TxtBox_Contraseña.PasswordChar == '*')
            {
                TxtBox_Contraseña.PasswordChar = '\0';
                Btn_NoVerContraseña.BringToFront();
            }
        }

        private void Btn_NoVerContraseña_Click(object sender, EventArgs e)
        {
            if (TxtBox_Contraseña.PasswordChar == '\0')
            {
                TxtBox_Contraseña.PasswordChar = '*';
                Btn_VerContraseña.BringToFront();
            }
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
