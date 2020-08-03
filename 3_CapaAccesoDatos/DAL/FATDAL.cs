using _3_CapaAccesoDatos.BD;
using _3_CapaAccesoDatos.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_CapaAccesoDatos.DAL
{
    public class FATDAL : BaseContextFAT, IFATDAL
    {
        public TFAT_ATENCION getFat(int idFat)
        {
            try
            {
                TFAT_ATENCION fat = new TFAT_ATENCION();
                fat = _context.TFAT_ATENCION.Where(f=> f.CFAT_ID_ATENCION==idFat).FirstOrDefault();
                return fat;
            }
            catch (Exception e)
            {

                return new TFAT_ATENCION();
            }
        }

        public int guardarFat(TFAT_ATENCION fat, string fecultate, int modalidad, int tipoaten)
        {
            throw new NotImplementedException();
        }

        public List<PRFAT_ListarTeleconsulta_Result> listaFatMedico(string fecinicio, string fecfin, string cmp)
        {
            try
            {
                List<PRFAT_ListarTeleconsulta_Result> lista = new List<PRFAT_ListarTeleconsulta_Result>();

                lista = _context.PRFAT_ListarTeleconsulta(fecinicio, fecfin, cmp).ToList();
                return lista;
            }
            catch (Exception e)
            {

            return new List<PRFAT_ListarTeleconsulta_Result>();
            }
        }
    }
}
