using _1_CapaPresentacionGM.Models;
using _1_CapaPresentacionGM.Models.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_CapaPresentacionGM.Controllers
{
    public class TeleconsultaController : BaseController
    {
        public ActionResult ListadoTeleconsulta()
        {
            TeleconsultaViewModel teleconsultaViewModel = new TeleconsultaViewModel();
            teleconsultaViewModel.listarTeleconsulta("","","");
            return View(teleconsultaViewModel.teleconsultas);
        }
        public ActionResult Formulario(int id)
        {
            TeleconsultaViewModel teleconsultaViewModel = new TeleconsultaViewModel();
            teleconsultaViewModel.getTeleconsulta(id); 
            return View(teleconsultaViewModel.teleconsulta);
        }
        [HttpPost]
        public ActionResult Formulario(TeleconsultaModel teleconsulta)
        {
            TeleconsultaViewModel teleconsultaViewModel = new TeleconsultaViewModel();

            return View();
        }
        public JsonResult BuscarTeleconsulta(string fechaIncio, string fechaFin, string cmp)
        {
            TeleconsultaViewModel teleconsultaViewModel = new TeleconsultaViewModel();
            teleconsultaViewModel.listarTeleconsulta(fechaIncio, fechaFin,"");
            return Json(new { list = teleconsultaViewModel.teleconsultas }, JsonRequestBehavior.AllowGet);
        }
    }
}