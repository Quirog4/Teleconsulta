using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.IDAL
{
    public interface IOrdenIntQuirurgicaDAL
    {
        int guardarOrdenIQx(OIQirurgica_Result orden, List<string> equipos, List<string> diagnostico, List<string> cirugia, List<SuministrosxOIQuirurgica_Result> suministro,List<ArchivosXCodCarta_Result> archivos);

        List<ListarOIQx_Result> getListaOrdenes(string busqueda,string codespecialidad,string estado,
            string fechaini,string fechafin, bool cconfirmada);

        OIQirurgica_Result getOrdenQx(int idOrden);

        CartaOIQx_Result getCartaOrdenQx(int idOrden);

        List<CDESxOIQx_Result> listaCDESxIOQx(int idOrden, string Tipo);

        List<SuministrosxOIQuirurgica_Result> listaSuministroOQx(int idOrden);

        bool eliminaCDES(int id, string codigo, string tipo);

        bool eliminaOrden(int nroOrden,string codOrden);

        List<ListarCartasOIQxProgramador_Result> getListaCartasOrdenesProgramador(string codEstadoCG
             , string codEstadoReqPreQx, string fecinicio, string fecfin, bool qxprograma);

        List<ListarCartasOIQx_Result> getListaCartasOrdenes(string busqueda, string codEspecialidad,
           string codEstadoReqPreQx, string codtipocirugia, string fecinicio, string fecfin, bool reqpreqx);

        List<PreQuirurgicoxCartaOiqx_Result> preqxXcarta(int idCarta);

        bool guardarCartaOIQx(int idcarta,string codestado, string criterio, string observaciones,
            string fechacirugia, string sala, bool qxconfirmado,string tipo,string codtipoAnes);
        
    }
}
