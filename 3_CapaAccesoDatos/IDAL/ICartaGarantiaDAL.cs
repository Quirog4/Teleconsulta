using _3_CapaAccesoDatos.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3_CapaAccesoDatos.Entidades;

namespace _3_CapaAccesoDatos.IDAL
{
    public interface ICartaGarantiaDAL
    {

        CartaGarantia_Result getCartaGarantia(int NroSolicitud);

        CartaGarantiaPS_Result getCartaGarantiaPS(int NroSolicitud, string departamento);

        IEnumerable<ListarCartas_Result> buscarCartas(string busqueda, string especialidad);

        IEnumerable<ListarCartasAuditor_Result> buscarCartasAuditor(string busqueda,
           string fecinicio, string fecfin, string tipoAt, string codEstado);

        IEnumerable<ListarCartasServicios_Result> buscarCartasServicios(string busqueda,
          string fecinicio, string fecfin, string tipoAt, string codEstado);

        bool auditaCarta(string importe, string estadoFinal, string obsMedicas, string obsInternas,
            string motivoestado, string usuario, string equipo, string diagnostico,
            List<string> procedimiento, BeneficioEntity beneficio,
             ArchivosXCodCarta_Result archivo, string departamento);

        int guardarCartaServicio(CartaGarantiaPS_Result cartaservicio, string usuario, string equipo, 
            List<string> codproced,  List<BeneficioEntity> beneficios,ArchivosXCodCarta_Result anexo );

        void eliminaProcedimiento(string codprocedimiento, string codsolicitud);
         }
    
}
