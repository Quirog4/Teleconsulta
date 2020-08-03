using _3_CapaAccesoDatos.BD;
using _3_CapaAccesoDatos.IDAL;
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
    public class EpicrisisDAL : IEspicrisiDAL
    {
        protected operacionesEntities _contextope;
        protected log4net.ILog log;

        public EpicrisisDAL()
        {
            _contextope = new operacionesEntities();
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public IEnumerable<T_EPI_DIAGNOSTICO> diagnosticosXinforme(int idinforme)
        {
            IEnumerable<T_EPI_DIAGNOSTICO> diagnosticos = new List<T_EPI_DIAGNOSTICO>();
            try
            {
                diagnosticos = _contextope.PRGUR_DIAGNOSTICOSxINF(idinforme).ToList();

            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                   parametros: "idinforme:" + idinforme,
                   ruta_sp: "Capa AccesoDatos : PRGUR_DIAGNOSTICOSxINF",
                   detalle: e.Message,
                   mensaje: e.ToString());
            }
            return diagnosticos;
        }

        public PRGUR_INFORMEPICR_Result getEpicrisis(string hcu, string fecha)
        {
            PRGUR_INFORMEPICR_Result entidad = new PRGUR_INFORMEPICR_Result();
            try
            {
                entidad = _contextope.PRGUR_INFORMEPICR(hcu, fecha).FirstOrDefault();
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                   parametros: "OIQx",
                   ruta_sp: "Capa AccesoDatos : PRGUR_ListarOIQx",
                   detalle: e.Message,
                   mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar traer la información, porfavor intentelo más tarde o comuniquede con el administrador del sistema";

            return entidad;
        }
    }
}
