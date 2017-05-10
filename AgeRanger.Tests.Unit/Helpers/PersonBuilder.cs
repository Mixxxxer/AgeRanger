using AgeRanger.Entities;

namespace AgeRanger.Tests.Unit.Helpers
{
    public class PersonBuilder
    {
        public static Person GetPerson()
        {
            return new Person() {Id = 1, FirstName = "Bob", LastName = "Jones", Age = 60};
        }
    }
}
