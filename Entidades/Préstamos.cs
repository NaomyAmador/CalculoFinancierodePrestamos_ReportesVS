using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Préstamos
    {
        public int IdPrestamo { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public decimal MontoCapital { get; set; } // cambio a decimal
        public int PlazoMeses { get; set; }
        public decimal TasaInteresAplicada { get; set; }
        public decimal MontoTotal { get; set; } // cambio a decimal
        public string Garantia { get; set; }
        public DateTime Fecha { get; set; }
    }
}
