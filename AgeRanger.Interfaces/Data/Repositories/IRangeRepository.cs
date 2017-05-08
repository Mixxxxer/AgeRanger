using System.Collections.Generic;
using AgeRanger.Entities;

namespace AgeRanger.Interfaces.Data.Repositories
{
    public interface IRangeRepository
    {
        /// <summary>
        /// Returns a list of all Age Groups
        /// </summary>
        IEnumerable<AgeGroup> GetAgeGroups();

        /// <summary>
        /// Returns a list of all Persons
        /// </summary>
        IEnumerable<Person> GetPersons();

        /// <summary>
        /// Finds a given person based on their Id
        /// </summary>
        /// <param name="id"></param>
        Person GetPerson(long id);
    }
}