using AgeRanger.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgeRanger.Tests.Unit.Data.Entities
{
    [TestClass]
    public class PersonTests
    {

        [TestMethod]
        [TestCategory("Unit-Entities")]
        public void Person_Returns_Equivalent_Object()
        {
            var expected = new Person()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                Age = 10
            };

            expected.Id.Should().Be(1);
            expected.FirstName.Should().Be("Bob");
            expected.LastName.Should().Be("Jones");
            expected.Age.Should().Be(10);
        }
    }
}
