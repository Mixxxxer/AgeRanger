using System.Collections.Generic;
using AgeRanger.Domain.Models;
using AgeRanger.Entities;

namespace AgeRanger.Domain.Helpers
{
    public interface IPersonServiceHelper
    {
        /// <summary>
        /// Get a decription for a particular page
        /// </summary>
        string GetDescriptionForAge(IEnumerable<AgeGroup> ageGroups, int age);

        /// <summary>
        /// Transforms to a ConsolidatedPerson
        /// </summary>
        ConsolidatedPerson ToConsolidatedPerson(IEnumerable<AgeGroup> ageGroups, Person person);

        /// <summary>
        /// Transform to ConsolidatedPersons
        /// </summary>
        IEnumerable<ConsolidatedPerson> ToConsolidatedPersons(IEnumerable<AgeGroup> ageGroups,
            IEnumerable<Person> persons);

        /// <summary>
        /// Transform to a Person
        /// </summary>
        Person ToEntity(ConsolidatedPerson consolidatedPerson);
    }
}