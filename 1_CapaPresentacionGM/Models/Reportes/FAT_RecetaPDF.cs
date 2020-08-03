using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_CapaPresentacionGM.Models.Reportes
{
    public class FAT_RecetaPDF : FAT_General
    {
        public string cDatosReceta { get; set; }
        public string cIndicacionesReceta { get; set; }
        //public string lstDiagnostico { get; set; }

        public FAT_RecetaPDF(string re,string indicaciones)
        {
            this.titulo = "Receta Virtual - Atención de Telemonitoreo";
            this.cDatosReceta = re;
            this.cIndicacionesReceta = indicaciones;
        }

     
    }
}
