using _3_CapaAccesoDatos.BD;
using _3_CapaAccesoDatos.IDAL;
using CapaSoporte.Cache;
using CapaSoporte.LogAplicacion;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3_CapaAccesoDatos.BD.BaseContextHCD;
using static _3_CapaAccesoDatos.Entidades;

namespace _3_CapaAccesoDatos.DAL
{
    public class CartaGarantiaDAL : BaseContextCRPCG, ICartaGarantiaDAL
    {
        public bool auditaCarta(string importe, string estadoFinal, string obsMedicas, string obsInternas,
            string motivoestado, string usuario, string equipo, string diagnostico,List<string> procedimiento,
             BeneficioEntity beneficio, ArchivosXCodCarta_Result archivo, string departamento)
        {
            try
            {
                _context.PRGUR_UPD_AUDITORIA_CARTA(
                                                i_Importe: importe,
                                                i_Diagnostico: diagnostico,
                                                i_NroSolicitud: archivo.codSolicitud,
                                                i_CodSolicitud: archivo.IdArchivo,
                                                i_Usuario: usuario,
                                                i_Equipo: equipo,
                                                i_estadoAuditar: estadoFinal,
                                                i_motivoEstado: motivoestado,
                                                i_observacionMedica: obsMedicas,
                                                i_observacionInterna: obsInternas,
                                                i_archivoCarta: archivo.Archivo,
                                                i_departamento: departamento,
                                                i_NombreArchivo: archivo.NombreArchivo);

                if (procedimiento.Count() > 0)
                {
                    string proc = "PROSE";
                    if (departamento == "BACKOFFICE")
                    {
                        proc = "PROBO";
                    }
                    foreach (var p in procedimiento)
                    {
                        if (p == "")
                        {
                            continue;
                        }
                        _context.PRGUR_GuardarBenefYProced_PS(
                                                            i_NroSolicitud: archivo.codSolicitud,
                                                            i_Usuario: usuario,
                                                            i_Equipo: equipo,
                                                            i_CorrelativoInt: archivo.IdArchivo,
                                                            i_cpfijo: "",
                                                            i_cpVariable: "",
                                                            i_flagSeleccion: 0,
                                                            i_Descripcion: "",
                                                            i_Codigo: p,
                                                            i_tipo: proc);
                    }

                }
                if (beneficio != null)
                {
                    _context.PRGUR_GuardarBenefYProced_PS(
                                                  i_NroSolicitud: archivo.codSolicitud,
                                                  i_Usuario: usuario,
                                                  i_Equipo: equipo,
                                                  i_CorrelativoInt: archivo.IdArchivo,
                                                  i_tipo:(beneficio.forzado)? "BENFO" : "BENUP",
                                                  i_Codigo: beneficio.codigo,
                                                  i_Descripcion: beneficio.Descripcion,
                                                  i_cpfijo: beneficio.cpFijo,
                                                  i_cpVariable: beneficio.cpVariable,
                                                  i_flagSeleccion: beneficio.seleccion);
                }
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
                       parametros: "AUDITORIACG",
                       ruta_sp: "Capa AccesoDatos : PRGUR_UPD_AUDITORIA_CARTA,PRGUR_GuardarBenefYProced_PS",
                       detalle: "Error al ingresar la informacion a la base de datos",
                       mensaje: e);
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                       parametros: "AUDITORIACG",
                       ruta_sp: "Capa AccesoDatos : PRGUR_UPD_AUDITORIA_CARTA,PRGUR_GuardarBenefYProced_PS",
                       detalle: e.Message,
                       mensaje: e.ToString());

            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar guardar la información, porfavor intentelo más tarde o comuniquede con el administrador del sistema";

            return false;
        }

        public IEnumerable<ListarCartas_Result> buscarCartas(string busqueda, string especialidad)
        {
            IEnumerable<ListarCartas_Result> listado = new List<ListarCartas_Result>();
            try
            {
                listado = _context.PRGUR_ListarCartas(busqueda, especialidad).ToList();
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "busqueda: "+ busqueda
                    + "__especialidad: " + especialidad,
                    ruta_sp: "Capa AccesoDatos : PRGUR_ListarCartas",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar listar las cartas, porfavor intentelo más tarde o comuniquede con el administrador del sistema";

            return listado;
        }

        public IEnumerable<ListarCartasAuditor_Result> buscarCartasAuditor(string busqueda, string fecinicio, string fecfin, string tipoAt, string codEstado)
        {
                IEnumerable<ListarCartasAuditor_Result> listado = new List<ListarCartasAuditor_Result>();
            try
            {
                listado = _context.PRGUR_ListarCartasAuditor(
                               i_sBusqueda: busqueda,
                               i_FInic: fecinicio,
                               i_FFin: fecfin,
                               i_CodEstado: codEstado,
                               i_TipoAt: tipoAt
                               ).ToList();
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                     parametros: "i_sBusqueda:"+ busqueda+
                               "__i_FInic:"+ fecinicio+
                               "__i_FFin:"+ fecfin+
                               "__i_CodEstado:" +codEstado+
                               "__i_TipoAt:"+ tipoAt,
                     ruta_sp: "Capa AccesoDatos : PRGUR_ListarCartasAuditor",
                     detalle: e.Message,
                     mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar listar las cartas, porfavor intentelo más tarde o comuniquede con el administrador del sistema";

            return listado;
        }

        public IEnumerable<ListarCartasServicios_Result> buscarCartasServicios(string busqueda, string fecinicio, string fecfin, string tipoAt, string codEstado)
        {
                IEnumerable<ListarCartasServicios_Result> listado = new List<ListarCartasServicios_Result>();
            try
            {
                listado = _context.PRGUR_ListarCartasServicios(
                               i_sBusqueda: busqueda,
                               i_FInic: fecinicio,
                               i_FFin: fecfin,
                               i_CodEstado: codEstado,
                               i_TipoAt: tipoAt).ToList();
            }
            catch (Exception e)
            {

                new LOG(tipo: "Error",
                     parametros: "i_sBusqueda:" + busqueda +
                               "__i_FInic:" + fecinicio +
                               "__i_FFin:" + fecfin +
                               "__i_CodEstado:" + codEstado +
                               "__i_TipoAt:" + tipoAt,
                     ruta_sp: "Capa AccesoDatos : PRGUR_ListarCartasAuditor",
                     detalle: e.Message,
                     mensaje: e.ToString());
            }
            return listado;
        }

        public CartaGarantia_Result getCartaGarantia(int NroSolicitud)
        {
                CartaGarantia_Result carta = new CartaGarantia_Result();
            try
            {
                carta = _context.PRGUR_getCarta(NroSolicitud).FirstOrDefault();
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "NroSolicitud:" + NroSolicitud,
                    ruta_sp: "Capa AccesoDatos : PRGUR_getCarta",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar mostrar la solicitud, porfavor intentelo más tarde o comuniquede con el administrador del sistema";

            return carta;
        }

        public CartaGarantiaPS_Result getCartaGarantiaPS(int codSolicitud, string departamento)
        {
                CartaGarantiaPS_Result carta = new CartaGarantiaPS_Result();
            try
            {
                carta = _context.PRGUR_getCartaPS(codSolicitud, departamento).FirstOrDefault();
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                     parametros: "codSolicitud:" + codSolicitud+
                    "_departamento: " + departamento,
                     ruta_sp: "Capa AccesoDatos : PRGUR_getCartaPS",
                     detalle: e.Message,
                     mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar mostrar la solicitud, porfavor intentelo más tarde o comuniquede con el administrador del sistema";

            return carta;
        }

        public int guardarCartaServicio(CartaGarantiaPS_Result cartaservicio, string usuario, string equipo, List<string> codproced, List<BeneficioEntity> beneficios, ArchivosXCodCarta_Result anexo)
        {
            try
            {
                IEnumerable<CARTASERVICIO_Result> solicitud = _context.PRGUR_GUARDAR_CARTASERVICIO(
                    i_tipodocto: cartaservicio.TipoDocto,
                    i_CorreoContacto: cartaservicio.correo,
                    i_Edad: cartaservicio.edad,
                    i_Contratante: cartaservicio.Contratante,
                    i_Equipo: equipo,
                    i_FAfiliacion: cartaservicio.PSFechaAfiliacion,
                    i_Fcontrato: cartaservicio.PSFechaContrato,
                    i_Finivigencia: cartaservicio.PSFechAVigencia,
                    i_HC_paciente: cartaservicio.historiaclinica,
                    i_idEspecialidad: cartaservicio.Especialidad,
                    i_idFinanciador: "",
                    i_ImporteCarta: cartaservicio.Importe,
                    i_Nom_Paciente: cartaservicio.nombrepaciente,
                    i_Usuario: usuario,
                    i_Num_Celular: cartaservicio.celular ?? "",//cartaservicio.nu
                    i_Num_Doc_Paciente: cartaservicio.docpaciente,
                    i_Num_Telefono: cartaservicio.nrotelefono,
                    i_PSdiagnostico: cartaservicio.Diagnostico,
                    i_PSTitular: cartaservicio.Titular,
                    i_PSDiashospitalizado: cartaservicio.DiasHospital,
                    i_PSEstadoContrato: cartaservicio.EstadoContratoPS,
                    i_PSMed_Tratante: cartaservicio.MedicoTratante,
                    i_PSObs_medTratante: cartaservicio.ObservMedicTrat,
                    i_PSParentesco: cartaservicio.Parentesco,
                    i_PSPlan: cartaservicio.PSPlan,
                    i_PSProducto: cartaservicio.PSProducto,
                    i_PSTiempo_dia: cartaservicio.TiempoDia,
                    i_PSTipoAtencion: cartaservicio.TipoAtencion,
                    i_PSTiempo_year: cartaservicio.TiempoAnio,
                    i_PSTiempo_Mes: cartaservicio.TiempoMes,
                    i_PSnumContrato: cartaservicio.NroContratoPS,
                    i_idSol_CarGarantia: "",
                    i_CodigoAfiliado: cartaservicio.CodAfiliado,
                    i_Fnacimiento: cartaservicio.FecNacPaciente,
                    i_Anexo: anexo.Archivo
                    );
                var codsolicitud = solicitud.FirstOrDefault();
                if (codproced != null)
                {
                    foreach (string c in codproced)
                    {
                        if (c == null) continue;
                        _context.PRGUR_GuardarBenefYProced_PS(
                            i_NroSolicitud: codsolicitud.cCAR_idSol_CarGarantia,
                            i_Usuario: usuario,
                            i_Equipo: equipo,
                            i_CorrelativoInt: codsolicitud.cCAR_CorrelativoInterno,
                            i_cpfijo: "",
                            i_cpVariable: "",
                            i_flagSeleccion: 0,
                            i_Descripcion: "",
                            i_Codigo: c,
                            i_tipo: "PROSE");
                    }

                }

                foreach (BeneficioEntity b in beneficios)
                {
                    if (b == null) continue;
                    _context.PRGUR_GuardarBenefYProced_PS(
                        i_NroSolicitud: codsolicitud.cCAR_idSol_CarGarantia,
                        i_Usuario: usuario,
                        i_Equipo: equipo,
                        i_CorrelativoInt: codsolicitud.cCAR_CorrelativoInterno,
                        i_tipo: "BENE",
                        i_Codigo: b.codigo,
                        i_Descripcion: b.Descripcion,
                        i_cpfijo: b.cpFijo,
                        i_cpVariable: b.cpVariable,
                        i_flagSeleccion: b.seleccion);
                }



                return codsolicitud.cCAR_CorrelativoInterno;
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
                    parametros: "CG SERVICIO:",
                    ruta_sp: "Capa AccesoDatos : PRGUR_getCartaPS",
                    detalle: e,
                    mensaje: e.ToString());

            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar guardar la información, porfavor intentelo más tarde o comuniquede con el administrador del sistema";

            return -1;
        }

        public void eliminaProcedimiento(string codprocedimiento, string codsolicitud)
        {
            try
            {
                _context.PRGUR_EliminaProcedimientos_PS(codsolicitud, codprocedimiento);
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "codprocedimiento:"+ codprocedimiento
                    + "_codsolicitud:"+ codsolicitud,
                    ruta_sp: "Capa AccesoDatos : PRGUR_EliminaProcedimientos_PS",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar eliminar el procedimiento, porfavor intentelo más tarde o comuniquede con el administrador del sistema";

        }
    }
}
