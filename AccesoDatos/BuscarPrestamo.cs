using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class BuscarPrestamo
    {
      
        ConexiónBDD conexionBDD = new ConexiónBDD();

        public int ObtenerIdPrestamo(string usuario, string nombreCliente)
        {
            using (SqlConnection conexion = conexionBDD.ObtenerConexión())
            {
                string consulta = @"
                SELECT TOP 1 p.IdPrestamo
                FROM Prestamos p
                INNER JOIN Clientes c ON p.IdCliente = c.IdCliente
                INNER JOIN User_Login u ON p.IdUsuario = u.IdUsuario
                WHERE LTRIM(RTRIM(u.usuario)) = LTRIM(RTRIM(@usuario))
                AND c.NombreCompleto LIKE @nombre";

                SqlCommand cmd = new SqlCommand(consulta, conexion);

                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@nombre", "%" + nombreCliente + "%");

              object resultado = cmd.ExecuteScalar();

                if (resultado != null)
                    return (int)resultado;

                return 0;
            }
        }
    }

}

