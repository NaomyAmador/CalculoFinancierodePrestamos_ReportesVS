using System;
using System.Data.SqlClient;


namespace AccesoDatos
{
    public class ValidarCliente
    {
        ConexiónBDD ConexionBD = new ConexiónBDD();
        public bool ValidarClientes(string IdCliente)
        {
            using (SqlConnection Conexión = ConexionBD.ObtenerConexión())
            {
                string Consulta = @"SELECT COUNT(*) FROM Clientes WHERE IdCliente = @IdCliente ";

                SqlCommand ValidarClienteExistente = new SqlCommand(Consulta, Conexión);
                ValidarClienteExistente.Parameters.AddWithValue("@IdCliente", IdCliente);
                
                int Validación = Convert.ToInt32(ValidarClienteExistente.ExecuteScalar());
                return Validación > 0;
            }

        }
    }
}
