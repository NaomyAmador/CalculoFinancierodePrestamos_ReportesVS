using System;

namespace Entidades
{
    public class Préstamos
    {
        public int IdPrestamo { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public decimal MontoCapital { get; set; }
        public int PlazoMeses { get; set; }
        public decimal TasaInteresAplicada { get; set; }
        public decimal MontoTotal { get; set; }
        public string Garantia { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
