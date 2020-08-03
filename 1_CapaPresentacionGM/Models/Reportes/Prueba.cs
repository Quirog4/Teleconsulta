using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models.Reportes
{
    public class Prueba
    {
        public string imagen { get; set; }
        public string tituloPrueba { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public Prueba() {
            this.tituloPrueba = "PRUEBAAAAAAAAAAAAAAAAAAAAA";
        }
    }
}