using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.IDAL
{
    public interface IFATDAL
    {
        List<PRFAT_ListarTeleconsulta_Result> listaFatMedico(string fecinicio, string fecfin,string cmp);
        int guardarFat(TFAT_ATENCION fat, string fecultate, int modalidad, int tipoaten) ;
        TFAT_ATENCION getFat(int idFat);
    }
}
