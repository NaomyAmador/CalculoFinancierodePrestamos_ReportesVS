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
                string Consulta = @"INSERT INTO User_Login (usuario, Contraseña) VALUES (@usuario, @Contraseña); SELECT SCOPE_IDENTITY();";

                SqlCommand AgregarUsuario = new SqlCommand(Consulta, Conexión);

                AgregarUsuario.Parameters.AddWithValue("@usuario", DatosUsuario.usuario);
                AgregarUsuario.Parameters.AddWithValue("@Contraseña", DatosUsuario.Contraseña);

                int IdAgregado = Convert.ToInt32(AgregarUsuario.ExecuteScalar());
                return IdAgregado;
            }
        }
        public User_Login ObtenerUsuarioPorCredenciales(string usuario, string contraseña)
        {
            using (SqlConnection conexion = conexiónBDD.ObtenerConexión())
            {
                string consulta = @"SELECT IdUsuario, usuario, Contraseña 
                            FROM User_Login 
                            WHERE usuario = @usuario AND Contraseña = @contraseña";

                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    User_Login user = new User_Login();
                    user.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    user.usuario = reader["usuario"].ToString();
                    user.Contraseña = reader["Contraseña"].ToString();

                    return user;
                }

                return null;
            }
        }






    }
}
