using _1_CapaPresentacionGM.Models;
using CapaSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _1_CapaPresentacionGM.Controllers
{
    [RoutePrefix("FATAdmin")]
    [Route("{action}")]
    public class FATAdmisionController : BaseSessionController
    {
        [Route("BandejaAdmisionFAT")]
        public ActionResult ListadoAtencionesAdmCG()
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFatAdmision != 2)
                return View("SinAcceso");
            FATAdminViewModel atvm = new FATAdminViewModel();

            string[] filtros = new string[5];
            int id;
            filtros = System.Web.HttpContext.Current.Session["filtrosFATGS"] as string[];
            id = System.Web.HttpContext.Current.Session["filtrosFATGSEstado"] as int? ?? 12;

            if (filtros != null)
            {
                ViewBag.fecinicio = filtros[0];
                ViewBag.fecfin = filtros[1];
                ViewBag.busqueda = filtros[2];
                ViewBag.medico = filtros[3];
                ViewBag.espec = filtros[4];
                ViewBag.estado = id;
                atvm.getListaFATAdmGS(filtros[0], filtros[1], filtros[2], filtros[3], id, filtros[4]);
            }
            else
            {
                ViewBag.fecinicio = DateTime.Now.ToString("dd/MM/yyyy");
                ViewBag.fecfin = "";
                ViewBag.busqueda = "";
                ViewBag.medico = "";
                ViewBag.espec = "";
                ViewBag.estado = id;
                atvm.getListaFATAdmGS(DateTime.Now.ToString("dd/MM/yyyy"), "", "", "", id, "");
            }
            SelectViewModel select = new SelectViewModel();
            atvm.especialidades = select.listaEspecialidadesMedicas();
            return View(atvm);
        }

        public ActionResult BuscarAtencionGS(string fecinicio, string fecfin, string busqueda, string medico, string espec, int estado)
        {

            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFatAdmision != 2)
                return View("SinAcceso");
            string[] filtros = new string[5] { fecinicio, fecfin, busqueda, medico, espec };
            System.Web.HttpContext.Current.Session["filtrosFATGS"] = filtros;
            System.Web.HttpContext.Current.Session["filtrosFATGSEstado"] = estado;

            FATAdminViewModel atvm = new FATAdminViewModel();
            atvm.getListaFATAdmGS(fecinicio, fecfin, busqueda, espec, estado, medico);
            return Json(new { list = atvm.listaAtencion }, JsonRequestBehavior.AllowGet);
        }


        [Route("Formulario/{id}")]
        public ActionResult FormularioAtencion(int id)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFatAdmision != 2)
                return View("SinAcceso");

            TeleconsultaViewModel atvm = new TeleconsultaViewModel();
            SelectViewModel select = new SelectViewModel();
            int cod = id;

            atvm.getFAT(cod);
            System.Web.HttpContext.Current.Session["firmaMed"] = atvm.atencionTM.firma;
            System.Web.HttpContext.Current.Session["cmp"] = atvm.atencionTM.CMP;
            System.Web.HttpContext.Current.Session["nombreMed"] = atvm.atencionTM.Medico;

            string rne = atvm.atencionTM.RNE;
            atvm.atencionTM.RNE = (string.IsNullOrEmpty(rne)) ? atvm.getRNe(UserLoginCache.CMP) : rne;
            atvm.atencionTM.isEditable = (p.ListaFATAdmEditor == 2);
            atvm.financiador = select.listaFinanciadorFAT();
            atvm.vias = select.listaViasAplicacion();
            atvm.tiempo = select.listaTiempoAplicacion();
            if (TempData["rpta"] != null)
                ViewBag.mensaje = TempData["rpta"] as string;
            return View(atvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GuardarFormularioAtencion(AtencionTmModel fat, List<DiagnosticosModel> di)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFATAdmEditor != 2) 
                return View("SinAcceso");

            TeleconsultaViewModel atvm = new TeleconsultaViewModel();
            FATAdminViewModel adminvm = new FATAdminViewModel();
            fat.firma = System.Web.HttpContext.Current.Session["firmaMed"] as byte[];
            fat.CMP = System.Web.HttpContext.Current.Session["cmp"] as string;
            fat.Medico = System.Web.HttpContext.Current.Session["nombreMed"] as string;

            await adminvm.guardaFAT(fat);
            if (fat.medicinas.Count != 0)
            {
                await atvm.guardarReceta(fat, di);
            }


            int s = fat.laboratorio.Count + fat.radiologia.Count;
            int m = fat.medicinas.Count;
            if (s > 0 && m > 0)
                TempData["rpta"] = "3";
            else if (m > 0)
                TempData["rpta"] = "2";
            else if (s > 0)
                TempData["rpta"] = "1";

            System.Web.HttpContext.Current.Session["firmaMed"] = null;
            System.Web.HttpContext.Current.Session["cmp"] = "";
            System.Web.HttpContext.Current.Session["nombreMed"] = "";
            return RedirectToAction("Formulario/" + fat.idAtencion);
        }


        public ActionResult eliminaDetalleFat(int id, string tipo, string codigo)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFATAdmEditor != 2)
                return View("SinAcceso");

            TeleconsultaViewModel oiq = new TeleconsultaViewModel();
            oiq.eliminaDetalleFat(id, tipo, codigo);
            return Json(new { result = true }, JsonRequestBehavior.AllowGet);

        }

    }
}