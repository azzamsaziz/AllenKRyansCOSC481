using System.Web.Mvc;

namespace AllenKRyansCOSC481.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Cart()
        {
            ViewBag.Message = "Your Cart page";
            return View();
        }

        public ActionResult Menu()
        {
            ViewBag.Message = "Your Menu page";
            return View();
        }

    }
}