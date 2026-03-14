using AccesoDatos;
using Entidades;
using System;
using System.Data.SqlClient;
namespace LógicaNegocio
{
    public class LógicaNegocio_ActualizarCliente
    {
        ConexiónBDD conexionBDD = new ConexiónBDD();
        ActualizarCliente actualizarCliente = new ActualizarCliente();
        ValidarCliente validarCliente = new ValidarCliente();

        public int ActualizarAlCliente(Clientes clientes)
        {
            using (SqlConnection conexion = conexionBDD.ObtenerConexión())
            {
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    bool existeCliente = validarCliente.ValidarClientes(clientes.IdCliente);

                    if (!existeCliente)
                    {
                        throw new Exception("El cliente no existe.");
                    }

                    int resultado = actualizarCliente.ActualizarClientes(clientes, conexion, transaccion);

                    transaccion.Commit();

                    return resultado;
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }
    }
}



