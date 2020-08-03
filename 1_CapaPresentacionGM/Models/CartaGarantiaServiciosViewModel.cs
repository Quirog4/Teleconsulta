using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{
  
    public class CartaGarantiaServiciosViewModel
    {
        public List<FiltroModel> lstTipoAtencion;
        public List<FiltroModel> lstTipoDocumentos;
        public List<FiltroModel> lstMedico;
        public List<FiltroModel> lstDiagnosticoCIE;
        public List<FiltroModel> lstEspecialidades;
        public List<FiltroModel> lstProcedimientos;
        public CartaGarantiaModel cartaG;
        public PacienteModel paciente;
        public PlanSaludModel plan;
        public List<lstCartaGarantiaModel> cartas;

        public void getCartaServicio(int idSolicitud,string departamento)
        {
            ICartaGarantiaService service = new CartaGarantiaService();
            this.cartaG = new CartaGarantiaModel();
            var carta = service.getCarta(idSolicitud, departamento);
            carta.paciente.plan.beneficios = carta.paciente.plan.beneficios.Where(x => x.seleccionado).ToList();

            this.cartaG = DTOToModel.CartaGarantiaPSModel(carta);
        }

        public void getCombos()
        {
            SelectViewModel select = new SelectViewModel();
            this.lstEspecialidades = new List<FiltroModel>();
            this.lstEspecialidades = select.listaEspecialidades();
            this.lstTipoDocumentos = new List<FiltroModel>();
            this.lstTipoDocumentos = select.listaTipoDocumento();
        }

        public void listadoCartas(String busqueda, string fechaini, string fecfin, string tipoAt, string codestado)
        {
            ICartaGarantiaService service = new CartaGarantiaService();
            this.cartas = new List<lstCartaGarantiaModel>();
            this.cartas = DTOToModel.listarCartasGarantiaServicio(
                                service.bandejaAuditServ(busqueda, tipoAt, fechaini, fecfin, codestado)
                                );
        }

        public int guardarCarta(CartaGarantiaModel carta,PlanSaludModel plan,PacienteModel paciente,List<string> procedimientos,string usuario,string equipo,ArchivoModel archivo)
        {
            ICartaGarantiaService cartaserv = new CartaGarantiaService();

            var cartaps = ModelDTO.cartaDTO(carta, plan, paciente);
            int result = cartaserv.guardarCarta(cartaps, usuario, equipo,
                ModelDTO.beneficiosDTO(plan.beneficios)
                , procedimientos,ModelDTO.archivoDTO(archivo));
            return result;
        }



    }
}