using _1_CapaPresentacionGM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_CapaPresentacionGM.Controllers
{
    public class FiltroAutocompleteController : Controller
    {
        // GET: FiltroAutocomplete
        [OutputCacheAttribute(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult getProcedimientos(string term)
        {
            SelectViewModel sel = new SelectViewModel();
            List<FiltroModel> lstProcedimientos = new List<FiltroModel>();
            lstProcedimientos = sel.listaProcedimiento(term);
            return Json(new { list = lstProcedimientos }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getMedicos(string term)
        {
            SelectViewModel sel = new SelectViewModel();
            List<FiltroModel> lista = new List<FiltroModel>();
            lista = sel.listaMedico(term);
            return Json(new { list = lista }, JsonRequestBehavior.AllowGet);
        }

        [OutputCacheAttribute(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult getDiagnosticos(string term)
        {
            SelectViewModel sel = new SelectViewModel();
            List<FiltroModel> lista = new List<FiltroModel>();
            lista = sel.listaDiagnosticos(term);
            return Json(new { list = lista }, JsonRequestBehavior.AllowGet);
        }

        [OutputCacheAttribute(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult getEquipos(string term)
        {
            SelectViewModel sel = new SelectViewModel();
            List<FiltroModel> lista = new List<FiltroModel>();
            lista = sel.listaEquipo(term);
            return Json(new { list = lista }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getInsumos(string term)
        {
            SelectViewModel sel = new SelectViewModel();
            List<FiltroModel> lista = new List<FiltroModel>();
            lista = sel.listaInsumo(term);
            return Json(new { list = lista }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getBeneficioForzados(string term)
        {
            AuditarCGViewModel avm = new AuditarCGViewModel();
            List<BeneficioModel> lista = avm.listaBeneficiosPS(term);
            return Json(new { rpta = lista }, JsonRequestBehavior.AllowGet);
        }
        [OutputCacheAttribute(Duration = 600, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult getLaboratorio(string term)
        {
            SelectViewModel svm = new SelectViewModel();
            List<FiltroModel> lista = new List<FiltroModel>();
            lista = svm.listarLaboratorios(term);
            return Json(new { list = lista }, JsonRequestBehavior.AllowGet);
        }
        [OutputCacheAttribute(Duration = 600, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult getRadiologia(string term)
        {
            SelectViewModel svm = new SelectViewModel();
            List<FiltroModel> lista = new List<FiltroModel>();
            lista = svm.listarRadiologias(term);
            return Json(new { list = lista }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getMedicamento(string descripcionPrincipioActivo, string descripcionProducto)
        {
            SelectViewModel sel = new SelectViewModel();
            List<MedicinasModel> lista = new List<MedicinasModel>();
            lista = sel.listaMedicamento(descripcionPrincipioActivo, descripcionProducto);
            return Json(new { list = lista }, JsonRequestBehavior.AllowGet);
        }

    }
}