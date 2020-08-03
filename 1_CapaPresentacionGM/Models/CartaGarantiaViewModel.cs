using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{
    public class CartaGarantiaModel
    {
        public string obseGenerales { get; set; }

        public string nrogarantia { get; set; }
        public string nrosolicitud { get; set; }
        public string fechaRegistro { get; set; }
        public string financiador { get; set; }
        public string fechavcto { get; set; }
        public string obsfin { get; set; }
        public string tipoCarta { get; set; }
        public string obsrechazado { get; set; }
        public string motivodemora { get; set; }
        public string estado { get; set; }
        public string importe { get; set; }
        public string deducible { get; set; }
        public string coaseguro { get; set; }
        public string agente { get; set; }
        public string colorEstado { get; set; }
        public string NoCubierto { get; set; }
        public string ObsNoCubierto { get; set; }
        public string tipoSolicitud { get; set; }
        public string procedimiento { get; set; }
        public PacienteModel paciente { get; set; }
        public int idCartaGarantia { get; set; }
        
        //Solicitud plan salud
        public string tiempoEnfer { get; set; }
        public string obsMedTratante { get; set; }
        public string codtipoAtencion { get; set; }
        public int nroDiasHosp { get; set; }
        public string usuarioRegistro { get; set; }
        public string TenfAnio { get; set; }
        public string TenfMes { get; set; }
        public string TenfDia { get; set; }
        public FiltroModel diagnostico { get; set; }
        public FiltroModel medicoTratante { get; set; }
        public FiltroModel especialidad { get; set; }
        public string tipoAtencion { get; set; }
        public List<FiltroModel> procedimientos { get; set; }
        public ObservacionesAuditorModel auditor { get; set; }

        public List<ArchivoModel> archivos { get; set; }
        public string idEstadoCarta { get;  set; }
        public string importePresup { get; set; }

        public CartaGarantiaModel()
        {
            this.nrogarantia = "";
            this.nrosolicitud = "";
            this.fechaRegistro = "";
            this.financiador = "";
            this.fechavcto = "";
            this.obsfin = "";
            this.tipoCarta = "";
            this.tipoSolicitud = "";
            this.procedimiento = "";
            this.obsrechazado = "";
            this.motivodemora = "";
            this.estado = "";
            this.importe = "";
            this.deducible = "";
            this.coaseguro = "";
            this.agente = "";
            this.colorEstado = "";
            this.NoCubierto = "";
            this.ObsNoCubierto = "";
            this.paciente = new PacienteModel();
            this.tiempoEnfer = "";
            this.obsMedTratante = "";
            this.codtipoAtencion = "";
            this.nroDiasHosp = 0;
            this.usuarioRegistro = "";
            this.TenfAnio = "";
            this.TenfMes = "";
            this.TenfDia = "";
            this.obsMedTratante = "";
            this.medicoTratante =  new FiltroModel { codigo="", descripcion=""};
            this.diagnostico = new FiltroModel { codigo = "", descripcion = "" };
            this.auditor = new ObservacionesAuditorModel();

        }
    }

    public class lstCartaGarantiaModel
    {
        public string nrosolicitud { get; set; }
        public string nompaciente { get; set; }
        public string departamento { get; set; }
        public string titular { get; set; }
        public string nroContrato { get; set; }
        public string colorEstado { get; set; }
        public string estado { get; set; }
        public string fechaRegistro { get; set; }
        public string tipoAtencion { get; set; }
        public string tipoSolicitud { get; set; }
        public string procedimiento { get; set; }
        public int id { get; set; }
    }

    public class CartaGarantiaViewModel
    {
        public List<lstCartaGarantiaModel> cartas;
        public CartaGarantiaModel cartaG;
        public string mensajeError;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
          (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void listadoCartas(String busqueda, string periodo, string especialidad)
        {
            ICartaGarantiaService service = new CartaGarantiaService();
            this.cartas = new List<lstCartaGarantiaModel>();
            this.cartas = DTOToModel.listarCartasGarantia(service.listarCartas(busqueda, especialidad));
            mensajeError = "Hubo un problema, consute con el administrador";
        }

        public void getCarta(int nroSolicitud)
        {
            ICartaGarantiaService service = new CartaGarantiaService();
            this.cartaG = new CartaGarantiaModel();
            this.cartaG = DTOToModel.CartaGarantiaModel(service.getCarta(nroSolicitud));
        }


    }
}