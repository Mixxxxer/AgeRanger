using System.Collections.Generic;
using System.Linq;
using AgeRanger.Domain.Models;
using AgeRanger.Models;

namespace AgeRanger.Helpers
{
    public class PersonViewModelHelper : IPersonViewModelHelper
    {
        public IEnumerable<PersonViewModel> FromConsolidatedPersons(IList<ConsolidatedPerson> persons)
        {
            return persons
                .Select(x => new PersonViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    AgeRangeDescription = x.AgeRangeDescription
                });
        }

        public PersonViewModel FromConsolidatedPerson(ConsolidatedPerson consolidatedPerson)
        {
            return new PersonViewModel()
            {
                Id = consolidatedPerson.Id,
                FirstName = consolidatedPerson.FirstName,
                LastName = consolidatedPerson.LastName,
                Age = consolidatedPerson.Age,
                AgeRangeDescription = consolidatedPerson.AgeRangeDescription
            };
        }
    }
}