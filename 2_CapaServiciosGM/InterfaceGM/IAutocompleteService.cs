using _3_CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CapaServiciosGM.InterfaceGM
{
    public interface IAutocompleteService
    {
        List<PRFAT_Autocompletar_Result> listaDiagnostico(string term);
        List<PRFAT_Autocompletar_Result> listaLaboratorio(string term);
        List<PRFAT_Autocompletar_Result> listaRadiologia(string term);
    }
}
