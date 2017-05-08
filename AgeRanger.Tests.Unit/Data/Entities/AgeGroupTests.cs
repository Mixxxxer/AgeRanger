using AgeRanger.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgeRanger.Tests.Unit.Data.Entities
{
    [TestClass]
    public class AgeGroupTests
    {
        private const string Description = "Test";

        [TestMethod]
        [TestCategory("Unit-Entities")]
        public void AgeGroup_Returns_Equivalent_Object()
        {
            var expected = new AgeGroup()
            {
                Id = 1,
                MinAge = 0,
                MaxAge = int.MaxValue,
                Description = Description.ToLower()
            };

            expected.Id.Should().Be(1);
            expected.MinAge.Should().Be(0);
            expected.MaxAge.Should().Be(int.MaxValue);
            expected.Description.Should().Be(Description.ToLower());
        }

        [TestMethod]
        [TestCategory("Unit-Entities")]
        public void AgeGroup_MinAge_Can_Be_Null()
        {
            var expected = new AgeGroup()
            {
                MinAge = null
            };

            expected.MinAge.Should().BeNull();
        }

        [TestMethod]
        [TestCategory("Unit-Entities")]
        public void AgeGroup_MaxAge_Can_Be_Null()
        {
            var expected = new AgeGroup()
            {
                MaxAge = null
            };

            expected.MaxAge.Should().BeNull();
        }
    }
}
