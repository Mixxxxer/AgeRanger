using System.Collections.Generic;
using AgeRanger.Entities;

namespace AgeRanger.Interfaces.Data.Repositories
{
    public interface IRangeRepository
    {
        /// <summary>
        /// Returns a list of all Age Groups
        /// </summary>
        /// <returns></returns>
        IEnumerable<AgeGroup> GetAgeGroups();

        /// <summary>
        /// Returns a list of all Persons
        /// </summary>
        /// <returns></returns>
        IEnumerable<Person> GetPersons();
    }
}