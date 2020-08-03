using _3_CapaAccesoDatos.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.IDAL
{
    public interface IAtencionDAL
    {
        IEnumerable<DetalleAtenciones_Result> detAtencion(string hcu,string ip, string user, string paciente);
    }
}
