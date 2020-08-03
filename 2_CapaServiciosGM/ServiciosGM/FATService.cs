using _2_CapaServiciosGM.InterfaceGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3_CapaAccesoDatos.IDAL;
using _3_CapaAccesoDatos.DAL;
using _3_CapaAccesoDatos;

namespace _2_CapaServiciosGM.ServiciosGM
{
    public class FATService : IFATService
    {
        public TFAT_ATENCION getTeleconsulta(int id)
        {
            try
            {
                TFAT_ATENCION _atencion = new TFAT_ATENCION();

                IFATDAL _dal = new FATDAL();
                _atencion = _dal.getFat(id);
                return _atencion;
            }
            catch (Exception e)
            {
                return new TFAT_ATENCION();
            }
        }

        public List<PRFAT_ListarTeleconsulta_Result> listaFAT(string fecinicio, string fecfin, string cmp)
        {
            try {
                List<PRFAT_ListarTeleconsulta_Result> lista = new List<PRFAT_ListarTeleconsulta_Result>();
                IFATDAL _dal = new FATDAL();
                lista = _dal.listaFatMedico(fecinicio,fecfin,cmp);
                return lista;
            } catch (Exception e) {
                return new List<PRFAT_ListarTeleconsulta_Result>();
            }
        }
    }

}
