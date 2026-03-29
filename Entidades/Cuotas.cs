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
        public decimal MontoCuota { get; set; } // cambio a decimal
        public decimal InteresCuota { get; set; } // cambio a decimal
        public decimal AbonoCapital { get; set; } // cambio a decimal             
        public decimal SaldoRemanente { get; set; } // cambio a decimal
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; }
    }
}
