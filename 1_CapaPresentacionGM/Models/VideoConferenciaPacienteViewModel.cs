using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{
    public class VideoConferenciaPacienteViewModel
    {
        public AtencionTmModel atencionTM { get; set; }
        public PacienteModel pacienteFat { get; set; }



        public void getFAT(Guid id)
        {
            IFATService _fatService = new FATService();
            this.atencionTM = new AtencionTmModel();

            var videoConferencia = _fatService.getVideoConferencia(id);

            if (videoConferencia != null)
            {
                var fatdto = _fatService.getFAT(videoConferencia.AtencionId);
                this.atencionTM = DTOToModel.FatModel(fatdto);
                this.atencionTM.dx = DTOToModel.listarDiagnostico(fatdto.diagnosticos);
                this.atencionTM.radiologia = DTOToModel.listaServisioFAT(fatdto.radiologia);
                this.atencionTM.laboratorio = DTOToModel.listaServisioFAT(fatdto.laboratorio);
                this.atencionTM.medicinas = DTOToModel.listMedicinas(fatdto.medicinas);
                this.atencionTM.VideoConferencia = DTOToModel.ObtenerVideoConferenciaModelDesdeDTO(fatdto.VideoConferencia);

            }



        }






    }
}