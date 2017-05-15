using System.Web.Mvc;

namespace AgeRanger.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Age Ranger API";

            return View();
        }
    }
}
