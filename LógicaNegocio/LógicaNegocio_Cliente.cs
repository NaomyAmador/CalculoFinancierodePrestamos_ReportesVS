using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;

namespace LógicaNegocio
{
    public class LogicaNegocio_Cliente
    {
        VerClientes datos = new VerClientes();
        public Clientes ObtenerClientePorId(int id)
        {
            if (id <= 0)
                throw new Exception("El ID no es válido.");

            Clientes cliente = datos.ObtenerClientePorId(id);

            if (cliente == null)
                throw new Exception("Cliente no encontrado.");

            return cliente;
        }
    }


}

