using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{
    public class FATAdminViewModel
    {
        public List<LstFATModel> listaAtencion { get; set; }
        public List<FiltroModel> especialidades { get; set; }

        public void getListaFATAdmGS(string fecInicio, string FecFin, string busqueda, string codespecialidad, int estado, string medico)
        {
            this.listaAtencion = new List<LstFATModel>();
            IFATService _fatService = new FATService();
            this.listaAtencion = DTOToModel.listaFATModel(
            _fatService.bandejaAdmisionFAT(fecInicio, FecFin, medico, codespecialidad, estado, busqueda));
        }
        public async Task<int> guardaFAT(AtencionTmModel fat)
        {
            return await Task.Run(() =>
            {
                IFATService _fatService = new FATService();
                var fatDTO = ModelDTO.faTDTO(fat);
                int i = _fatService.guardaFAT(fatDTO);
                TeleconsultaViewModel tele = new TeleconsultaViewModel();
                tele.guardaDiagnostico(fat.dx, fat.idAtencion);
                tele.guardaMedicamentos(fat.medicinas, fat.idAtencion);
                tele.guardaServicio(fat.laboratorio, fat.idAtencion, "LAB");
                tele.guardaServicio(fat.radiologia, fat.idAtencion, "RAD");
                return i;
            });
        }

    }
}