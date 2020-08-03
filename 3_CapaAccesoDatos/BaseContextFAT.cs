using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.BD
{

    public class BaseContextFAT
    {
        protected FAT_CRPEntities _context;
        protected log4net.ILog log;

        protected BaseContextFAT()
        {
            _context = new FAT_CRPEntities();
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

    }

}
