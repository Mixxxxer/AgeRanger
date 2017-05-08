using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AgeRanger.Domain.Models;
using AgeRanger.Domain.Services;

namespace AgeRanger.Controllers
{
    public class PersonController : ApiController
    {

        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }
           
        public IEnumerable<ConsolidatedPerson> Get()
        {
            return personService.GetPersons();
        }

        public ConsolidatedPerson Get(long id)
        {
            var person = personService.GetPerson(id);
            if (person == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return person;
        }

        public HttpResponseMessage Post(ConsolidatedPerson person)
        {
            if(ModelState.IsValid)
            {
                var result = personService.AddPerson(person);
                if (result)
                {
                    var response = Request.CreateResponse(HttpStatusCode.Created, person);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = person.Id }));
                    return response;
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        public HttpResponseMessage Put(long id, ConsolidatedPerson person)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != person.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                var result = personService.UpdatePerson(id, person);

                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception);
            }
        }

        public HttpResponseMessage Delete(long id)
        {
            var person = personService.GetPerson(id);
            if (person == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                var result = personService.DeletePerson(id);

                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, person);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, exception);
            }
        }
    }
}
