using AccesoDatos;
using Entidades;
using System;

namespace LógicaNegocio
{
    public class LógicaNegocio_Usuario
    {
        AddUsuario DatosNecesarios = new AddUsuario();
        ValidaciónUsuario Validación = new ValidaciónUsuario();
        public int CrearUsuario(User_Login UsuarioIngresado)
        {
            if (UsuarioIngresado.usuario == "" || UsuarioIngresado.Contraseña == "")
            {
                throw new Exception("Campos vacíos, ¡completa estos mismos antes de continuar con el proceso!");
            }
            return DatosNecesarios.InsertarUsuario(UsuarioIngresado);
        }

        public bool LoginUsuario(string Usuarioexistente, string ContrasenaExistente)
        {
            if (Usuarioexistente == "" || ContrasenaExistente == "")
            {
                throw new Exception("Campos vacíos, ¡completa estos mismos antes de continuar con el proceso!");
            }

            return Validación.ValidarLogin(Usuarioexistente, ContrasenaExistente);
        }
    }
}
