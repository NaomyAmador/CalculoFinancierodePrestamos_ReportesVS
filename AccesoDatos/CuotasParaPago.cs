using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class CuotasParaPago
    {
        ConexiónBDD conexionBDD = new ConexiónBDD();

        public Cuotas ObtenerCuotaPendiente(int idPrestamo )
        {
            using (SqlConnection conexion = conexionBDD.ObtenerConexión())
            {
                string consulta = @"SELECT TOP 1 * 
                                    FROM Cuotas 
                                    WHERE IdPrestamo = @IdPrestamo 
                                    AND Estado = 'Pendiente'
                                    ORDER BY NumeroDeCuota ASC";

                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Cuotas()
                    {
                        IdCuota = Convert.ToInt32(reader["IdCuota"]),
                        IdPrestamo = Convert.ToInt32(reader["IdPrestamo"]),
                        NumeroDeCuota = Convert.ToInt32(reader["NumeroDeCuota"]),
                        MontoCuota = Convert.ToDecimal(reader["MontoCuota"]),
                        InteresCuota = Convert.ToDecimal(reader["InteresCuota"]),
                        AbonoCapital = reader["AbonoCapital"] != DBNull.Value
                        ? Convert.ToDecimal(reader["AbonoCapital"]): 0,
                        SaldoRemanente = reader["SaldoRemanente"] != DBNull.Value
                        ? Convert.ToDecimal(reader["SaldoRemanente"]): 0,
                        FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"]),
                        Estado = reader["Estado"].ToString()
                    };
                }

                return null;
            }
        }

        public int MarcarCuotaComoPagada(int idCuota, SqlConnection conexion, SqlTransaction transaccion)
        {
            string consulta = @"UPDATE Cuotas 
                        SET Estado = 'Pagada'
                        WHERE IdCuota = @IdCuota";

            SqlCommand cmd = new SqlCommand(consulta, conexion, transaccion);
            cmd.Parameters.AddWithValue("@IdCuota", idCuota);

            return cmd.ExecuteNonQuery();
        }

        public int ContarCuotasPendientes(int idPrestamo, SqlConnection conexion, SqlTransaction transaccion)
        {
            string consulta = @"SELECT COUNT(*) 
                        FROM Cuotas 
                        WHERE IdPrestamo = @IdPrestamo 
                        AND Estado = 'Pendiente'";

            SqlCommand cmd = new SqlCommand(consulta, conexion, transaccion);
            cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);

            return (int)cmd.ExecuteScalar();
        }


        public int InsertarMora(Moras mora, SqlConnection conexion, SqlTransaction transaccion)
        {
            string consulta = @"INSERT INTO Moras (IdCliente, IdCuota, MontoMora, Fecha)
                        OUTPUT INSERTED.IdMora
                        VALUES (@IdCliente, @IdCuota, @MontoMora, @Fecha)";

            SqlCommand cmd = new SqlCommand(consulta, conexion, transaccion);

            cmd.Parameters.AddWithValue("@IdCliente", mora.IdCliente);
            cmd.Parameters.AddWithValue("@IdCuota", mora.IdCuota);
            cmd.Parameters.AddWithValue("@MontoMora", mora.MontoMora);
            cmd.Parameters.AddWithValue("@Fecha", mora.Fecha);

            return (int)cmd.ExecuteScalar(); 
        }

        public int ContarMorasCliente(int idCliente, SqlConnection conexion, SqlTransaction transaccion)
        {
            string consulta = "SELECT COUNT(*) FROM Moras WHERE IdCliente = @IdCliente";

            SqlCommand cmd = new SqlCommand(consulta, conexion, transaccion);
            cmd.Parameters.AddWithValue("@IdCliente", idCliente);

            return (int)cmd.ExecuteScalar();
        }


        public bool EsClienteMoroso(int idCliente, SqlConnection conexion, SqlTransaction transaccion)
        {
            string consulta = "SELECT EsMoroso FROM Clientes WHERE IdCliente = @IdCliente";

            SqlCommand cmd = new SqlCommand(consulta, conexion, transaccion);
            cmd.Parameters.AddWithValue("@IdCliente", idCliente);

            object resultado = cmd.ExecuteScalar();

            if (resultado == DBNull.Value || resultado == null)
                return false;

            return Convert.ToBoolean(resultado);
        }



        public int MarcarComoMoroso(int idCliente, SqlConnection conexion, SqlTransaction transaccion)
        {
            string consulta = @"UPDATE Clientes 
                        SET EsMoroso = 1 
                        WHERE IdCliente = @IdCliente";

            SqlCommand cmd = new SqlCommand(consulta, conexion, transaccion);
            cmd.Parameters.AddWithValue("@IdCliente", idCliente);

            return cmd.ExecuteNonQuery();
        }


    }
}
       
    
