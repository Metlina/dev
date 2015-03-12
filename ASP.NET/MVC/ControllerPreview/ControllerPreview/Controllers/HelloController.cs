using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerPreview.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }

        public string HelloWorld()
        {
            return "Hello World";
        }

        public string HelloName(string name, int ID = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + ". " + ID + " times!");
        }
    }
}