using Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class VerClientes
    {
        ConexiónBDD conexionBDD = new ConexiónBDD();
        public Clientes ObtenerClientePorId(int idCliente)
        {
            using (SqlConnection conexion = conexionBDD.ObtenerConexión())
            {
                string consulta = "SELECT * FROM Clientes WHERE IdCliente = @IdCliente";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IdCliente", idCliente);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    return new Clientes()
                    {
                        IdCliente = (int)reader["IdCliente"],
                        NombreCompleto = reader["NombreCompleto"].ToString(),
                        Correo = reader["Correo"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        SueldoMensual = (int)reader["SueldoMensual"]
                    };
                }

                return null;
            }
        }
    }
}