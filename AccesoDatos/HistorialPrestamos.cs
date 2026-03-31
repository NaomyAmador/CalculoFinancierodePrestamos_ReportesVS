using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class HistorialPrestamos

    {
        ConexiónBDD conexionBDD = new ConexiónBDD();

        public List<Préstamos> ObtenerHistorialPrestamos(int idCliente)
        {
            List<Préstamos> listaPrestamos = new List<Préstamos>();

            using (SqlConnection conexion = conexionBDD.ObtenerConexión())
            {
                string consulta = @"SELECT IdPrestamo, IdCliente, IdUsuario, MontoCapital, PlazoMeses,TasaInteresAplicada, MontoTotal,  
                                    Garantia, Fecha, Estado FROM Prestamos WHERE IdCliente = @IdCliente ORDER BY Fecha";


                SqlCommand comando = new SqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdCliente", idCliente);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Préstamos prestamo = new Préstamos();

                    prestamo.IdPrestamo = (int)reader["IdPrestamo"];
                    prestamo.IdCliente = (int)reader["IdCliente"];
                    prestamo.IdUsuario = (int)reader["IdUsuario"];
                    prestamo.MontoCapital = (decimal)reader["MontoCapital"];
                    prestamo.PlazoMeses = (int)reader["PlazoMeses"];
                    prestamo.TasaInteresAplicada = (decimal)reader["TasaInteresAplicada"];
                    prestamo.MontoTotal = (decimal)reader["MontoTotal"];
                    prestamo.Garantia = reader["Garantia"].ToString();
                    prestamo.Fecha = (System.DateTime)reader["Fecha"];
                    prestamo.Estado = (string)reader["Estado"];

                    listaPrestamos.Add(prestamo);
                }

                return listaPrestamos;
            }
        }

    }
}
