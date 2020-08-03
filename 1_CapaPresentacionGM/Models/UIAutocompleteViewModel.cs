using _1_CapaPresentacionGM.Models.Modelos;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System.Collections.Generic;

namespace _1_CapaPresentacionGM.Models
{
    public class UIAutocompleteViewModel
    {
        public List<UIAutocompleteModel> listDiagnostico;
        public List<UIAutocompleteModel> listRadiologia;
        public List<UIAutocompleteModel> listLaboratorio;

        public void listarDiagnostico(string term)
        {
            this.listDiagnostico = new List<UIAutocompleteModel>();
            IAutocompleteService service = new AutompleteService();
            var lst = service.listaDiagnostico(term);
            this.listDiagnostico = EntityToModel.listaAutocomplete(lst);
        }

        public void listarLaboratorio(string term)
        {
            this.listLaboratorio = new List<UIAutocompleteModel>();
            IAutocompleteService service = new AutompleteService();
            var lst = service.listaLaboratorio(term);
            this.listLaboratorio = EntityToModel.listaAutocomplete(lst);

        }

        public void listarRadiologia(string term)
        {
            this.listRadiologia = new List<UIAutocompleteModel>();
            IAutocompleteService service = new AutompleteService();
            var lst = service.listaRadiologia(term);
            this.listRadiologia = EntityToModel.listaAutocomplete(lst);
        }
    }
}