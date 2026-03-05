using Entidades;
using LógicaNegocio;
using System;
using System.Windows.Forms;

namespace CálculoFinancierodePréstamos.Principal
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

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
            
        }
    }
}
