using System.Collections.Generic;
using System.Linq;

using AgeRanger.Domain.Models;
using AgeRanger.Entities;
using AgeRanger.Interfaces.Data.Repositories;

namespace AgeRanger.Domain.Services
{
    public interface IPersonService
    {
        /// <summary>
        /// Adds a new person to the repository
        /// </summary>
        bool AddPerson(ConsolidatedPerson person);

        /// <summary>
        /// Removes a person from the repository
        /// </summary>
        bool DeletePerson(long id);

        /// <summary>
        /// Finds a person based on the given Id
        /// </summary>
        ConsolidatedPerson GetPerson(long id);

        /// <summary>
        /// Returns a list of all known persons
        /// </summary>
        IList<ConsolidatedPerson> GetPersons();

        /// <summary>
        /// Updates the details of a person based on the given Id
        /// </summary>
        bool UpdatePerson(long id, ConsolidatedPerson person);
    }

    public class PersonService : IPersonService
    {
        private readonly IRangeRepository rangeRepository;

        public PersonService(IRangeRepository rangeRepository)
        {
            this.rangeRepository = rangeRepository;
        }

        public bool AddPerson(ConsolidatedPerson person)
        {
            return false;
        }

        public bool DeletePerson(long id)
        {
            return false;
        }

        public string GetDescriptionForAge(IEnumerable<AgeGroup> ageGroups, int age)
        {
            return ageGroups.First(range => age >= range.MinAge && age < range.MaxAge).Description;
        }

        public ConsolidatedPerson GetPerson(long id)
        {
            var person = rangeRepository.GetPerson(id);

            if (person == null)
                return null;

            var ageGroups = rangeRepository.GetAgeGroups();

            return new ConsolidatedPerson()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                AgeRangeDescription = GetDescriptionForAge(ageGroups, person.Age)
            };
        }

        public IList<ConsolidatedPerson> GetPersons()
        {
            var persons = rangeRepository.GetPersons();
            var ageGroups = rangeRepository.GetAgeGroups();

            var personRanges = persons.Select(person => new ConsolidatedPerson()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                AgeRangeDescription = GetDescriptionForAge(ageGroups, person.Age)
            });

            return personRanges.ToList();
        }

        public bool UpdatePerson(long id, ConsolidatedPerson person)
        {
            return false;
        }
    }
}
