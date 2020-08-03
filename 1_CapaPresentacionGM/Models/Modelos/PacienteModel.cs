using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models.Modelos
{
    public class PacienteModel
    {

        public int IdPaciente { get; set; }
        public string NumeroDoc { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string HC { get; set; }
        public int Edad{ get; set; }
        public string Sexo { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Financiador { get; set; }
    }
}