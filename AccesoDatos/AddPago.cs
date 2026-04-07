using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AddPago
    {
        ConexiónBDD conexiónBDD = new ConexiónBDD();
        public int InsertarPago(Pagos DatosPagos, SqlConnection conexion, SqlTransaction transaccion)
         {         
               string Consulta = @"INSERT INTO Pagos (IdCuota, FechaPago, MontoPagado, MoraAplicada) VALUES (@IdCuota, @FechaPago, @MontoPagado, @MoraAplicada)";

                SqlCommand AgregarPago = new SqlCommand(Consulta, conexion, transaccion);

                AgregarPago.Parameters.AddWithValue("@IdCuota", DatosPagos.IdCuota);
                AgregarPago.Parameters.AddWithValue("@FechaPago", DatosPagos.FechaPago);
                AgregarPago.Parameters.AddWithValue("@MontoPagado", DatosPagos.MontoPagado);

                if (DatosPagos.MoraAplicada.HasValue)
                {
                    AgregarPago.Parameters.AddWithValue("@MoraAplicada", DatosPagos.MoraAplicada);
                }
                else
                {
                    AgregarPago.Parameters.AddWithValue("@MoraAplicada", DBNull.Value);
                }

                return AgregarPago.ExecuteNonQuery();
            }
        }
    }


