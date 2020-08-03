using _3_CapaAccesoDatos.BD;
using _3_CapaAccesoDatos.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.DAL
{
    public class UsuarioDAL : BaseContextFAT, IUsuarioDAL
    {
        public TFAT_USUARIO getUsuario(string user)
        {
            try{
                TFAT_USUARIO entity = new TFAT_USUARIO();
                entity = _context.TFAT_USUARIO.Where(u=>u.SUSU_CODUSUARIO==user).FirstOrDefault();
                return entity;
            }
            catch (Exception e) {
                return new TFAT_USUARIO();
            }
        }
    }
}
