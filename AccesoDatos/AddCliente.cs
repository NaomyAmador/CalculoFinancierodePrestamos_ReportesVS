using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AddCliente
    {
        ConexiónBDD conexiónBDD = new ConexiónBDD();
        public int InsertarCliente(Clientes DatosClientes)
        {
            using (SqlConnection Conexión = conexiónBDD.ObtenerConexión())
            {
                string Consulta = @"INSERT INTO Clientes (IdUsuario, NombreCompleto, Correo, Direccion, Telefono, SueldoMensual) VALUES (@IdUsuario, @NombreCompleto, @Correo, @Direccion, @Telefono, @SueldoMensual ); SELECT SCOPE_IDENTITY();";

                SqlCommand AgregarCliente = new SqlCommand(Consulta, Conexión);

                AgregarCliente.Parameters.AddWithValue("@IdUsuario", DatosClientes.IdUsuario);
                AgregarCliente.Parameters.AddWithValue("@NombreCompleto", DatosClientes.NombreCompleto);
                AgregarCliente.Parameters.AddWithValue("@Correo", DatosClientes.Correo);
                AgregarCliente.Parameters.AddWithValue("@Direccion", DatosClientes.Direccion);
                AgregarCliente.Parameters.AddWithValue("@Telefono", DatosClientes.Telefono);
                AgregarCliente.Parameters.AddWithValue("@SueldoMensual", DatosClientes.SueldoMensual);
                //AgregarCliente.Parameters.AddWithValue("@IdMora", DatosClientes.IdMora);


                int IdAgregado = Convert.ToInt32(AgregarCliente.ExecuteScalar());
                return IdAgregado;
            }
        }
    }
}
