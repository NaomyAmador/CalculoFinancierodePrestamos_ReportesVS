using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moras
    {
        public int IdMora { get; set; }
        public int IdCliente { get; set; }
        public int IdCuota { get; set; }
        public decimal MontoMora { get; set; }
        public DateTime Fecha { get; set; }
    }
}
