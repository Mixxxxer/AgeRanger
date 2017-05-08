using System.Linq;
using AgeRanger.Data.Contexts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgeRanger.Tests.Integration.Data
{
    [TestClass]
    public class SqLiteTests
    {
        [TestMethod]
        [TestCategory("Integration-Data")]
        public void SqlLite_Default_Timeout_Is_120()
        {
            using (var context = new RangeDbContext())
            {
                context.DefaultTimeout.Should().Be(120);
            }
        }

        [TestMethod]
        [TestCategory("Integration-Data")]
        public void SqlLite_Extended_Timeout_Is_1200()
        {
            using (var context = new RangeDbContext())
            {
                context.ExtendedTimeout.Should().Be(1200);
            }
        }

        [TestMethod]
        [TestCategory("Integration-Data")]
        public void SqlLite_Initialises_And_Seeds_AgeGroups()
        {
            using (var context = new RangeDbContext())
            {
                context.AgeGroups.Count().Should().Be(12);
            }
        }

        [TestMethod]
        [TestCategory("Integration-Data")]
        public void SqlLite_Initialises_And_Seeds_Persons()
        {
            using (var context = new RangeDbContext())
            {
                context.Persons.Count().Should().Be(0);
            }
        }
    }
}
