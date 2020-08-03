using _3_CapaAccesoDatos.BD;
using _3_CapaAccesoDatos.IDAL;
using CapaSoporte.Cache;
using CapaSoporte.LogAplicacion;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.DAL
{
    public class ArchivoCGDAL : BaseContextCRPCG, IArchivoCGDAL
    {
        public bool eliminaArchivo(int id)
        {
            try
            {
                 _context.PRGUR_ELIMINA_ARCHIVOS(id);
                return true;
            }
            catch (Exception e)
            {

                new LOG(tipo: "Error",
                    parametros: "idArchivo:" + id,
                    ruta_sp: "Capa AccesoDatos : PRGUR_getArchivosXCarta",
                    detalle: e.Message,
                    mensaje: e.ToString());
                return false;
            }
        }

        public ArchivosXCodCarta_Result getArchivoAuditor(int idsolicitud)
        {

            ArchivosXCodCarta_Result archivos = new ArchivosXCodCarta_Result();
            try
            {
                archivos = _context.PRGUR_getArchivosXCarta(idsolicitud, "%").ToList()
                            .Where(a => a.Origen == "AUDITORIAPS").FirstOrDefault();
            }
            catch (Exception e)
            {

                new LOG(tipo: "Error",
                    parametros: "idsolicitud: " + idsolicitud,
                    ruta_sp: "Capa AccesoDatos : PRGUR_getArchivosXCarta",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar acceder la información, porfavor intentelo más tarde o comuniquede con el administrador del sistema";

            return archivos;
        }

        public List<ArchivosXCodCarta_Result> getArchivos(int idsolicitud, string codsolicitud)
        {
            IEnumerable<ArchivosXCodCarta_Result> archivos = new List<ArchivosXCodCarta_Result>();
            try
            {
                archivos = _context.PRGUR_getArchivosXCarta(idsolicitud, codsolicitud)//;
                          .ToList();

            }
            catch (Exception e)
            {

                new LOG(tipo: "Error",
                    parametros: "idsolicitud:" + idsolicitud
                    + "codsolicitud:" + codsolicitud,
                    ruta_sp: "Capa AccesoDatos : PRGUR_getArchivosXCarta",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar acceder a la información, porfavor intentelo más tarde o comuniquede con el administrador del sistema";
            return archivos.ToList();
        }

        public bool guardaArchivoFAT(ArchivosXCodCarta_Result archivo)
        {
            try
            {
                _context.PRGUR_Guarda_ArchivoFAT(
                    i_IdFAT: archivo.IdArchivo,
                    i_OAA: archivo.codSolicitud,
                    i_Archivo: archivo.Archivo,
                    i_Tipo: archivo.TipoArchivo,
                    i_User: UserLoginCache.User);
                return true;
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
                new LOG(tipo: "Error",
                    parametros: "ARCHIVO",
                    ruta_sp: "Capa AccesoDatos : PRCGA_GUARDA_ARCHIVOS",
                    detalle: "Error al ingresar la informacion a la base de datos",
                    mensaje: e);
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                      parametros: "ARCHIVO",
                      ruta_sp: "Capa AccesoDatos : PRCGA_GUARDA_ARCHIVOS",
                      detalle: e.Message,
                      mensaje: e.ToString());
                
            }
            return false;
        }

        public bool guardarArchivo(ArchivosXCodCarta_Result archivo, string usuario, string ip)
        {
            try
            {
                _context.PRGUR_GUARDA_ARCHIVOS(
                    id_carta: archivo.IdArchivo,
                    id_Solcarta: archivo.codSolicitud,
                    is_archivo: archivo.Archivo,
                    is_ctipo: (archivo.TipoArchivo != "") ? archivo.TipoArchivo : "OD",
                    iS_nomarchivo: archivo.NombreArchivo,
                    is_vp_equipo: UserLoginCache.IpAddress,
                    is_vp_usuario: UserLoginCache.audUser,
                    is_Origen:archivo.Origen ?? ""                    );
                return true;
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
                new LOG(tipo: "Error",
                    parametros: "ARCHIVO",
                    ruta_sp: "Capa AccesoDatos : PRCGA_GUARDA_ARCHIVOS",
                    detalle: "Error al ingresar la informacion a la base de datos",
                    mensaje: e);
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                      parametros: "ARCHIVO",
                      ruta_sp: "Capa AccesoDatos : PRCGA_GUARDA_ARCHIVOS",
                      detalle: e.Message,
                      mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar guardar la información, porfavor intentelo más tarde o comuniquede con el administrador del sistema";
            return false;
        }
    }
}
