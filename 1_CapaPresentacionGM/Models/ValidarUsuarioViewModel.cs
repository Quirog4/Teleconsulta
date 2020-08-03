using _2_CapaServiciosGM.DTO;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{

    public class ValidarUsuarioViewModel
    {
        public UsuarioSession ValidarUsuario(string usuario, string pass)
        {
            IValidacionUsuarioService _validarService = new ValidacionUsuarioService();
            UsuarioSession usuarioSesion = new UsuarioSession();
            usuarioSesion = _validarService.validaUsuario(usuario, pass);
            return usuarioSesion;
        }

        public bool CambiarContraseña(string usuario, string pass)
        {
            IValidacionUsuarioService _validarService = new ValidacionUsuarioService();
            return _validarService.cambiarContrasenia(usuario,pass);
        }
        //public void verificarUsuario() {
        //    IValidacionUsuarioService _validarService = new ValidacionUsuarioService();
        //    _validarService.validaUsuario();
        //}
    }
}