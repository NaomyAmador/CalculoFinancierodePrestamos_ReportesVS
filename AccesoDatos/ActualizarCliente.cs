using Entidades;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace AccesoDatos
{
    public class ActualizarCliente
    {
        ConexiónBDD conexiónBDD = new ConexiónBDD();
        public int ActualizarClientes(Clientes DatosClientes, SqlConnection conexion, SqlTransaction transaccion)
        {
            using (SqlConnection Conexión = conexiónBDD.ObtenerConexión())
            {
                string Consulta = @"UPDATE Clientes SET NombreCompleto = @NombreCompleto, Correo = @Correo, Direccion = @Direccion, Telefono = @Telefono, SueldoMensual = @SueldoMensual WHERE IdCliente = @IdCliente";


                SqlCommand ActualizarCliente =  new SqlCommand(Consulta, conexion, transaccion);

                ActualizarCliente.Parameters.AddWithValue("@IdCliente", DatosClientes.IdCliente);
                ActualizarCliente.Parameters.AddWithValue("@NombreCompleto", DatosClientes.NombreCompleto);
                ActualizarCliente.Parameters.AddWithValue("@Correo", DatosClientes.Correo);
                ActualizarCliente.Parameters.AddWithValue("@Direccion", DatosClientes.Direccion);
                ActualizarCliente.Parameters.AddWithValue("@Telefono", DatosClientes.Telefono);
                ActualizarCliente.Parameters.AddWithValue("@SueldoMensual", DatosClientes.SueldoMensual);

                return ActualizarCliente.ExecuteNonQuery();
            }
        }
    }
}

                              
           
        

    

