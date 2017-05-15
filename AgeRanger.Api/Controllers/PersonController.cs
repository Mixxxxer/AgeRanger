using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgeRanger.Domain.Models;
using AgeRanger.Domain.Services;

namespace AgeRanger.Api.Controllers
{
    [Authorize]
    public class PersonController : ApiController
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]ConsolidatedPerson person)
        {
            try
            {
                personService.UpdatePerson(person);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
