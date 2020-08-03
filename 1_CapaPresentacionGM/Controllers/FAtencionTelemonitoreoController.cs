using _1_CapaPresentacionGM.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _1_CapaPresentacionGM.Controllers
{
    [RoutePrefix("FAT")]
    [Route("{action}")]
    public class FAtencionTelemonitoreoController : BaseSessionController
    {
        // GET: FAtencionTelemonitoreo

        [Route("BandejaFAT")]
        public ActionResult ListadoAtenciones()
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFat != 2)
                return View("SinAcceso");

            TeleconsultaViewModel atvm = new TeleconsultaViewModel();
            string[] filtros = new string[2];
            filtros = System.Web.HttpContext.Current.Session["filtrosFAT"] as string[];

            string fecini = (filtros != null) ? filtros[0] : DateTime.Now.ToString("dd/MM/yyyy"),
                fecfin = (filtros != null) ? filtros[1] : "";

            ViewBag.fecinicio = fecini;
            ViewBag.fecfin = fecfin;
            ViewBag.isAdmin = string.IsNullOrEmpty(UserLoginCache.CMP);
            if (string.IsNullOrEmpty(UserLoginCache.CMP)) { atvm.listaAtencion = new List<LstFATModel>(); }
            else
            {
                atvm.getListaFAT(fecini, fecfin);
            }
            return View(atvm.listaAtencion);
        }

        public ActionResult BuscarAtencion(string fecinicio, string fecfin)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFat != 2)
                return Json(new { list = "",rpta="Sin Acceso" }, JsonRequestBehavior.AllowGet);
            string[] filtros = new string[2] { fecinicio, fecfin };
            System.Web.HttpContext.Current.Session["filtrosFAT"] = filtros;
            TeleconsultaViewModel atvm = new TeleconsultaViewModel();
            if (string.IsNullOrEmpty(UserLoginCache.CMP)) { atvm.listaAtencion = new List<LstFATModel>(); }
            else
            {
                atvm.getListaFAT(fecinicio, fecfin);
            }
            return Json(new { list = atvm.listaAtencion }, JsonRequestBehavior.AllowGet);
        }


        [Route("GuardarFAT/{id}x0{bgs}")]
        public ActionResult FormularioAtencion(int id, int bgs)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFat != 2)
                return View("SinAcceso");

            TeleconsultaViewModel atvm = new TeleconsultaViewModel();
            atvm.getFAT(id);
         
            SelectViewModel select = new SelectViewModel();
            System.Web.HttpContext.Current.Session["firmaMed"] = atvm.atencionTM.firma;
            string rne = atvm.atencionTM.RNE;
            atvm.atencionTM.RNE = (string.IsNullOrEmpty(rne)) ? atvm.getRNe(UserLoginCache.CMP) : rne;
           // atvm.financiador = select.listaFinanciadorFAT();
            atvm.vias = select.listaViasAplicacion();
            atvm.tiempo = select.listaTiempoAplicacion();
            if (TempData["rpta"] != null)
                ViewBag.mensaje = TempData["rpta"] as string;
            return View(atvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GuardarFormularioAtencion(AtencionTmModel fat)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFat != 2)
                return View("SinAcceso");


            TeleconsultaViewModel atvm = new TeleconsultaViewModel();
            fat.firma = System.Web.HttpContext.Current.Session["firmaMed"] as byte[];
            fat.CMP = UserLoginCache.CMP;
            fat.Medico = UserLoginCache.NombreCompleto;

            await atvm.guardaFAT(fat);

            if (fat.medicinas.Count != 0)
            {
                await atvm.guardarReceta(fat,null);
            }
         
            int s = fat.laboratorio.Count + fat.radiologia.Count;
            int m = fat.medicinas.Count;
            TempData["rpta"] = (s > 0 && m > 0) ? "3" : (m > 0) ?"2": (s > 0)?"1":"";
           
            System.Web.HttpContext.Current.Session["firmaMed"] = null;
            return   RedirectToAction("FormularioAtencion", new { id = fat.idAtencion, bgs = 0 });
        }

        public ActionResult BuscarPaciente(string busquda)
        {
            if (isOutSession)
                return Json(new { outsession = isOutSession }, JsonRequestBehavior.AllowGet);
            else if (p.ListaFat != 2)
                return Json(new { result = "sin accesso" }, JsonRequestBehavior.AllowGet);
            PacienteViewModel pacvm = new PacienteViewModel();
            pacvm.buscarPacienteFAT(busquda);
            return Json(new { result = pacvm.paciente }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListarViaPorGrupoFarmaceutico(string codigoGrupo)
        {
          
            if (isOutSession)
                return Json(new { outsession = isOutSession }, JsonRequestBehavior.AllowGet);
            else if (p.ListaFat == 2 || p.ListaFATAdmEditor == 2)
            {
            SelectViewModel oSelectViewModel = new SelectViewModel();
            TeleconsultaViewModel atvm = new TeleconsultaViewModel();
            atvm.vias = oSelectViewModel.listaViasAplicacionPorCodigoGrupoFarmaceutico(codigoGrupo);
            return PartialView("_ListaVia", atvm);

            }else
                return View("SinAcceso");
        }

        public ActionResult ListarUnidadPrescripcionPorGrupoFarmaceutico(string codigoGrupo, string unidadVentaProducto)
        {
            if (isOutSession)
                return Json(new { outsession = isOutSession }, JsonRequestBehavior.AllowGet);
            else if (p.ListaFat == 2 || p.ListaFATAdmEditor == 2)
            {
            SelectViewModel oSelectViewModel = new SelectViewModel();
            TeleconsultaViewModel atvm = new TeleconsultaViewModel();
            atvm.unidadPrescripcion = oSelectViewModel.listaUnidadPrescripcionPorCodigoGrupoFarmaceutico(codigoGrupo, unidadVentaProducto);
            return PartialView("_ListaUnidadPrescripcion", atvm);

            }else
                return View("SinAcceso");
        }

    }
}