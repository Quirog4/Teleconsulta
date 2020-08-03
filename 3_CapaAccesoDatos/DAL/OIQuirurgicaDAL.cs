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
    public class OIQuirurgicaDAL : BaseContextCRPCG, IOrdenIntQuirurgicaDAL
    {
        public bool eliminaCDES(int id, string codigo, string tipo)
        {
            try
            {
                _context.PRGUR_EliminarCDESOIQx(i_Codigo: codigo,
                    i_IdCorrelativoInterno: id, tipoIns: tipo);
                return true;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                     parametros: "idOrden:" + id +
                                 "--codigo:" + codigo +
                                 "--tipo:" + tipo,
                     ruta_sp: "Capa Servicio : getOrdenQx",
                     detalle: e.Message,
                     mensaje: e.ToString());
                return false;
            }
        }

        public bool eliminaOrden(int id, string codigo)
        {
            try
            {
                _context.PRGUR_Eliminar_OIQUIRURGICA(
                    i_NroOrden: codigo,
                    i_idOrdenQx: id,
                    i_Usuario:UserLoginCache.audUser,
                    i_Equipo:UserLoginCache.IpAddress
                    );
                return true;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                     parametros: "idOrden:" + id +
                                 "--codigo:" + codigo ,
                     ruta_sp: "Capa Servicio : getOrdenQx",
                     detalle: e.Message,
                     mensaje: e.ToString());
                return false;
            }
        }

        public CartaOIQx_Result getCartaOrdenQx(int idOrden)
        {
            CartaOIQx_Result _result = new CartaOIQx_Result();
            try
            {
                _result = _context.PRGUR_getCartaOIQx(i_idOrden: idOrden).FirstOrDefault();
                return _result;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "i_idOrden:" + idOrden,
                    ruta_sp: "Capa AccesoDatos : PRGUR_getCartaOIQx",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            return _result;
        }

        public List<ListarCartasOIQx_Result> getListaCartasOrdenes(string busqueda, string codEspecialidad,
            string codEstadoReqPreQx, string codtipocirugia,string fecinicio, string fecfin, bool reqpreqx)
        {
            List<ListarCartasOIQx_Result> _result = new List<ListarCartasOIQx_Result>();
            try
            {
                _result = _context.PRGUR_ListarCartasOIQx(
                    i_sBusqueda: busqueda,
                    i_FFin: fecfin, 
                    i_FInic: fecinicio,
                    i_CodEspecialidad:codEspecialidad,
                    i_CodEstadoPreQx:codEstadoReqPreQx,
                    i_CodTipoCirugia: codtipocirugia,
                    i_ReqPreQx:reqpreqx
                    ).ToList();
                return _result;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "__i_sBusqueda:" + busqueda,
                    ruta_sp: "Capa AccesoDatos : PRGUR_ListarOIQx",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            return _result;
        }

        public List<ListarCartasOIQxProgramador_Result> getListaCartasOrdenesProgramador(string codEstadoCG
           , string codEstadoReqPreQx, string fecinicio, string fecfin, bool qxprograma)
        {
            List<ListarCartasOIQxProgramador_Result> _result = new List<ListarCartasOIQxProgramador_Result>();
            try
            {
                _result = _context.PRGUR_ListarCartasOIQxProgramador(
                    i_FFin: fecfin,
                    i_FInic: fecinicio,
                    i_CodEstadoCarta: codEstadoCG,
                    i_CodEstadoPreQx: codEstadoReqPreQx,
                    i_QxProgramado: qxprograma                   
                    ).ToList();
                return _result;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "i_FFin:"+ fecfin+
                    "i_FInic:"+ fecinicio+
                    "i_CodEstadoCarta:"+ codEstadoCG+
                    "i_CodEstadoPreQx:"+ codEstadoReqPreQx+
                    "i_QxProgramado:"+ qxprograma,
                    ruta_sp: "Capa AccesoDatos : PRGUR_ListarCartasOIQxProgramador",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            return _result;
        }

        public List<ListarOIQx_Result> getListaOrdenes(string busqueda, string codespecialidad, string estado, string fechaini, string fechafin, bool cconfirmada)
        {
            List<ListarOIQx_Result> _result = new List<ListarOIQx_Result>();
            try
            {

                _result = _context.PRGUR_ListarOIQx(
                    i_CConfirmada: cconfirmada,
                    i_CodEspecialidad: codespecialidad,
                    i_CodEstado: estado,
                    i_FFin: fechafin,
                    i_FInic: fechaini,
                    i_sBusqueda: busqueda
                    , i_CMP: UserLoginCache.CMP
                    ).ToList();
                return _result;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "i_CConfirmada:" + cconfirmada +
                    "__i_CodEspecialidad:" + codespecialidad +
                    "__i_CodEstado:" + estado +
                    "__i_FFin:" + fechafin +
                    "__i_FInic:" + fechaini +
                    "__i_sBusqueda:" + busqueda,
                    ruta_sp: "Capa AccesoDatos : PRGUR_ListarOIQx",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            return _result;
        }

        public OIQirurgica_Result getOrdenQx(int idOrden)
        {
            OIQirurgica_Result _result = new OIQirurgica_Result();
            try
            {
                _result = _context.PRGUR_getOIQx(i_idOrden: idOrden).FirstOrDefault();
                return _result;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "i_idOrden:" + idOrden,
                    ruta_sp: "Capa AccesoDatos : PRGUR_getOIQx",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            return _result;
        }

        public bool guardarCartaOIQx(int idcarta,string codestado, string criterio, string observaciones, string fechacirugia, string sala, bool qxconfirmado,string tipo,string tipoAnes)
        {
            try
            {
                string fechaCirugia = "";
                if (!String.IsNullOrEmpty(fechacirugia)) {
                    string hora = fechacirugia.Substring(10);
                    fechaCirugia = Convert.ToDateTime(fechacirugia).ToString("yyyy-MM-dd");
                    fechaCirugia += hora;
                }

                _context.PRGUR_GUARDA_CartaOrdenIQx(
                    id_carta:idcarta,
                    id_Solcarta:"",
                    is_criteriopreqx:criterio,
                    iS_estadoPreqx:codestado,
                    is_fechaCirugia: fechaCirugia,
                    is_observaciones:observaciones,
                    is_qxProgramada:qxconfirmado,
                    is_sala:sala,
                    is_tipo:tipo,
                    is_tipoAnestesia:tipoAnes,
                    is_vp_equipo:UserLoginCache.IpAddress,
                    is_vp_usuario:UserLoginCache.audUser
                    );
                return true;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                     parametros: "idOrden:" + idcarta,
                     ruta_sp: "Capa Servicio : PRGUR_GUARDA_CartaOrdenIQx",
                     detalle: e.Message,
                     mensaje: e.ToString());
                return false;
            }
        }

        public int guardarOrdenIQx(OIQirurgica_Result orden, List<string> equipo, List<string> diagnostico, List<string> cirugia, List<SuministrosxOIQuirurgica_Result> suministro, List<ArchivosXCodCarta_Result> archivos)
        {

            try
            {
                string usermed = UserLoginCache.CMP ?? "";
                string fcigur = Convert.ToDateTime(orden.FecCirugia).ToString("MM-dd-yyyy");
                string fhosp = Convert.ToDateTime(orden.FecHospit).ToString("MM-dd-yyyy");
                 string edad = (!String.IsNullOrEmpty(orden.EdadPac)) ? orden.EdadPac.Split(' ')[0] : "";
                string tipoUpd = (orden.IdOrden!=0) ?"UPD":"Ins";
                CodIdOIQx_Result indice = _context.PRGUR_GUARDAR_OIQUIRURGICA(
                    i_idOrdenQx: orden.IdOrden,
                    i_NroOrden: orden.NroOrden,
                    i_Usuario: UserLoginCache.audUser,
                    i_Equipo: UserLoginCache.IpAddress,
                    i_Num_Doc_Paciente: orden.DocPac,
                    i_HC_paciente: orden.HCPac,
                    i_Edad: edad,
                    i_Num_Celular: orden.CelularPac,
                    i_Nom_Paciente: (orden.NombrePac!=null)?orden.NombrePac.ToUpper():"",
                    i_CorreoContacto: orden.CorreoPac,
                    i_codFinanciador: orden.Financiador,
                    i_codEspecialidad: orden.Especialidad,
                    i_codTipoCirugia: orden.TipoCarta,
                    i_Tiempo_dia: orden.TenfDia,
                    i_Tiempo_Mes: orden.TenfMes,
                    i_Tiempo_year: orden.TenfAnios,
                    i_HorasQx: orden.DuracionHorQx,
                    i_Alergias: orden.Alergias,
                    i_Morbilidades: orden.Morbilidades,
                    i_Requisito1: orden.ReqConsentimiento,
                    i_Requisito2: orden.ReqExamenes,
                    i_Requisito3: orden.ReqImagenes,
                    i_Requisito4: orden.ReqRiesgoCar,
                    i_Requisito5: orden.ReqRiesgoNeu,
                    i_Requisito6: orden.ReqDSangre,
                    i_Requisito7: orden.ReqEvaPre,
                    i_Requisito8: orden.ReqOtros,
                    i_FCirugia: (orden.FecCirugia != null) ? fcigur : "",
                    i_HoraCirugia: orden.HorCirugia,
                    i_FHospitalizacion: (orden.FecCirugia != null) ? fhosp : "",
                    i_HoraHosp: orden.HorHospit,
                    i_Justificacion: (orden.Justificacion != null) ? orden.Justificacion.ToUpper() : "",
                    i_Testancia: orden.TEstimado,
                    i_Profilaxis: orden.Profilaxis,
                    i_CMPmedicoReg: usermed,
                    i_ValidaTiempo:orden.ValidaTiempo,
                    i_TipoAnestesia:orden.TipoAnestesia
                    ).FirstOrDefault();

                if (diagnostico != null)
                {
                    foreach (string cdes in diagnostico)
                    {
                        if (cdes == "") continue;
                        _context.PRGUR_guardarCDESxOIQuirurgica(
                                   i_NroOIQx: indice.IDORDEN,
                                   i_CodigoOIQx:indice.NRORDEN,
                                   i_Codigo: cdes,
                                   i_Equipo: UserLoginCache.IpAddress,
                                   i_Usuario: UserLoginCache.audUser,
                                   tipoIns: ConstanteDB.TipoDx
                                   );
                    }
                }
                if (cirugia != null)
                {
                    foreach (string cdes in cirugia)
                    {
                        if (cdes == "") continue;
                        _context.PRGUR_guardarCDESxOIQuirurgica(
                                   i_NroOIQx: indice.IDORDEN,
                                   i_CodigoOIQx: indice.NRORDEN,
                                   i_Codigo: cdes,
                                   i_Equipo: UserLoginCache.IpAddress,
                                   i_Usuario: UserLoginCache.audUser,
                                   tipoIns: ConstanteDB.TipoCirugia
                                   );
                    }
                }
                if (equipo != null)
                {
                    foreach (string cdes in equipo)
                    {
                        if (cdes == "") continue;
                        _context.PRGUR_guardarCDESxOIQuirurgica(
                                   i_NroOIQx: indice.IDORDEN,
                                   i_CodigoOIQx: indice.NRORDEN,
                                   i_Codigo: cdes,
                                   i_Equipo: UserLoginCache.IpAddress,
                                   i_Usuario: UserLoginCache.audUser,
                                   tipoIns: ConstanteDB.TipoEquipo
                                   );
                    }
                }
                if (suministro != null)
                {
                    foreach (SuministrosxOIQuirurgica_Result s in suministro)
                    {
                        //if (s.CODIGO == "") continue;
                        _context.PRGUR_guardarSuministroxOIQuirurgica(
                                   i_NroOIQx: indice.IDORDEN,
                                   i_TipoIns: tipoUpd,
                                   i_Codigo: s.CODIGO,
                                   i_Equipo: UserLoginCache.IpAddress,
                                   i_Usuario: UserLoginCache.audUser,
                                   i_cantidad:s.cantidad,
                                   i_Observacion:s.Observ
                                   );
                    }
                }
                if (archivos != null)
                {
                    IArchivoCGDAL _arcDal = new ArchivoCGDAL();
                    int ind = 0;
                    foreach (var a in archivos)
                    {
                        a.NombreArchivo = "OIQAnexo" + ind+ConstanteDB.extensionPDF;
                        a.Origen = "OIQx";
                        a.IdArchivo = indice.IDORDEN ?? 0;
                        a.codSolicitud = indice.NRORDEN;
                        a.TipoArchivo = "OD";
                        _arcDal.guardarArchivo(a, "", "");
                        ind++;
                    }
                }

                return indice.IDORDEN ?? 0;
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
                    parametros: "OiQx",
                    ruta_sp: "Capa AccesoDatos : PRGUR_getOIQx",
                    detalle: "Error al ingresar la informacion a la base de datos",
                    mensaje: e);
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "OIQx",
                    ruta_sp: "Capa AccesoDatos : PRGUR_ListarOIQx",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar guardar la información, porfavor intentelo más tarde o comuniquede con el administrador del sistema";
            return -1;
        }

        public List<CDESxOIQx_Result> listaCDESxIOQx(int idOrden, string Tipo)
        {
            List<CDESxOIQx_Result> _result = new List<CDESxOIQx_Result>();
            try
            {

                _result = _context.PRGUR_getCDESxOIQuirurgica(
                   i_NroOIQx: idOrden,
                   tipoIns: Tipo
                    ).ToList();
                return _result;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "i_NroOIQx:" + idOrden +
                    "__tipoIns:" + Tipo,
                    ruta_sp: "Capa AccesoDatos : PRGUR_getCDESxOIQuirurgica",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            return _result;
        }

        public List<SuministrosxOIQuirurgica_Result> listaSuministroOQx(int idOrden)
        {
            List<SuministrosxOIQuirurgica_Result> _result = new List<SuministrosxOIQuirurgica_Result>();
            try
            {

                _result = _context.PRGUR_getSuministrosxOIQuirurgica(
                   i_NroOIQx: idOrden
                    ).ToList();
                return _result;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "i_NroOIQx:" + idOrden ,
                    ruta_sp: "Capa AccesoDatos : PRGUR_getCDESxOIQuirurgica",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            return _result;
        }

        public List<PreQuirurgicoxCartaOiqx_Result> preqxXcarta(int idCarta)
        {

            List<PreQuirurgicoxCartaOiqx_Result> _result = new List<PreQuirurgicoxCartaOiqx_Result>();
            try
            {

                _result = _context.PRGUR_getPreQuirurgicoxCartaOiqx(
                    i_idSolicitud:idCarta
                    ).ToList();
                return _result;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                    parametros: "i_idSolicitud:"+idCarta,
                    ruta_sp: "Capa AccesoDatos : PRGUR_getPreQuirurgicoxCartaOiqx",
                    detalle: e.Message,
                    mensaje: e.ToString());
            }
            return _result;
        }

    }
}
