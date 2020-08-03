using _3_CapaAccesoDatos.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.IDAL
{
    public interface IMedicinaDAL
    {
        List<ListMedicinasXAte_Result> medicinas(string nroAtencion);
    }
}
