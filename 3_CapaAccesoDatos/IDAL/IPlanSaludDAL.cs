using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.IDAL
{
    public interface IPlanSaludDAL
    {
         IEnumerable<BeneficiosProdecimientos_Result> beneficios(string nrosolicitud);
         IEnumerable<BeneficiosProdecimientos_Result> procedimientos(string nrosolicitud);
    }
}
