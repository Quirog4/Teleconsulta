using _3_CapaAccesoDatos.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.IDAL
{
    public interface IPacienteDAL 
    {
        IEnumerable<ListadoPacientes_Result> getPacientes(string hcd,string nombres);
        PacienteFAT_Result getPacienteFAT(string nrodoc);
    }
}
