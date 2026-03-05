using Entidades;
using System;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class AddUsuario
    {
        ConexiónBDD conexiónBDD = new ConexiónBDD();
        public int InsertarUsuario(User_Login DatosUsuario)
        {
            using (SqlConnection Conexión = conexiónBDD.ObtenerConexión())
            {
                Conexión.Open();
                string Consulta = @"INSERT INTO User_Login (usuario, Contraseña) VALUES (@usuario, @Contraseña); SELECT SCOPE_IDENTITY();";

                SqlCommand AgregarUsuario = new SqlCommand(Consulta, Conexión);

                AgregarUsuario.Parameters.AddWithValue("@usuario", DatosUsuario.Usuario);
                AgregarUsuario.Parameters.AddWithValue("@Contraseña", DatosUsuario.Contraseña);

                int IdAgregado = Convert.ToInt32(AgregarUsuario.ExecuteScalar());
                return IdAgregado;
            }
        }
    }
}
