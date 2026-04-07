using System;
using System.Data.SqlClient;


namespace AccesoDatos
{
    public class ValidarCliente
    {
        ConexiónBDD ConexionBD = new ConexiónBDD();
        public bool ValidarClientes(int IdCliente)
        {
            using (SqlConnection conexion = ConexionBD.ObtenerConexión())
            {
                string Consulta = "SELECT COUNT(*) FROM Clientes WHERE IdCliente = @IdCliente";

                SqlCommand comando = new SqlCommand(Consulta, conexion);
                comando.Parameters.AddWithValue("@IdCliente", IdCliente);

                int cantidad = (int)comando.ExecuteScalar();

                return cantidad > 0;
            }

        }
    }
} 
