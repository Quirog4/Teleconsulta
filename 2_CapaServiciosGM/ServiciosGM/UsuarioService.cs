using _2_CapaServiciosGM.InterfaceGM;
using _3_CapaAccesoDatos;
using _3_CapaAccesoDatos.DAL;
using _3_CapaAccesoDatos.IDAL;
using System;

namespace _2_CapaServiciosGM.ServiciosGM
{
    public class UsuarioService : IUsuarioService
    {
        public TFAT_USUARIO validaUsuario(string user, string pass)
        {
            try
            {
                TFAT_USUARIO usuario = new TFAT_USUARIO();
                IUsuarioDAL usuarioDAL = new UsuarioDAL();

                usuario = usuarioDAL.getUsuario(user);
                if (usuario.SUSU_PASSWORD.Equals(pass))
                {
                    return usuario;
                }
                return new TFAT_USUARIO();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
