using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models.Modelos
{
    public class UsuarioSessionModel
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public int Respuesta { get; set; }
        public bool isMedico { get; set; }
    }
}