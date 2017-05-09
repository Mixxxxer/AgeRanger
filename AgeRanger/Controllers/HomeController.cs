using System.Web.Mvc;

namespace AgeRanger.Controllers
{
    public class HomeController : Controller
    {
        #region Public Methods

        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}