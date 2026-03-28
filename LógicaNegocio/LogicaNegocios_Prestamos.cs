using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LógicaNegocio
{
    public class LogicaNegocios_Prestamos
    {
        PrestamosDatos Prestamo = new PrestamosDatos();

        public decimal ConsultarFondoBanco()
        {
            return Prestamo.ObtenerFondoEmpresa();
        }

        public string ValidarReglas(decimal sueldo, decimal montoPedido, decimal FondoBanco, int cantidadMoras)
        {
            if (cantidadMoras >= 3) 
                return "DENEGADO: Cliente con 3 o más moras.";
            if (montoPedido > (sueldo * 4)) 
                return "DENEGADO: El monto excede 4 veces el sueldo mensual.";
            if (montoPedido >FondoBanco) 
                return "DENEGADO: El banco no tiene fondos suficientes.";


            return "OK";
        }

        public int ObtenerCantidadMoras(int idCliente)
        {
            return Prestamo.ContarMorasPorCliente(idCliente);
        }

        public decimal ObtenerTasaTEA(int meses)
        {
            if (meses >= 12)
                return 13.25m;
            if (meses > 12 && meses <= 24)
                return 15m;

            return 30m;
        }
        
        public double CalcularTEM(double teaAnual)
        {
            return Math.Pow(1 + (teaAnual / 100), 1.0 / 12.0) - 1;
        }

        public double CalcularCuotaFija(decimal principal, double tem, int meses)
        {
            double P = (double)principal;
            double i = tem;
            int n = meses;

            double cuotas = (P * i) / (1 - Math.Pow(1 + i, -n));
            return cuotas;
        }

        public List<Cuotas> GenerarCuotas(decimal MontoPrestamo, double tea, int meses)
        { 
            List<Cuotas> cuotas = new List<Cuotas>();

            double i = CalcularTEM(tea);
            double CuotaFija = CalcularCuotaFija(MontoPrestamo,i,meses);

            decimal SaldoAnterior = MontoPrestamo;

            for (int mes = 1; mes <= meses; mes++)
            {
                double InteresesDelMes = (double)SaldoAnterior * i;
                double AmortizacionCapital = CuotaFija - InteresesDelMes;
                decimal NuevoSaldo = SaldoAnterior - (decimal)AmortizacionCapital;

                cuotas.Add(new Cuotas
                {
                    NumeroDeCuota = mes,
                    MontoCuota = decimal.Round((decimal) CuotaFija, 2),
                    InteresCuota = decimal.Round((decimal) InteresesDelMes, 2),
                    AbonoCapital = decimal.Round((decimal) AmortizacionCapital, 2),
                    SaldoRemanente = decimal.Round(Math.Max(0, NuevoSaldo), 2)
                });

                SaldoAnterior = NuevoSaldo;
            
            }
            return cuotas;

        }
        public bool GuardarPrestamoCompleto(Préstamos p, List<Cuotas> lista)
        {
            return Prestamo.AddPrestamo(p, lista);
        }
        public List<Entidades.Clientes> ObtenerTodosLosClientes()
        {
            return Prestamo.ListarClientes();
        }


    }
}

