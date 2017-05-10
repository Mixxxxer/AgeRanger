using AgeRanger.Domain.Models;

namespace AgeRanger.Tests.Unit.Helpers
{
    public class ConsolidatedPersonBuilder
    {
        public static ConsolidatedPerson GetConsolidatedPerson()
        {
            return new ConsolidatedPerson() {Id = 1, FirstName = "Bob", LastName = "Jones", Age = 60};
        }
    }
}
