using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models.Modelos
{
    public class TeleconsultaModel
    {
        public int IdAtencion { get; set; }
        public string FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string NroDocumento { get; set; }
        public PacienteModel Paciente { get; set; }
        public string Seguro { get; set; }
        public string Estado { get; set; }
        public string Anamnesis { get; set; }
        public string Motivo { get; set; }
        public string Receta { get; set; }
        public string OAA { get; set; }
        public string fechaOAA { get; set; }
        public string usuarioOAA { get; set; }
        public bool estadoRegistro { get; set; }
        public string tipoAtencion { get; set; }
        public string medioContacto { get; set; }
    }
}


