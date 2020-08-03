using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{
    public class OIQuirurgicaModel
    {
        public string tipoSolicitante { get; set; }

        //PREQX
        public string observacionesPreqx { get; set; }
        public string colorEstadoPreQx { get; set; }
        public bool isEditablePreQx { get; set; }
        public string EstadoPreqx { get; set; }
        public string criterioEstadoPreqx { get; set; }
        public int idCarta { get; set; }

        public int idOrden { get; set; }
        public string nroOIQuirurgica { get; set; }
        public string TiEnferDia { get; set; }
        public string TiEnferMes { get; set; }
        public string TiEnferAnio { get; set; }
        public string DuracionCirugia { get; set; }
        public string Alergia { get; set; }
        public string Morbilidad { get; set; }
        public string Especialidad { get; set; }
        public string Financiador { get; set; }
        public string TipoCirugia { get; set; }
        public bool Requisito1 { get; set; }
        public bool Requisito2 { get; set; }
        public bool Requisito3 { get; set; }
        public bool Requisito4 { get; set; }
        public bool Requisito5 { get; set; }
        public bool Requisito6 { get; set; }
        public bool Requisito7 { get; set; }
        public string Requisito8 { get; set; }
        public bool profilaxis { get; set; }
        public bool isEditable { get; set; }
        public string justificacion { get; set; }
        public List<ArchivoModel> anexos { get; set; }
        public PacienteModel paciente { get; set; }
        public List<FiltroModel> Procedimientos { get; set; }
        public List<FiltroModel> Diagnosticos { get; set; }
        public List<FiltroModel> Equipos { get; set; }
        public List<SuministroModel> Insumos { get; set; }
        public string TiempEstancia { get; set; }
        public string FecPrevistaCirugia { get; set; }
        public string HoraPrevistaCirugia { get; set; }
        public string FecPrevistaHospitalizacion { get; set; }
        public string HoraPrevistaHospitalizacion { get; set; }
        public string colorEstado { get; set; }
        public bool isAlertaProgramador { get; set; }
        //Campos del programador
        public bool QxConfirmado { get; set; }
        public string obsProgramador { get; set; }
        public string Sala { get; set; }
        public string FecCirugiaProgramada { get; set; }//indicada x el programador de sala

        //Listado
        public string Estado { get; set; }
        public string QxProgramado { get; set; }
        public string FecRegistro { get; set; }
        public string Departamento { get;  set; }
        public string FecCitaPreQx { get;  set; }
        public string Solicitante { get;  set; }
        public int idArchivo { get;  set; }
        public string observacionFidelizacion { get;  set; }
        public string preqxRealizado { get;  set; }
        public string pacienteAdmitido { get;  set; }
        public string requierePreqx { get;  set; }
        public string AnexoProgramadorSala { get; set; }
        public int alertaProgramador { get; set; }
        public string tipoAnestesia { get; set; }
    }
    public class ListaPreQx
    {
        public string fecha { get; set; }
        public string descripcion { get; set; }
        public string observaciones { get; set; }
     //   public int id { get; set; }
    }

    public class SuministroModel
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public string observaciones { get; set; }
    }

    public class OIQuirurgicaViewModel
    {
        public List<FiltroModel> lstTipoCirugia;
        public List<FiltroModel> lstTipoDocumentos;
        public List<FiltroModel> lstFinanciador;
        public List<FiltroModel> lstTipoAnestesia;
        public List<FiltroModel> lstDiagnosticoCIE;
        public List<FiltroModel> lstEspecialidades;
        public List<FiltroModel> lstEstados;
        public List<FiltroModel> lstEstadosPreQx;
        public List<FiltroModel> lstProcedimientos;
        public List<FiltroModel> lstSalas;
        public List<AtencionModel> atenciones;
        public OIQuirurgicaModel quirurgicaModel;
        public List<OIQuirurgicaModel> listOIQx;
        public List<ListaPreQx> lstPreQx;

        public void getCombos()
        {
            SelectViewModel select = new SelectViewModel();
            this.lstEspecialidades = new List<FiltroModel>();
            this.lstEspecialidades = select.listaEspecialidadesMedicas();
            this.lstFinanciador = new List<FiltroModel>();
            this.lstTipoCirugia = new List<FiltroModel>();
            this.lstTipoDocumentos = new List<FiltroModel>();
            this.lstTipoDocumentos = select.listaTipoDocumento();
            this.lstFinanciador = select.listaFinanciador();
            this.lstTipoCirugia = select.listaTipoCirugia();
        }

        public void eliminaCDES(int id, string codigo, string tipo)
        {
            IOrdenIQxService _service = new OrdenIQxService();
            _service.eliminaCDES(id, codigo, tipo);
        }

        public void getOIQx(int idOrden)
        {
            this.quirurgicaModel = new OIQuirurgicaModel();
            IOrdenIQxService _service = new OrdenIQxService();
            var oiq = _service.getOrden(idOrden);
            this.quirurgicaModel = DTOToModel.getOIQx(oiq);
            if (oiq.Equipo != null)
            {
                this.quirurgicaModel.Equipos = DTOToModel.filtroModel(oiq.Equipo);
            }
            if (oiq.Suministro != null)
            {
                this.quirurgicaModel.Insumos = DTOToModel.suministroModel(oiq.Suministro);
            }
            if (oiq.Cirugia != null)
            {
                this.quirurgicaModel.Procedimientos = DTOToModel.filtroModel(oiq.Cirugia);
            }
            if (oiq.Diagnostico != null)
            {
                this.quirurgicaModel.Diagnosticos = DTOToModel.filtroModel(oiq.Diagnostico);
            }
            if (oiq.Anexos != null)
            {
                this.quirurgicaModel.anexos = DTOToModel.getArchivos(oiq.Anexos);
            }
            //this.quirurgicaModel.Insumos = DTOToModel.filtroModel(oiq.Suministro);
        }

        public void eliminaArchivo(int id)
        {
            IArchivosCGService _service = new ArchivosCGService();
            _service.eliminaArchivo(id);
        }

        public void eliminaOrden(int id, string codigo)
        {
            IOrdenIQxService _service = new OrdenIQxService();
            bool rpta=_service.eliminaOrden(id,codigo);
        }

        public void listaOIQx(string busqueda, string especialidad, string codEstado, string fechaini, string fechafin, bool qxprogramado)
        {
            this.listOIQx = new List<OIQuirurgicaModel>();
            IOrdenIQxService _service = new OrdenIQxService();
            var s = _service.ordenes(busqueda, especialidad, codEstado, fechaini, fechafin, qxprogramado);
            this.listOIQx = DTOToModel.listaOrdenIQx(s);
        }

        public int guardarOIQx(OIQuirurgicaModel orden, List<string> cirugia, List<string> dx
            , List<string> equipo, List<SuministroModel> suministro)
        {
            IOrdenIQxService _service = new OrdenIQxService();
            var anexos = ModelDTO.archivosDTO(orden.anexos);
            var suministros = suministro ?? new List<SuministroModel>();
            return _service.guardarOrden(ModelDTO.ordenIQx(orden), cirugia, dx, equipo, ModelDTO.SuministroDTO(suministros), anexos);
        }

        public void getAtenciones(string hcu,string user,string paciente,string ip) {
            AtencionService atservice = new AtencionService();
            this.atenciones = DTOToModel.listaAtencionModel(atservice.detAtenciones(hcu, user, paciente, ip));
        }

        public void listarCartaPreQx(string busqueda,string  especialidad,string  codTipoCirugia,string  fecinicio,string  fecfin,bool  reqpreqx,string  codEstado)
        {
            IOrdenIQxService _service = new OrdenIQxService();
            this.listOIQx = new List<OIQuirurgicaModel>();
            var lista=_service.listarCartasPreQx(busqueda,especialidad,codTipoCirugia,fecinicio,fecfin,reqpreqx,codEstado);
            this.listOIQx = DTOToModel.listaCartaOrdenIQx(lista);
        }

        public void listarCartaProgramadorSala(string codEstadoCarta, string fechaini, string fechafin, bool qxprogramado, string preQx)
        {
            IOrdenIQxService _service = new OrdenIQxService();
            this.listOIQx = new List<OIQuirurgicaModel>();
            var lista = _service.listarCartasProgramador(codEstadoCarta, fechaini, fechafin, qxprogramado, preQx);
            this.listOIQx = DTOToModel.listaCartaOrdenIQx(lista);
        }

        public bool guadaPreQx(int idCarta, string estadoPreQx, string criterioEstado, string observaciones,string codTipoAnes)
        {
            IOrdenIQxService _service = new OrdenIQxService();
           return _service.guardarCartaPreQx(idCarta,estadoPreQx,criterioEstado,observaciones,codTipoAnes);
        }

        public void getPreQxyEstadoPreqx(int id)
        {
            SelectViewModel select = new SelectViewModel();
            this.lstEstadosPreQx = new List<FiltroModel>();
            this.lstEstadosPreQx = select.listaEstadosPreQx();
            this.lstTipoAnestesia = new List<FiltroModel>();
            this.lstTipoAnestesia = select.listaTipoAnestesia();
            this.lstPreQx = new List<ListaPreQx>();
            ICartaGarantiaService _service = new CartaGarantiaService();
            this.lstPreQx = DTOToModel.listarPreQx(_service.preqxXcarta(id));
        }

        public void getCombosPreQX()
        {
            SelectViewModel select = new SelectViewModel();
            this.lstEstadosPreQx = new List<FiltroModel>();
            this.lstEspecialidades = new List<FiltroModel>();
            this.lstTipoDocumentos = new List<FiltroModel>();
            this.lstEstadosPreQx = select.listaEstadosPreQx();
            this.lstEspecialidades = select.listaEspecialidades();
            this.lstTipoCirugia = select.listaTipoCirugia();
        }

        public void getCombosProgramadorSala()
        {
            SelectViewModel select = new SelectViewModel();
            this.lstEstadosPreQx = new List<FiltroModel>();
            this.lstEstados = new List<FiltroModel>();
            this.lstEstadosPreQx = select.listaEstadosPreQx();
            this.lstEstados = select.listaEstados();
        }

        public void getProgramadorCartaEstadoOIqx(int id)
        {
            SelectViewModel select = new SelectViewModel();
            this.quirurgicaModel = new OIQuirurgicaModel();
            IOrdenIQxService _service = new OrdenIQxService();
            var oiq = _service.getCartaOrden(id);
            this.quirurgicaModel = DTOToModel.getCartaOIQx(oiq);
            if (oiq.cirugias != null)
            {
                this.quirurgicaModel.Procedimientos = DTOToModel.filtroModel(oiq.cirugias);
            }
            this.lstPreQx = new List<ListaPreQx>();
            ICartaGarantiaService _servicepreqx = new CartaGarantiaService();
            var pre = _servicepreqx.preqxXcarta(id);
            if (pre.Count >0)
            {
                this.lstPreQx = DTOToModel.listarPreQx(pre);
            }
        }

        public bool guardarProgramacionSala(int idcarta, string fechaProgramada, string sala, bool qxprogramado,string observacion)
        {
            IOrdenIQxService _service = new OrdenIQxService();
            return _service.guardarCartaProgramacionSala(idcarta, fechaProgramada, sala, qxprogramado,observacion);
        }
    }
}