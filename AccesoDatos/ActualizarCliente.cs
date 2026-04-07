using Entidades;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace AccesoDatos
{
    public class ActualizarCliente
    {

        public int ActualizarClientes(Clientes DatosClientes, SqlConnection conexion, SqlTransaction transaccion)
        {
            string Consulta = @"UPDATE Clientes 
                        SET NombreCompleto = @NombreCompleto, 
                            Correo = @Correo, 
                            Direccion = @Direccion, 
                            Telefono = @Telefono, 
                            SueldoMensual = @SueldoMensual 
                        WHERE IdCliente = @IdCliente";

            SqlCommand comando = new SqlCommand(Consulta, conexion, transaccion);

            comando.Parameters.AddWithValue("@IdCliente", DatosClientes.IdCliente);
            comando.Parameters.AddWithValue("@NombreCompleto", DatosClientes.NombreCompleto);
            comando.Parameters.AddWithValue("@Correo", DatosClientes.Correo);
            comando.Parameters.AddWithValue("@Direccion", DatosClientes.Direccion);
            comando.Parameters.AddWithValue("@Telefono", DatosClientes.Telefono);
            comando.Parameters.AddWithValue("@SueldoMensual", DatosClientes.SueldoMensual);

            return comando.ExecuteNonQuery();
        }
    }
    
}

                              
           
        

    

