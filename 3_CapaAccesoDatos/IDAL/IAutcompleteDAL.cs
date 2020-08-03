using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.IDAL
{
    public interface IAutcompleteDAL
    {
        List<PRFAT_Autocompletar_Result> listaLaboratorio(string term);
       List<PRFAT_Autocompletar_Result> listaRadiologia(string term);
       List<PRFAT_Autocompletar_Result> listaDiagnostico(string term);
    }
}
