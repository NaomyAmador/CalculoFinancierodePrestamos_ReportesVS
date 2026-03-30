using Entidades;
using System;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class PrestamoPago
    {
        ConexiónBDD conexionBDD = new ConexiónBDD();

        public Préstamos ObtenerPrestamo(int idPrestamo)
        {
            using (SqlConnection conexion = conexionBDD.ObtenerConexión())
            {
                string consulta = "SELECT * FROM Prestamos WHERE IdPrestamo = @IdPrestamo";

                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Préstamos()
                    {
                        IdPrestamo = Convert.ToInt32(reader["IdPrestamo"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        MontoCapital = Convert.ToInt32(reader["MontoCapital"]),
                        PlazoMeses = Convert.ToInt32(reader["PlazoMeses"]),
                        TasaInteresAplicada = Convert.ToDecimal(reader["TasaInteresAplicada"]),
                        MontoTotal = Convert.ToInt32(reader["MontoTotal"])
                    };
                }

                return null;
            }
        }
       public int MarcarPrestamoFinalizado(int idPrestamo, SqlConnection conexion, SqlTransaction transaccion)
        {
            string consulta = @"UPDATE Prestamos 
                        SET Estado = 'Finalizado' 
                        WHERE IdPrestamo = @IdPrestamo";

            SqlCommand cmd = new SqlCommand(consulta, conexion, transaccion);
            cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);

            return cmd.ExecuteNonQuery();
        }

    }
}


