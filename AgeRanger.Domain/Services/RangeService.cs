using System.Collections.Generic;
using System.Linq;
using AgeRanger.Domain.Models;
using AgeRanger.Interfaces.Data.Repositories;

namespace AgeRanger.Domain.Services
{
    public interface IRangeService
    {
        IList<Person> GetPersons();
    }

    public class RangeService : IRangeService
    {
        private readonly IRangeRepository rangeRepository;

        public RangeService(IRangeRepository rangeRepository)
        {
            this.rangeRepository = rangeRepository;
        }

        public IList<Person> GetPersons()
        {
            var persons = rangeRepository.GetPersons();
            var ranges = rangeRepository.GetAgeGroups();

            var personRanges = persons.Select(person => new Person()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                AgeRangeDescription = ranges.First(range => 
                    person.Age >= range.MinAge && person.Age < range.MaxAge).Description
            });

            return personRanges.ToList();
        }
    }
}
