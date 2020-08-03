using _3_CapaAccesoDatos.BD;
using _3_CapaAccesoDatos.DAL;
using CapaSoporte.LogAplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.IDAL
{
    public class PlanSaludDAL : BaseContextCRPCG, IPlanSaludDAL
    {
        public IEnumerable<BeneficiosProdecimientos_Result> beneficios(string nrosolicitud)
        {
            IEnumerable<BeneficiosProdecimientos_Result> listado = new List<BeneficiosProdecimientos_Result>();

            try
            {
                    listado = _context.PRGUR_getBenefYProcedxSolicitud(nrosolicitud).Where(x=> x.TIPO == ConstanteDB.TipoBeneficio);
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                   parametros: "nrosolicitud:"+nrosolicitud+"_tipo:BENEFICIOS",
                   ruta_sp: "Capa AccesoDatos : PRGUR_getBenefYProcedxSolicitud",
                   detalle: e.Message,
                   mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar mostrar los beneficios, porfavor intentelo más tarde o comuniquede con el administrador del sistema";

            return listado;
        }

        public IEnumerable<BeneficiosProdecimientos_Result> procedimientos(string nrosolicitud)
        {
            IEnumerable<BeneficiosProdecimientos_Result> listado = new List<BeneficiosProdecimientos_Result>();

            try
            {
                listado = _context.PRGUR_getBenefYProcedxSolicitud(nrosolicitud).Where(x => x.TIPO==ConstanteDB.TipoProcedimiento);
            }
            catch (Exception e)
            {

                new LOG(tipo: "Error",
                    parametros: "nrosolicitud:"+ nrosolicitud+ "_tipo:BENEFICIOS",
                    ruta_sp: "Capa AccesoDatos : PRGUR_getBenefYProcedxSolicitud",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar mostrar la informacion, porfavor intentelo más tarde o comuniquede con el administrador del sistema";

            return listado;
        }
    }
}
