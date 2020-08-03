using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaSoporte.Cache
{
    public static class PermisosSKA
    {
        public static byte VerAtenciones { get;set; }
        public static byte BuscarCG { get; set; }
        public static byte ServicioPS { get; set; }
        public static byte AuditorPS { get; set; }
        public static byte OIQuirurgico { get; set; }
        public static byte ProcesoPreQx { get; set; }
        public static byte ProgramarSala { get; set; }
        public static int FatLaboratorio { get;  set; }
        public static int FatRadiologia { get; set; }
    }
}
