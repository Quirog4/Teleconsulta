using _1_CapaPresentacionGM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_CapaPresentacionGM.Controllers
{
    public class FATRecetaController : BaseSessionController
    {
        // GET: FATReceta
        public ActionResult BandejaReceta()
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFATReceta == 0)
                return View("SinAcceso");
            TelefarmaciaViewModel atvm = new TelefarmaciaViewModel();
            atvm.getListaFATReceta("", "", "", "","REVISAR");
            SelectViewModel select = new SelectViewModel();
            atvm.especialidades = select.listaEspecialidadesMedicas();
            atvm.estadosRp = select.estadosRp();
            return View(atvm);
        }

        public ActionResult BuscarReceta(string fecinicio, string fecfin, string busqueda, string espec,string estado)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFATReceta == 0)
                return View("SinAcceso");
            TelefarmaciaViewModel atvm = new TelefarmaciaViewModel();
            atvm.getListaFATReceta(fecinicio,fecfin, busqueda, espec, estado);
            return Json(new { list = atvm.listaAtencion }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetGuias(int id)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFATReceta == 0)
                return View("SinAcceso");
            TelefarmaciaViewModel atvm = new TelefarmaciaViewModel();
            atvm.getGuiasDespacho(id);
            return Json(new { list = atvm.listaGuias}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetIntermedioTelefarmacia(string numeroAdmision)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFATReceta == 0)
                return View("SinAcceso");

            TelefarmaciaViewModel atvm = new TelefarmaciaViewModel();
            atvm.getIntermedioTelefarmacia(numeroAdmision);

            return Json(new { list = atvm.listaIntermedioTelefarmacia }, JsonRequestBehavior.AllowGet);
        }
    }
}