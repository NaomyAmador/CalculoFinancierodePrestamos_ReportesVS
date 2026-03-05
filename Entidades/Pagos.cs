using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pagos
    {
        public int IdPagos { get; set; }
        public int IdCuota { get; set; }
        public DateTime FechaPago { get; set; }
        public int MontoPagado { get; set; }
        public int? MoraAplicada { get; set; }
    }
}
