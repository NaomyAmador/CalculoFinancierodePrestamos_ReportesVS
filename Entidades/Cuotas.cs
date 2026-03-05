using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cuotas
    {
        public int IdCuota { get; set; }
        public int IdPrestamo { get; set; }
        public int NumeroDeCuota { get; set; }
        public int MontoCuota { get; set; }
        public decimal InteresCuota { get; set; }
        public int AbonoCapital { get; set; }
        public int SaldoRemanente { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; }
    }
}
