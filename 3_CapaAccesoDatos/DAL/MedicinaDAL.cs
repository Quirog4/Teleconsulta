using _3_CapaAccesoDatos.BD;
using _3_CapaAccesoDatos.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.DAL
{
    public class MedicinaDAL : BaseContextHCD, IMedicinaDAL
    {

        public List<ListMedicinasXAte_Result> medicinas(string nroAtencion)
        {
            try
            {
                List<ListMedicinasXAte_Result> msa = new List<ListMedicinasXAte_Result>();
                msa = _context.PRHCD_MEDICINAxAte(nroAtencion).ToList();
                return msa;
            }
            catch (Exception e)
            {
                log.Error("MedicinaDAL->servicios() : PRHCD_MEDICINAxAte__" + e.Message + "____________________________\n" + e.ToString());
                new LOG("Error", "", "MedicinaDAL->servicios() : PRHCD_MEDICINAxAte__", e.Message, e.ToString());
            }
            return null;
        }


    }
}
