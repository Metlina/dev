using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JavaFxToASPDotNet.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Knjiga()
        {
            ViewBag.Message = "Clan application page";

            return View("~/Views/Knjiga/Index.cshtml");
        }

        public ActionResult Casopis()
        {
            ViewBag.Message = "Clan application page";

            return View("~/Views/Casopis/Index.cshtml");
        }

        public ActionResult Clan()
        {
            ViewBag.Message = "Clan application page";

            return View("~/Views/Clan/Index.cshtml");
        }
    }
}