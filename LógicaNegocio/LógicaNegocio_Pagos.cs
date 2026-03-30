using AccesoDatos;
using Entidades;
using System;
using System.Data.SqlClient;

namespace LógicaNegocio
{
    public class LógicaNegocio_Pagos
    {
        CuotasParaPago cuotaAD = new CuotasParaPago();
        PrestamoPago prestamoAD = new PrestamoPago();
        AddPago pagoAD = new AddPago();
        ConexiónBDD conexionBDD = new ConexiónBDD();

        public void ProcesarPago(int idPrestamo)
        {
            using (SqlConnection conexion = conexionBDD.ObtenerConexión())
            {
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                   
                    var cuota = cuotaAD.ObtenerCuotaPendiente(idPrestamo);

                    if (cuota == null)
                        throw new Exception("Préstamo ya pagado completamente.");

                    var prestamo = prestamoAD.ObtenerPrestamo(idPrestamo);

                    int montoBase = cuota.MontoCuota;
                    int mora = 0;

                   
                    if (DateTime.Now > cuota.FechaVencimiento)
                    {
                        mora = (int)(montoBase * 0.10);
                    }

                    int totalPagar = montoBase + mora;

                                        
                    Pagos pago = new Pagos()
                    {
                        IdCuota = cuota.IdCuota,
                        FechaPago = DateTime.Now,
                        MontoPagado = totalPagar,
                        MoraAplicada = mora > 0 ? (int?)mora : null
                    };

                    
                    pagoAD.InsertarPago(pago, conexion, transaccion);


                    if (mora > 0)
                    {
                        Moras nuevaMora = new Moras()
                        {
                            IdCliente = prestamo.IdCliente,
                            IdCuota = cuota.IdCuota,
                            MontoMora = mora,
                            Fecha = DateTime.Now
                        };

                        new CuotasParaPago().InsertarMora(nuevaMora, conexion, transaccion);
                    }

                   
                    new CuotasParaPago().MarcarCuotaComoPagada(cuota.IdCuota, conexion, transaccion);

                    int cantidadMoras = cuotaAD.ContarMorasCliente(prestamo.IdCliente, conexion, transaccion);
                                                            
                    if (mora > 0)
                    {
                        Moras nuevaMora = new Moras()
                        {
                            IdCliente = prestamo.IdCliente,
                            IdCuota = cuota.IdCuota,
                            MontoMora = mora,
                            Fecha = DateTime.Now
                        };

                        cuotaAD.InsertarMora(nuevaMora, conexion, transaccion);
                    }

                    int CantidadMoras = cuotaAD.ContarMorasCliente(prestamo.IdCliente, conexion, transaccion);

                   
                    if (cantidadMoras >= 3 && !cuotaAD.EsClienteMoroso(prestamo.IdCliente, conexion, transaccion))
                    {
                        cuotaAD.MarcarComoMoroso(prestamo.IdCliente, conexion, transaccion);
                    }

                    int cuotasPendientes = cuotaAD.ContarCuotasPendientes(idPrestamo, conexion, transaccion);

                    if (cuotasPendientes == 0)
                    {
                        prestamoAD.MarcarPrestamoFinalizado(idPrestamo, conexion, transaccion);
                    }

                    transaccion.Commit();
                }

                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("Error en el pago: " + ex.Message);
                }
            }
        }
    }
}
