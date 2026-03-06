using System;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class ValidaciónUsuario
    {
        ConexiónBDD conexiónBDD = new ConexiónBDD();
        public bool ValidarLogin(string usuario, string Contraseña)
        {
            using (SqlConnection Conexión = conexiónBDD.ObtenerConexión())
            {
                string Consulta = @"SELECT COUNT(*) FROM User_Login WHERE usuario = @usuario AND Contraseña = @Contraseña";

                SqlCommand LoginUsarioExistente = new SqlCommand(Consulta, Conexión);
                LoginUsarioExistente.Parameters.AddWithValue("@usuario", usuario);
                LoginUsarioExistente.Parameters.AddWithValue("@Contraseña", Contraseña);

                int Validación = Convert.ToInt32(LoginUsarioExistente.ExecuteScalar());
                return Validación > 0;
            }
        }
    }
}

