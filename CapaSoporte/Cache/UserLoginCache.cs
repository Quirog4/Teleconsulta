using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaSoporte.Cache
{
    public static class UserLoginCache
    {
        public static string NombreCompleto { get; set; }
        public static string audUser { get; set; }
        public static string User { get; set; }
        public static string Password { get; set; }
        public static string CMP { get; set; }
        public static int TipoUsuario { get; set; }
        public static string IpAddress { get; set; }
        public static bool changePass { get; set; }
        public static void LoginOut()
        {
            UserLoginCache.NombreCompleto = "";
            UserLoginCache.audUser = null;
            UserLoginCache.User = null;
            UserLoginCache.Password = null;
            UserLoginCache.IpAddress = null;
            //quitar permisos
            PermisosSKA.FatRadiologia = 0;
            PermisosSKA.FatLaboratorio = 0;
            PermisosSKA.ServicioPS = 0;
            PermisosSKA.BuscarCG = 0;
            UserLoginCache.changePass = false;

        }

    }
}