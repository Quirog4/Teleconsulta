using _3_CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CapaServiciosGM.InterfaceGM
{
    public interface IFATService
    {
        List<PRFAT_ListarTeleconsulta_Result> listaFAT(string fecinicio,string fecfin, string cmp);
        TFAT_ATENCION getTeleconsulta(int id);
    }
}
