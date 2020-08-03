using CapaSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_CapaPresentacionGM.Models.Reportes
{
    public class Header
    {
        public string rutaImagen { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string titulo { get; set; }
        public string otro { get; set; }

        public Header()
        {
            this.fecha = DateTime.Now.ToShortDateString();
            this.hora = DateTime.Now.ToString("hh:mm tt");
        }

    }
}
