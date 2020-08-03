using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_CapaPresentacionGM.Models.Reportes
{
    public class FAT_RadiologiaPDF : FAT_General
    {
        public string cExamen { get; set; }
      
        public FAT_RadiologiaPDF()
        {
            this.titulo = "Radiología - Atención de Telemonitoreo";
        }
    }
}
