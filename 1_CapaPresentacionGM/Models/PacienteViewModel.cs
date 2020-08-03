using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{
    public class PacienteModel
    {
        public string NroHistoria { get; set; }

        public string mostrarNombre { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FNacimiento { get; set; }
        public string Sexo { get; set; }
        public string EstCivil { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string eMail { get; set; }
        public string Edad { get; set; }
        public string DNI { get; set; }
        public string tipoDocumento { get; set; }
        public PlanSaludModel planSalud { get; set; }
        public string celular { get; set; }
        public string FUtimaAtencion { get; set; }

        public PacienteModel()
        {
            this.NroHistoria = "";
            this.Nombre = "";
            this.FNacimiento = "";
            this.Sexo = "";
            this.EstCivil = "";
            this.Domicilio = "";
            this.Telefono = "";
            this.eMail = "";
            this.Edad = "";
            this.DNI = "";
            this.celular = "";
            planSalud = new PlanSaludModel();
        }
    }

    public class PlanSaludModel
    {
        public string fafiliacion { get; set; }
        public string fcontrato { get; set; }
        public string estadocontrato { get; set; }
        public string contratoCodigo { get; set; }
        public string plan { get; set; }
        public string producto { get; set; }
        public string contratoIniVigencia { get; set; }
        public string contratoFinVigencia { get; set; }
        public string TitularDocIden { get; set; }
        public string TitularNombre { get; set; }
        public string Parentesco { get; set; }
        public string contratante { get; set; }
        public string codafilicacion { get; set; }

        public List<BeneficioModel> beneficios { get; set; }
        public List<PreexistenciasModel> preexistencias { get; set; }
        public List<DeclaracionJuradaPSModel> declaracionJur { get; set; }
        public PlanSaludModel()
        {
            this.contratante = "";
            this.fafiliacion = "";
            this.fcontrato = "";
            this.estadocontrato = "";
            this.contratoCodigo = "";
            this.plan = "";
            this.producto = "";
            this.contratoIniVigencia = "";
            this.contratoFinVigencia = "";
            this.TitularDocIden = "";
            this.TitularNombre = "";
            this.Parentesco = "";
        }
    }

    public class PreexistenciasModel
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string observaciones { get; set; }
    }

    public class BeneficioModel
    {
        public string codigo { get; set; }
        public string cobertura { get; set; }
        public string copagofijo { get; set; }
        public string copagovariable { get; set; }
        public bool seleccionado { get; set; }
        public bool isForzado { get; set; }
    }

    public class DeclaracionJuradaPSModel
    {
        public List<DolenciaModel> dolencia { get; set; }
        public string respuesta { get; set; }
        public string texto { get; set; }
    }
    public class DolenciaModel
    {
        public string descripcion { get; set; }
        public string situacionActual { get; set; }
        public string detalle { get; set; }
    }

    public class PacienteViewModel
    {
        public List<PacienteModel> pacientes;
        public PacienteModel paciente;
        public string mensajeError;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
           (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void buscarPaciente(string hcd, string nombres, string apellido1, string apellido2)
        {
            IPacienteService pacservice = new PacienteService();
            this.pacientes = new List<PacienteModel>();
            string materno = apellido2 ?? "";
            string nombre = nombres ?? "";

            if (pacservice.getPaciente(hcd, nombre, apellido1, materno) == null)
            {
                mensajeError = "Hubo un problema, consute con el administrador";
            }
            else
            {
                this.pacientes = DTOToModel.listPaciente(pacservice.getPaciente(hcd, nombre, apellido1, materno).ToList());
            }
        }

        public void getPacientePS(string docident, string tipoDocumento)
        {

            IConsultaPlanSaludService wsplan = new ConsultaPlanSaludService();
            this.paciente = new PacienteModel();
            var paciente = wsplan.getAfiliadoPorDocumento(docident, tipoDocumento);
            this.paciente = (paciente != null) ? DTOToModel.pacienteModel(paciente) : null;
        }

        public void getPacientePSxApellidos(string apellidos)
        {
            IConsultaPlanSaludService wsplan = new ConsultaPlanSaludService();
            this.pacientes = new List<PacienteModel>();
            this.pacientes = DTOToModel.listPaciente(wsplan.getAfiliadoPorApellidos(apellidos));
        }

        public void buscarPacienteOIQ(string tipoDoc, string busqueda)
        {
            IPacienteService pacservice = new PacienteService();
            this.pacientes = new List<PacienteModel>();
            this.pacientes = DTOToModel.listPaciente
               (pacservice.getPacienteAll(busqueda, tipoDoc));
        }

        public void buscarPacienteFAT(string NroDocumento)
        {
            IFATService _fatService = new FATService();
            this.paciente = new PacienteModel();
            this.paciente = DTOToModel.pacienteModel(_fatService.getPacienteFAT(NroDocumento));
        }

    }
}