using System.Collections.Generic;
using AgeRanger.Domain.Models;
using AgeRanger.Models;

namespace AgeRanger.Helpers
{
    public interface IPersonViewModelHelper
    {
        /// <summary>
        /// Transforms ConsolidatedPerson to PersonViewModel
        /// </summary>
        PersonViewModel FromConsolidatedPerson(ConsolidatedPerson consolidatedPerson);

        /// <summary>
        /// Transforms a list of ConsolidatedPerson to a list of PersonViewModel
        /// </summary>
        IEnumerable<PersonViewModel> FromConsolidatedPersons(IList<ConsolidatedPerson> persons);
    }
}