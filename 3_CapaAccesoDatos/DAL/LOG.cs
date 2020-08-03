using _3_CapaAccesoDatos.BD;
using CapaSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.DAL
{
    public class LOG
    {
        public BD_CRPCGEntities _context;
        public log4net.ILog log;

        public LOG(string tipo,string parametros,string ruta_sp,string mensaje, string detalle)
        {
            _context = new BD_CRPCGEntities();
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            try
            {
                _context.PRGUR_LOG_DEBUG(
                    i_usuario: UserLoginCache.audUser,
                    i_data: parametros,
                    i_tipo: tipo,
                    i_MSJ:detalle,
                    i_Ref:mensaje,
                    i_sp:ruta_sp
                    );
            }
            catch (DbEntityValidationException ex)
            {
                string e = "";
                foreach (var error in ex.EntityValidationErrors)
                {
                    log.Error("====================Entity {0} in state {1} has validation errors:" +
                        error.Entry.Entity.GetType().Name + "--" + error.Entry.State);
                    e += "Parametro:" + error.Entry.Entity.GetType().Name;
                    e += "____Estado" + error.Entry.State;
                    foreach (var ve in error.ValidationErrors)
                    {
                        log.Error("\tProperty: {0}, Error: {1}" + ve.PropertyName + "----" + ve.ErrorMessage);
                        e += "_________________________________Mensaje" + ve.PropertyName + "----" + ve.ErrorMessage;
                    }
                }

            }
            catch (Exception e)
            {
                log.Error("Error al insertar log" + e.Message + "________" + e.ToString());
            }

        }
    }
}
