using _2_CapaServiciosGM.DTO;
using CapaSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services;

namespace _1_CapaPresentacionGM.Controllers
{
    public class BaseSessionController : Controller//, System.Web.UI.Page
    {
        UsuarioSession usuario = new UsuarioSession();
        public Permisos p { get; internal set; } 
        public bool isOutSession = false;
        public BaseSessionController()
        {
            usuario = (System.Web.HttpContext.Current.Session["UserSession"] as UsuarioSession) ?? new UsuarioSession();
            ViewBag.BaseURL = System.Web.HttpContext.Current.Session["URL"] as string;
            isOutSession = (usuario.respuesta!=1);
            UserLoginCache.Password = usuario.pass;
            ViewBag.usuario = usuario.usuario;
            if (usuario.respuesta==1)
            {
                ViewBag.nombreUsuario = usuario.nombreUsuario;
                UserLoginCache.User = usuario.usuario;
                UserLoginCache.NombreCompleto = (usuario.usermed!=null)?usuario.usermed.nombreMedico:usuario.nombreUsuario;
                if (usuario.usermed != null)
                {
                    UserLoginCache.CMP = usuario.usermed.cmp;
                    ViewBag.codEspecialidad = usuario.usermed.especialidadCodigo;
                }
                ViewBag.userName = usuario.usuarioName;
                ViewBag.tipoUsuario = usuario.tipoUsuario;
                UserLoginCache.changePass = usuario.tipoUsuario==1;// si es tipo directorio activo
                UserLoginCache.IpAddress = System.Web.HttpContext.Current.Session["EQUIPO"] as string;
                p = System.Web.HttpContext.Current.Session["MENU"] as Permisos;
                if (p != null)
                {
                    ViewBag.menuAtenciones = p.VerAtenciones;
                    ViewBag.menuVerCarta = p.BuscarCG;
                    ViewBag.menuServicios = p.ServicioPS;
                    ViewBag.menuAuditor = p.AuditorPS;
                    ViewBag.menuOiqx = p.OIQuirurgico;
                    ViewBag.menuProcesoPreqx = p.ProcesoPreQx;
                    ViewBag.menuProgramSala= p.ProgramarSala;
                    ViewBag.menuListaFat = p.ListaFat;
                    ViewBag.menuListaFatAdmision = p.ListaFatAdmision;
                    ViewBag.menuFAT =( p.ListaFatAdmision!=0 || p.ListaFat!=0 || p.ListaFATLaboratorio!=0 || p.ListaFATRadiologia !=0 || p.ListaFATReceta!=0) ?1:0;
                    ViewBag.menuFatRadiologia = p.ListaFATRadiologia ;
                    ViewBag.menuFatLaboratorio = p.ListaFATLaboratorio;
                    ViewBag.menuListaFatAdmEditor = p.ListaFATAdmEditor;
                    ViewBag.menuListaFatReceta = p.ListaFATReceta;
                    PermisosSKA.FatRadiologia = p.ListaFATRadiologia;
                    PermisosSKA.FatLaboratorio = p.ListaFATLaboratorio;
                }
                else
                {
                    p = new Permisos();
                }
            }else
            {

                UserLoginCache.changePass = usuario.respuesta == 2;// si ingresa por primera ves
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["datos"] = true;
            string sesion = Session["Login"].ToString();
            string aplication = Session["App"].ToString();
        }


        //[WebMethod]
        //public static bool KeepActiveSession()
        //{
        //    if (HttpContext.Current.Session["datos"] != null)
        //        return true;
        //    else
        //        return false;
        //}

        //[WebMethod]
        //public static void SessionAbandon()
        //{
        //    HttpContext.Current.Session.Remove("datos");
        //}

    }
}