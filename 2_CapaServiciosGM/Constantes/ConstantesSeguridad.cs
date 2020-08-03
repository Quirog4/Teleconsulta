using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CapaServiciosGM.Constantes
{
    public class ConstantesSeguridad
    {
        public static int IDAPPLICATION = 7;
        //----------------------Resultados WS------------
        public static int UsuarioValido =1;
        public static int UsuarioNoValido = 0;
        public static int PrimerAcceso = 2;
        public static string CambioClave = "0";
        public static char READ = 'R';
        public static char WRITE = 'W';
        public static int ErrorSistema = -2;
        public static string DirActivo = "1";
        public static string BD = "0";
        //-------------CAMPOS WS Ska--------------------

        public const string NOMBAPLICACION = "NOMBREENAPLICACION";
        public const string USUPASSWORD = "USUPASSWORD";
        public const string USUARIO = "USUARIO";
        public const string NOMBRESUSUARIO = "NOMBRESUSUARIO";
        public const string APLICATIVO = "APLICATIVO";
        public const string VALCAMBIO_PASS = "VALCAMBIO_PASS";
        public const string COLEGIATURA = "COLEGIATURA";
        public const string SERVICIO = "CODSERVICIO";
        public const string NOMBSERVICIO = "NOMSERVICIO";
        public const string TIPO_ACCESO = "TIPO_ACCESO";
        public const string COMPONENTE = "COMPONENTE";
        public const string menuVerAten = "GUR-001";
        public const string menuBuscarCG = "GUR-002";
        public const string menuServicio = "GUR-003";
        public const string menuAuditor = "GUR-004";
        public const string menuOIQx = "GUR-005";
        public const string menuEstadoPreQx = "GUR-006";
        public const string menuoProgramSala = "GUR-007";
        public const string menuListaFat = "GUR-008";
        public const string menuListaFATAdmision = "GUR-009";
        public const string menuServicioFatRadiologia = "GUR-010";
        public const string menuServicioFatLaboratorio = "GUR-011";
        public const string menuFatReceta = "GUR-012";
        public const string menuListaFATAdmEditor = "GUR-013";
        //-------------CAMPOS WS PlanSalud--------------------
        public const string TipoDocPS = "1";

        public static byte CanReadWrite = 2;
        public static byte CanReadOrWrite = 1;
    }


}
