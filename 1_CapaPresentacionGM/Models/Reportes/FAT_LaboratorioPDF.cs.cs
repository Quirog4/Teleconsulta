using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_CapaPresentacionGM.Models.Reportes
{
    public class FAT_LaboratorioPDF : FAT_General
    {
        public string cExamen { get; set; }

        public FAT_LaboratorioPDF()
        {
            this.titulo = "Laboratorio - Atención de Telemonitoreo";
        }
    }
}