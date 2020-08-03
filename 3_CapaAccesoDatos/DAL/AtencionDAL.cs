using _3_CapaAccesoDatos.BD;
using _3_CapaAccesoDatos.IDAL;
using CapaSoporte.Cache;
using CapaSoporte.LogAplicacion;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3_CapaAccesoDatos.BD.BaseContextHCD;

namespace _3_CapaAccesoDatos.DAL
{
    public class AtencionDAL : BaseContextHCD, IAtencionDAL
    {
        public IEnumerable<DetalleAtenciones_Result> detAtencion(string hcu, string ip, string user, string paciente)
        {
            List<DetalleAtenciones_Result> detatc = new List<DetalleAtenciones_Result>();
            try
            {
                var lista = _context.PRHCD_ATENCIONES(hcu, UserLoginCache.IpAddress, UserLoginCache.audUser, paciente).ToList();
                for (int i = 0; i < lista.Count; i++)
                {
                    detatc.Add(lista[i]);
                }
                return detatc;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "hcu:"+ hcu+
                    "paciente:" + paciente,
                    ruta_sp: "Capa AccesoDatos : PRHCD_ATENCIONES",
                    detalle: e.Message,
                    mensaje: e.ToString());
                Control.mensaje = "Ocurrio un error al traer listar las atenciones; porfavor comuníquese con el administrador del sistema.";
                Control.bug = true;
            }
            return detatc;
        }
    }
}
