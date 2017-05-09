using AgeRanger.Domain.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgeRanger.Tests.Unit.Domain.Models
{
    [TestClass]
    public class ConsolidatedPersonTests
    {
        [TestMethod]
        [TestCategory("Unit-Models")]
        public void ConsolidatedPerson_Returns_Equivalent_Object()
        {
            var expected = new ConsolidatedPerson()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                Age = 10,
                AgeRangeDescription = "Child"
            };

            expected.Id.Should().Be(1);
            expected.FirstName.Should().Be("Bob");
            expected.LastName.Should().Be("Jones");
            expected.Age.Should().Be(10);
            expected.AgeRangeDescription.Should().Be("Child");
        }
    }
}
