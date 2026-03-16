using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PrestamosDatos
    {
        ConexiónBDD con = new ConexiónBDD();
        public bool AddPrestamo(Préstamos p, List<Cuotas> cuotas)
        {
            using (SqlConnection Conexión = con.ObtenerConexión())
            {
                SqlTransaction transaccion = Conexión.BeginTransaction();
                try
                {
                    string Consulta1 = @"INSERT INTO Prestamos (IdCliente, IdUsuario, MontoCapital, plazoMeses, TasaInteresAplicada, MontoTotal, Garantia, Fecha) VALUES (@MontoCapital, @plazoMeses, @TasaInteresAplicada, @MontoTotal, @Garantia, @Fecha); SELECT SCOPE_IDENTITY();";
                    SqlCommand AgregarPrestamo = new SqlCommand(Consulta1, Conexión);

                    AgregarPrestamo.Parameters.AddWithValue("@IdCliente", p.IdCliente);
                    AgregarPrestamo.Parameters.AddWithValue("@IdUsuario", p.IdUsuario);
                    AgregarPrestamo.Parameters.AddWithValue("@MontoCapital", p.MontoCapital);
                    AgregarPrestamo.Parameters.AddWithValue("@plazoMeses", p.PlazoMeses);
                    AgregarPrestamo.Parameters.AddWithValue("@TasaInteresAplicada", p.TasaInteresAplicada);
                    AgregarPrestamo.Parameters.AddWithValue("@MontoTotal", p.MontoTotal);
                    AgregarPrestamo.Parameters.AddWithValue("@Garantia", p.Garantia);
                    AgregarPrestamo.Parameters.AddWithValue("@Fecha", DateTime.Now);

                    int IdPrestamoHecho = Convert.ToInt32(AgregarPrestamo.ExecuteScalar());

                    foreach (var c in cuotas)
                    {
                        string Consulta2 = @"INSERT INTO Cuotas (IdPrestamo, NumeroDeCuota, MontoCuota, InteresCuota, AbonoCapital, SaldoRemanente, FechaVencimiento, Estado) VALUES (@IdPrestamo, @NumeroDeCuota, @MontoCuota, @InteresCuota, @AbonoCapital, @SaldoRemanente, @FechaVencimiento, @Estado); SELECT SCOPE_IDENTITY();";
                        SqlCommand AgregarCuota = new SqlCommand(Consulta2, Conexión, transaccion);

                        AgregarCuota.Parameters.AddWithValue("@IdPrestamo", c.IdPrestamo);
                        AgregarCuota.Parameters.AddWithValue("@NUmeroDeCuota", c.NumeroDeCuota);
                        AgregarCuota.Parameters.AddWithValue("@MontoCuota", c.MontoCuota);
                        AgregarCuota.Parameters.AddWithValue("@InteresCuota", c.InteresCuota);
                        AgregarCuota.Parameters.AddWithValue("@AbonoCapital", c.AbonoCapital);
                        AgregarCuota.Parameters.AddWithValue("@SaldoRemanente", c.SaldoRemanente);
                        AgregarCuota.Parameters.AddWithValue("@FechaVencimiento", c.FechaVencimiento);
                        AgregarCuota.Parameters.AddWithValue("@Estado", "Pendiente");
                        AgregarCuota.ExecuteNonQuery();
                        
                        }

                        string Consulta3 = "UPDATE FondosDisponibles SET CantidadDisponible = CantidadDisponible - @monto";
                        SqlCommand Actualizar = new SqlCommand(Consulta3, Conexión, transaccion);
                        Actualizar.Parameters.AddWithValue("@Monto", p.MontoCapital);
                        Actualizar.ExecuteNonQuery();
                        transaccion.Commit();
                        return true;

                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    return false;
                }
               

            }
        }
         
    }
}
