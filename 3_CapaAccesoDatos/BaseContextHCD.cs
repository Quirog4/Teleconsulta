using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.BD
{
    public class BaseContextHCD
    {
        protected HCDigitalCRPEntities _context;
        protected log4net.ILog log;
        public string ErrorBD;

        protected BaseContextHCD()
        {
            _context = new HCDigitalCRPEntities();
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void getError(string error) {
            this.ErrorBD = error;
        }
    }
}
