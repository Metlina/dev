using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JavaFXToASPNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }

        public ActionResult Knjiga()
        {
            ViewBag.Message = "Knjiga application page";

            return View("~/Views/Knjiga/Index.cshtml");
        }

        public ActionResult Casopis()
        {
            ViewBag.Message = "Casopis application page";

            return View("~/Views/Casopis/Index.cshtml");
        }

        public ActionResult Clan()
        {
            ViewBag.Message = "Clan application page";

            return View("~/Views/Clan/Index.cshtml");
        }
    }
}