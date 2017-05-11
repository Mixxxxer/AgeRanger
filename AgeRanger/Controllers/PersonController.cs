using System.Linq;
using System.Net;
using System.Web.Mvc;
using AgeRanger.Domain.Exceptions;
using AgeRanger.Domain.Models;
using AgeRanger.Domain.Services;
using AgeRanger.Models;

namespace AgeRanger.Controllers
{
    public class PersonController : Controller
    {
        #region Injected Members

        private readonly IPersonService personService;

        #endregion

        #region Constructor

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        #endregion

        #region Public Methods

        public ActionResult Index()
        {
            return View("Index");
        }

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

        public JsonResult GetAllPersons()
        {
            var persons = personService.GetPersons()
                .Select(x => new PersonViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    AgeRangeDescription = x.AgeRangeDescription
                });

            return Json(persons, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetPerson(long id)
        {
            var person = personService.GetPerson(id);
            if (person == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            return Json(new PersonViewModel()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                AgeRangeDescription = person.AgeRangeDescription
            }, JsonRequestBehavior.AllowGet);
        }

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
