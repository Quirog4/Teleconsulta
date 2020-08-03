using _1_CapaPresentacionGM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_CapaPresentacionGM.Controllers
{
    public class UIAutocompleteController : BaseController
    {
        public ActionResult listDiagnostico(string term)
        {
            UIAutocompleteViewModel uIAutocompleteViewModel = new UIAutocompleteViewModel();
            uIAutocompleteViewModel.listarDiagnostico(term);
            return Json(new { list=uIAutocompleteViewModel.listDiagnostico }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult listRadiologia(string term)
        {
            UIAutocompleteViewModel uIAutocompleteViewModel = new UIAutocompleteViewModel();
            uIAutocompleteViewModel.listarRadiologia(term);
            return Json(new { list = uIAutocompleteViewModel.listRadiologia }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult listLaboratorio(string term)
        {
            UIAutocompleteViewModel uIAutocompleteViewModel = new UIAutocompleteViewModel();
            uIAutocompleteViewModel.listarLaboratorio(term);
            return Json(new { list = uIAutocompleteViewModel.listLaboratorio }, JsonRequestBehavior.AllowGet);
        }
    }
}