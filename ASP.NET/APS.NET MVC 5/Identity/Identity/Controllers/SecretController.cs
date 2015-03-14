using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    [Authorize]
    public class SecretController : Controller
    {
        // GET: Secret
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ContentResult Secret()
        {
            return Content("This is a secret...");
        }

        [AllowAnonymous]
        public ContentResult Overt()
        {
            return Content("This is not a secret...");
        }
    }
}