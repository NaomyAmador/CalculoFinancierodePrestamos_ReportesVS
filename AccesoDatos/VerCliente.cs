using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class VerClientes
    {
        ConexiónBDD conexionBDD = new ConexiónBDD();
        public Clientes ObtenerClientePorId(int idCliente)
        {
            using (SqlConnection conexion = conexionBDD.ObtenerConexión())
            {
                string consulta = "SELECT * FROM Clientes WHERE IdCliente = @IdCliente";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IdCliente", idCliente);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    return new Clientes()
                    {
                        IdCliente = (int)reader["IdCliente"],
                        NombreCompleto = reader["NombreCompleto"].ToString(),
                        Correo = reader["Correo"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        SueldoMensual = (decimal)reader["SueldoMensual"]
                    };
                }

                return null;
            }
        }

        public DataTable ObtenerDatosReportePorNombreUsuario(string nombreUsuario)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = conexionBDD.ObtenerConexión())
            {             
                string query = @"SELECT 
                            C.IdCliente,
                            C.NombreCompleto, 
                            C.Telefono as DNI, 
                            C.SueldoMensual,
                            P.MontoCapital, 
                            P.PlazoMeses, 
                            P.TasaInteresAplicada, 
                            P.MontoTotal
                         FROM User_Login U
                         INNER JOIN Clientes C ON U.IdUsuario = C.IdUsuario
                         INNER JOIN Prestamos P ON C.IdCliente = P.IdCliente
                         WHERE U.usuario = @nombreUser";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombreUser", nombreUsuario);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable ObtenerDatosReportePorIdCliente(int idCliente)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conexion = conexionBDD.ObtenerConexión())
            {
                string query = @"SELECT 
                            C.IdCliente,
                            C.NombreCompleto,
                            C.Correo,
                            C.Telefono,
                            C.Direccion,
                            C.SueldoMensual,
                            P.IdPrestamo,
                            P.MontoCapital,
                            P.PlazoMeses,
                            P.TasaInteresAplicada,
                            P.MontoTotal,
                            P.Estado
                         FROM Clientes C
                         LEFT JOIN Prestamos P ON C.IdCliente = P.IdCliente
                         WHERE C.IdCliente = @IdCliente";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }
    }






}

 