using System.Web.Mvc;

namespace TestBundle.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}