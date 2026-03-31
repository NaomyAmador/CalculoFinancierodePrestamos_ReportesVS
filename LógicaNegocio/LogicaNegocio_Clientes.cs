using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LógicaNegocio
{
    public class LogicaNegocio_Clientes
    {
        AddCliente DatosNecesariosCliente = new AddCliente();
        public void RegistrarCliente(Clientes DatosClientes)
        {
            if (string.IsNullOrWhiteSpace(DatosClientes.NombreCompleto) || string.IsNullOrWhiteSpace(DatosClientes.Correo))
                throw new Exception("¡Debe llenar todos los datos para continuar!");

            DatosNecesariosCliente.InsertarCliente(DatosClientes);
        }
    }
}
    