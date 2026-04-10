using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    // Normalizar entradas
                    string usuarioTrim = (usuario ?? "").Trim();
                    string nombreTrim = (nombreCliente ?? "").Trim();

                    // Usar parámetros explícitos (evitar AddWithValue)
                    cmd.Parameters.Add("@usuario", System.Data.SqlDbType.NVarChar, 100).Value = usuarioTrim;
                    cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar, 200).Value = "%" + nombreTrim + "%";

                    // DEBUG: ver qué valores se envían (temporal)
                    // MessageBox.Show($"SQL param usuario='{usuarioTrim}', nombre='{(string)cmd.Parameters["@nombre"].Value}'");

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                        return Convert.ToInt32(resultado);

                    return 0;
                }
            }
        }

    }
}

