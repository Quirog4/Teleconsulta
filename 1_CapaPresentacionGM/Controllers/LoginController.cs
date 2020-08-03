using _1_CapaPresentacionGM.Models;
using _1_CapaPresentacionGM.Models.Modelos;
using System;
using System.Web.Mvc;

namespace _1_CapaPresentacionGM.Controllers
{
    public class LoginController : Controller
    {

        [AllowAnonymous]
        public ActionResult Acceso()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Acceso(string usuario, string password)
        {
            UsuarioViewModel _uservm = new UsuarioViewModel();
            UsuarioSessionModel useSession = _uservm.ValidarUsuario(usuario, password);
            System.Web.HttpContext.Current.Session["UserSession"] = useSession;
            return RedirectToAction("Index", "Home");
        }



        public ActionResult OutSession()
        {
            System.Web.HttpContext.Current.Session["UserSession"] = null;
            return RedirectToAction("Acceso", "Login");
        }

    }
}