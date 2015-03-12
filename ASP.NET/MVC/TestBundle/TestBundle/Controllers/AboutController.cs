using System.Web.Mvc;

namespace TestBundle.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}