using _3_CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CapaServiciosGM.InterfaceGM
{
    public interface IUsuarioService
    {
        TFAT_USUARIO validaUsuario(string usuario, string pass);
    }
}
