using _3_CapaAccesoDatos.BD;
using _3_CapaAccesoDatos.IDAL;
using CapaSoporte.LogAplicacion;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.DAL
{
    public class ServicioAuxiliarDAL : BaseContextHCD, IServicioAuxiliarDAL
    {
        public List<ListDetServAux_Result> servicios(string nroAtencion)
        {
            List<ListDetServAux_Result> dser = new List<ListDetServAux_Result>();
            try
            {
               
                dser = _context.PRHCD_DETSERVAUX(nroAtencion).ToList();
                return dser;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "nro atencion"+nroAtencion,
                    ruta_sp: "Capa AccesoDatos : PRHCD_DETSERVAUX",
                    detalle: e.Message,
                    mensaje:e.ToString());
                Control.mensaje="Ocurrio un error al traer los servicios auxiliares; porfavor comuníquese con el administrador del sistema.";
                Control.bug = true;
            }
            return dser;
        }
    }
}
