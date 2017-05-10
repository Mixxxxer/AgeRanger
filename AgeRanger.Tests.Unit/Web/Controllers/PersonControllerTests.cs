using System.Web.Mvc;
using AgeRanger.Controllers;
using AgeRanger.Domain.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AgeRanger.Tests.Unit.Web.Controllers
{
    [TestClass]
    public class PersonControllerTests
    {
        [TestMethod]
        [TestCategory("Unit-Controllers")]
        public void Index_Returns_Person_View()
        {
            var mockService = new Mock<IPersonService>();
            var controller = new PersonController(mockService.Object);

            var returned = controller.Index();

            ((ViewResult) returned).ViewName.Should().Be("Index");
        }
    }
}
