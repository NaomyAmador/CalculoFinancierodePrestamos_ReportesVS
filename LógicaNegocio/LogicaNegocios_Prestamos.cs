using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LógicaNegocio
{
    public class LogicaNegocios_Prestamos
    {
        PrestamosDatos Prestamo = new PrestamosDatos();

        public bool ValidarReglas(int sueldo, int monto, int FondoDisponible, int limiteSueldo, int cantidadMoras)
        {
            return monto <= (sueldo * 4);
        }

        public decimal ObtenerTasa(int meses)
        {
            if (meses >= 12)
                return 13.25m;
            if (meses > 12 && meses <= 24)
                return 15m;

            return 30m;
        }

        public decimal CalcularInteresSimple(decimal Capital, decimal TasaAnual, int meses)
        {
           double i = (double)(TasaAnual / 12 / 100);
           double n = meses;
           double P = (double)Capital;
           double InteresSimple = P * ( 1(i * Math.Pow(1 + i, n)) / (Math.Pow(1 + i, n) - 1) );
        //    return (decimal)cuota;

        //}
        //public List<Cuotas> GenerarCuotas(decimal CapitalOriginal, int meses)
        //{
        //    var ListarCuotas = new List<Cuotas>();

        //    decimal TasaAnual = ObtenerTasa(meses);
        //    decimal CuotaFija = CalcularMonto(CapitalOriginal, TasaAnual, meses);
        //    decimal TasaMensual = TasaAnual / 12 / 100;

        //    decimal SaldoPendiente = CapitalOriginal;

        //    for (int i = 1; i <= meses; i++)
        //    {
        //        decimal InteresdelMes = SaldoPendiente * TasaMensual;
        //        decimal AbonoalCapital = CuotaFija - InteresdelMes;
        //        SaldoPendiente -= AbonoalCapital;

        //        if (SaldoPendiente < 0 ) SaldoPendiente = 0;

        //        Cuotas NewCuota = new Cuotas()
        //        {
        //            NumeroDeCuota = i,
        //            MontoCuota = (int)Math.Round(CuotaFija),
        //            InteresCuota = InteresdelMes,
        //            AbonoCapital = (int)Math.Round(AbonoalCapital),
        //            SaldoRemanente = (int)Math.Round(SaldoPendiente),
        //            FechaVencimiento = DateTime.Now.AddMonths(i),
        //            Estado = "Pendiente"
        //        };
        //        ListarCuotas.Add(NewCuota);
        //    }
        //    return ListarCuotas;
        //}


    }
}

