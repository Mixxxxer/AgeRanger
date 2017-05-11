using System.Collections.Generic;
using System.Linq;
using AgeRanger.Domain.Models;
using AgeRanger.Entities;

namespace AgeRanger.Domain.Helpers
{
    public class PersonServiceHelper : IPersonServiceHelper
    {
        public string GetDescriptionForAge(IEnumerable<AgeGroup> ageGroups, int age)
        {
            return ageGroups.First(range => age >= range.MinAge && age < range.MaxAge).Description;
        }

        public Person ToEntity(ConsolidatedPerson consolidatedPerson)
        {
            return new Person()
            {
                Id = consolidatedPerson.Id,
                FirstName = consolidatedPerson.FirstName,
                LastName = consolidatedPerson.LastName,
                Age = consolidatedPerson.Age
            };
        }

        public ConsolidatedPerson ToConsolidatedPerson(IEnumerable<AgeGroup> ageGroups, Person person)
        {
            return new ConsolidatedPerson()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                AgeRangeDescription = GetDescriptionForAge(ageGroups, person.Age)
            };
        }

        public IEnumerable<ConsolidatedPerson> ToConsolidatedPersons(IEnumerable<AgeGroup> ageGroups,
            IEnumerable<Person> persons)
        {
            return persons.Select(person => new ConsolidatedPerson()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                AgeRangeDescription = GetDescriptionForAge(ageGroups, person.Age)
            });
        }
    }
}
