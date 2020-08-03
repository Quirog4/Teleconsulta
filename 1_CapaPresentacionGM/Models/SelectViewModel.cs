using System;
using System.Collections.Generic;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System.Linq;
using System.Web;
using _1_CapaPresentacionGM.Models.Mapper;

namespace _1_CapaPresentacionGM.Models
{
    public class FiltroModel
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }

    public class SelectViewModel
    {
        public List<FiltroModel> lstEspecialides;
        public List<FiltroModel> lstEstados;
        public List<FiltroModel> lstEstadoAuditor;
        public List<FiltroModel> lstTipoAtencion;
        public List<FiltroModel> motivoEstado;
        public List<FiltroModel> tipoDocumentoPS;
        public List<FiltroModel> lstRadiologia;
        public List<FiltroModel> lstLaboratorio;

        public List<FiltroModel> listaEspecialidades()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selEspecialidades())
                                    ?? new List<FiltroModel>();
        }

        public  List<string> estadosRp()
        {
            IFATDetalleService service = new FATDetalleService();
            return service.estadosReceta();
        }

        public List<FiltroModel> listaEstados()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selEstado())
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaEstadosAuditoria()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selEstadoAuditoria())
                                    ?? new List<FiltroModel>();
        }
        public List<FiltroModel> listaTipoAnestesia()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selTipoAnestesia())
                                    ?? new List<FiltroModel>();
        }
        public string anexoProgSala()
        {
            IFiltrosService service = new FiltroService();
            return service.anexoProgramadorSala();
        }

        public List<FiltroModel> listaTipoDocumento()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selTipoDocumento())
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaEstadosAuditor()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selEstadoAuditor())
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaFinanciadorFAT()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selFinanciadorFAT())
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listarLaboratorios(string term)
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selLaboratorio(term))
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaTiempoAplicacion()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selTiempoMedicacion())
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaViasAplicacion()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selViaMedicacion())
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaViasAplicacionPorCodigoGrupoFarmaceutico(string codigoGrupo)
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selViaMedicacionPorCodigoGrupoFarmaceutico(codigoGrupo))
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaUnidadPrescripcionPorCodigoGrupoFarmaceutico(string codigoGrupo, string unidadVentaProducto)
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selUnidadPrescripcionPorCodigoGrupoFarmaceutico(codigoGrupo, unidadVentaProducto))
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaFinanciador()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selFinanciador())
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listarRadiologias(string term)
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selRadiologia(term))
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaTipoCirugia()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selTipoCirugia())
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaEstadosPreQx()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selEstadoPreQx())
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaEspecialidadesMedicas()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selEspecialidadesMedicas())
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaSala()
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selSala())
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaCriterioEstadoPreQx(string codigo)
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selCriterioEstadoPreQx(codigo))
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaMotivoEstadoAuditor(string codigo)
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selMotivoEstadoAuditor(codigo))
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaProcedimiento(string proced)
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selProcedimiento(proced))
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaDiagnosticos(string diag)
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selDiagnostico(diag))
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaMedico(string med)
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selMedicos(med))
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaEquipo(string term)
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selEquipo(term))
                                    ?? new List<FiltroModel>();
        }

        public List<FiltroModel> listaInsumo(string term)
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.filtroModel(service.selInsumo(term))
                                    ?? new List<FiltroModel>();
        }

        public List<MedicinasModel> listaMedicamento(string descripcionPrincipioActivo, string descripcionProducto)
        {
            IFiltrosService service = new FiltroService();
            return DTOToModel.listMedicinasParaReceta(service.selMedicamento(descripcionPrincipioActivo, descripcionProducto)) ?? new List<MedicinasModel>();
        }
    }
}