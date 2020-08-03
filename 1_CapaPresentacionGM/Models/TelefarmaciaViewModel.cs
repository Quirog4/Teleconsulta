using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{
    public class TelefarmaciaViewModel
    {
        public List<string> estadosRp { get; set; }
        public List<LstFATModel> listaAtencion { get; set; }
        public List<GuiasModel> listaGuias { get; set; }
        public List<FiltroModel> especialidades { get; set; }
        public List<IntermedioTelefarmaciaModel> listaIntermedioTelefarmacia { get; set; }

        public void getGuiasDespacho(int id)
        {
            this.listaGuias = new List<GuiasModel>();
            IFATDetalleService _fatService = new FATDetalleService();
            this.listaGuias = DTOToModel.listaGuias(_fatService.guiasReceta(id));
        }

        public void getIntermedioTelefarmacia(string numeroAdmision)
        {
            this.listaIntermedioTelefarmacia = new List<IntermedioTelefarmaciaModel>();
            IFATDetalleService _fatService = new FATDetalleService();
            this.listaIntermedioTelefarmacia = DTOToModel.listaIntermedioTelefarmacia(_fatService.listaIntermedioTelefarmacia(numeroAdmision));
        }

        public void getListaFATReceta(string fecinicio, string fecfin, string busqueda, string espec, string estado)
        {
            this.listaAtencion = new List<LstFATModel>();
            IFATDetalleService _fatService = new FATDetalleService();
            this.listaAtencion = DTOToModel.listaFATModel(
            _fatService.bandejaRecetaFAT(fecinicio, fecfin, espec, busqueda, estado));
        }

    }
}