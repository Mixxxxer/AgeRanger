using System.Net;
using System.Web.Mvc;
using AgeRanger.Domain.Exceptions;
using AgeRanger.Domain.Models;
using AgeRanger.Domain.Services;
using AgeRanger.Helpers;

namespace AgeRanger.Controllers
{
    public class PersonController : Controller
    {
        #region Injected Members

        private readonly IPersonService personService;

        private readonly IPersonViewModelHelper personViewModelHelper;

        #endregion

        #region Constructor

        public PersonController(IPersonService personService, 
            IPersonViewModelHelper personViewModelHelper)
        {
            this.personService = personService;
            this.personViewModelHelper = personViewModelHelper;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult AddPerson(ConsolidatedPerson person)
        {
            if (ModelState.IsValid)
            {
                var result = personService.AddPerson(person);
                if (result)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult DeletePerson(long id)
        {
            var person = personService.GetPerson(id);
            if (person == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }

            try
            {
                personService.DeletePerson(id);
            }
            catch (PersonException personException)
            {
                return Json(personException.Message, JsonRequestBehavior.DenyGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpGet]
        public JsonResult GetAllPersons()
        {
            var persons = personService.GetPersons();

            return Json(personViewModelHelper.FromConsolidatedPersons(persons), 
                JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult GetPerson(long id)
        {
            var person = personService.GetPerson(id);
            if (person == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            return Json(personViewModelHelper.FromConsolidatedPerson(person), 
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdatePerson(ConsolidatedPerson person)
        {
            try
            {
                personService.UpdatePerson(person);
            }
            catch (PersonException personException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, personException.Message);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        #endregion
    }
}
