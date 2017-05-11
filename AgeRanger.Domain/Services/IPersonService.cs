using System.Collections.Generic;
using AgeRanger.Domain.Models;

namespace AgeRanger.Domain.Services
{
    public interface IPersonService
    {
        #region Public Methods

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
        bool UpdatePerson(ConsolidatedPerson person);

        #endregion  
    }
}