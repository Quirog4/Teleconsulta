using _1_CapaPresentacionGM.Models;
using _1_CapaPresentacionGM.Models.Reportes;
using CapaSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace _1_CapaPresentacionGM.Controllers
{
    [RoutePrefix("Reporte")]
    [Route("{action}")]
    public class GestionReporteCGController : BaseSessionController
    {
        // GET: GestionReporteCG

        public ActionResult GenerarCartaGarantia(int id, string codsolicitud)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            GenerarReporteCGViewModel grvm = new GenerarReporteCGViewModel();
            grvm.getArchivo(id, codsolicitud);
            var file = grvm.archivo;
            return File(file.pdf, "application/pdf");
        }

        // GET: GestionReporteCGring
        public ActionResult CartaGarantiaAuditada(string codsolicitud)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            GenerarReporteCGViewModel grvm = new GenerarReporteCGViewModel();
            grvm.getCartaAuditor(0, codsolicitud);

            return File(grvm.archivo.pdf, "application/pdf");

        }

        public ActionResult OrdenIntervecionQxBO(string codsolicitud)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            GenerarReporteCGViewModel grvm = new GenerarReporteCGViewModel();
            grvm.getReporteiq(codsolicitud);

            return File(grvm.archivo.pdf, "application/pdf");

        }

        [Route("FAT~{id}/{*tipo}")]
        public ActionResult FATReporte(int id, string tipo)
        {
            if (isOutSession)
                return RedirectToAction("OutSession", "Login");
            else if (p.ListaFATLaboratorio !=0 || p.ListaFATRadiologia !=0 || p.ListaFat != 0 || p.ListaFatAdmision != 0 || p.ListaFATReceta != 0)
            { 
            string[] t = tipo.Split('~');

            ConstantesCache.rutaArchivos = ConfigurationManager.AppSettings["rutaProyecto"];
            ConstantesCache.rutaImagen = ConfigurationManager.AppSettings["rutaImagen"];
            tipo = t[t.Length-1];
            ReportesFATViewModel grvm = new ReportesFATViewModel();
            grvm.getReporteFat(id, tipo);
            return File(grvm.archivo.pdf, "application/pdf");
            }
            else { return View("SinAcceso"); }

        }

        public ActionResult prueba()
        {
            //if (isOutSession)
            //    return RedirectToAction("OutSession", "Login");

            GenerarReporteCGViewModel grvm = new GenerarReporteCGViewModel();
            Prueba cartaPDF = new Prueba();
            var hoy = DateTime.Now;
            cartaPDF.imagen = @ViewBag.BaseURL + "/Img/Reportes/LogoPlanSalud.png";
            //  cartaPDF.tituloPrueba = "REPORTE PRUEBA";
            cartaPDF.fecha = hoy.ToString("dd/MM/yyyy");
            cartaPDF.hora = hoy.ToString("hh:mm tt");
            string ruta = "C:\\Users\\OTI03\\Desktop\\ProyectosCRP_Vquiroga\\GestionMedica-GURU\\1_CapaPresentacionGM\\Views\\GestionReporteCG\\pruebaFAT_PDF.html";//WebConfigurationManager.AppSettings.Get("rutaPlantillaCGAuditorPS");
            var archivo = grvm.generarCARTAGARANTIAPLANSALUDAUDITOR(ruta, cartaPDF);
            return File(archivo, "application/pdf");

        }

    }
}