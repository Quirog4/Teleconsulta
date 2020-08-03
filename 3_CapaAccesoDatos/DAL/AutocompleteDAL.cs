using _3_CapaAccesoDatos.BD;
using _3_CapaAccesoDatos.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.DAL
{
    public class AutocompleteDAL : BaseContextFAT, IAutcompleteDAL
    {
        public List<PRFAT_Autocompletar_Result> listaDiagnostico(string term)
        {
            try
            {
                List<PRFAT_Autocompletar_Result> lista = new List<PRFAT_Autocompletar_Result>();

                lista = _context.PRFAT_Autocompletar(ConstanteDB.FiltroCIE,term).ToList();
                return lista;
            }
            catch (Exception e)
            {

                return new List<PRFAT_Autocompletar_Result>();
            }
        }

        public List<PRFAT_Autocompletar_Result> listaLaboratorio(string term)
        {
            try
            {
                List<PRFAT_Autocompletar_Result> lista = new List<PRFAT_Autocompletar_Result>();

                lista = _context.PRFAT_Autocompletar(ConstanteDB.FiltroLaboratorio, term).ToList();
                return lista;
            }
            catch (Exception e)
            {

                return new List<PRFAT_Autocompletar_Result>();
            }
        }

        public List<PRFAT_Autocompletar_Result> listaRadiologia(string term)
        {
            try
            {
                List<PRFAT_Autocompletar_Result> lista = new List<PRFAT_Autocompletar_Result>();

                lista = _context.PRFAT_Autocompletar(ConstanteDB.FiltroRadiologia, term).ToList();
                return lista;
            }
            catch (Exception e)
            {

                return new List<PRFAT_Autocompletar_Result>();
            }
        }
    }
}
