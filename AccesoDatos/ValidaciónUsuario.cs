using System;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class ValidaciónUsuario
    {
        ConexiónBDD conexiónBDD = new ConexiónBDD();
        public bool ValidarLogin(string Usuario, string Contraseña)
        {
            using (SqlConnection Conexión = conexiónBDD.ObtenerConexión())
            {
                Conexión.Open();
                string Consulta = @"SELECT COUNT(*) FROM User_Login WHERE Usuario = @Usuario AND Contraseña = @Contraseña";

                SqlCommand LoginUsarioExistente = new SqlCommand(Consulta, Conexión);
                LoginUsarioExistente.Parameters.AddWithValue("@Usuario", Usuario);
                LoginUsarioExistente.Parameters.AddWithValue("@Contraseña", Contraseña);

                int Validación = Convert.ToInt32(LoginUsarioExistente.ExecuteScalar());
                return Validación > 0;
            }
        }
    }
}

