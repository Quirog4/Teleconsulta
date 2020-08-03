using _3_CapaAccesoDatos.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.IDAL
{
     public interface IEspicrisiDAL
    {
        PRGUR_INFORMEPICR_Result getEpicrisis(string hcu, string fecha);
        IEnumerable<T_EPI_DIAGNOSTICO> diagnosticosXinforme(int idinforme);
    }
}
