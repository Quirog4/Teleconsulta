using System;
using System.Web.Configuration;
using System.Web.Mvc;

namespace _1_CapaPresentacionGM.Controllers
{
    public class HomeController: BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}