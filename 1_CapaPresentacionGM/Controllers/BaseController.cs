using _1_CapaPresentacionGM.Models.Modelos;
using System.Web.Mvc;

namespace _1_CapaPresentacionGM.Controllers
{
    public class BaseController : Controller
    {
       protected UsuarioSessionModel usuario = new UsuarioSessionModel();
        public BaseController()
        {
            usuario = (System.Web.HttpContext.Current.Session["UserSession"] as UsuarioSessionModel) ?? new UsuarioSessionModel();
            ViewBag.usuario = usuario.User;
                ViewBag.nombreUsuario = usuario.UserName;
            if (usuario.Respuesta == 1)
            {

            }
        }
    }
}