using AgeRanger.Domain.Models;
using AgeRanger.Models;

namespace AgeRanger.Helpers
{
    public interface IPersonViewModelHelper
    {
        PersonViewModel FromConsolidatedPerson(ConsolidatedPerson consolidatedPerson);
    }

    public class PersonViewModelHelper : IPersonViewModelHelper
    {
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