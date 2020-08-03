using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.IDAL
{
    public interface IArchivoCGDAL
    {
        List<ArchivosXCodCarta_Result> getArchivos(int idsolicitud,string codsolicitud);
        ArchivosXCodCarta_Result getArchivoAuditor(int codsolicitud);
        bool guardarArchivo(ArchivosXCodCarta_Result archivo, string usuario, string ip);
        bool eliminaArchivo(int id);
        bool guardaArchivoFAT(ArchivosXCodCarta_Result archivosXCodCarta_Result);
    }
}
