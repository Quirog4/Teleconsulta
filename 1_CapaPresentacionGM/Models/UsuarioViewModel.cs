using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _1_CapaPresentacionGM.Models.Modelos;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;

namespace _1_CapaPresentacionGM.Models
{
    public class UsuarioViewModel
    {
        public UsuarioSessionModel ValidarUsuario(string usuario, string password)
        {
            IUsuarioService _service = new UsuarioService();
            var user=_service.validaUsuario(usuario,password);

            UsuarioSessionModel userSesion = new UsuarioSessionModel();
            if (user!=null) {
                userSesion = new UsuarioSessionModel
                 {
                     User = usuario,
                     UserId = user.SUSU_CODUSUARIO,
                 };
            }
            return userSesion;
        }
    }
}