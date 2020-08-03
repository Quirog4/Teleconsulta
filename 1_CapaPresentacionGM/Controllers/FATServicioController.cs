using _1_CapaPresentacionGM.Models;
using CapaSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_CapaPresentacionGM.Controllers
{
    public class FATServicioController : BaseSessionController
    {
        // GET: FATServicio
        public ActionResult BandejaServicio()
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");

            else if (p.ListaFATLaboratorio == 0 || p.ListaFATRadiologia==0)
                return View("SinAcceso");
            ViewBag.fecinicio = DateTime.Now.ToString("dd/MM/yyyy");
            ViewBag.Servicio = (PermisosSKA.FatRadiologia == 2 || PermisosSKA.FatLaboratorio==2) ? "Todo" :
                (PermisosSKA.FatLaboratorio == 2) ? "Laboratorio" :  "Radiología";
            TeleconsultaViewModel atvm = new TeleconsultaViewModel();
            atvm.getListaFATServicios("", "","", "");
            SelectViewModel select = new SelectViewModel();
            atvm.especialidades = select.listaEspecialidadesMedicas();
            return View(atvm);
        }
        public ActionResult BuscarServicio(string fecinicio, string fecfin, string busqueda, string espec)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFATLaboratorio == 0 || p.ListaFATRadiologia == 0)
                return View("SinAcceso");
            TeleconsultaViewModel atvm = new TeleconsultaViewModel();
            atvm.getListaFATServicios(fecinicio, fecfin, busqueda, espec);
            return Json(new { list = atvm.listaAtencion }, JsonRequestBehavior.AllowGet);
        }

    }
}