using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;

namespace LógicaNegocio
{
    public  class LogicaNegocio_HistorialPrestamos
    {
        ValidarCliente validarCliente = new ValidarCliente();
        HistorialPrestamos historialPrestamos = new HistorialPrestamos();

        public List<Préstamos> VerHistorialPrestamos(int idCliente)
        {
            bool existeCliente = validarCliente.ValidarClientes(idCliente);

            if (!existeCliente)
            {
                throw new Exception("El cliente no existe.");
            }
            else
            {

                List<Préstamos> historial = historialPrestamos.ObtenerHistorialPrestamos(idCliente);

                return historial;
            }
        }

    }
}
