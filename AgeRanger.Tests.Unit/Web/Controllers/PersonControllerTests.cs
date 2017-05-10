using System.Web.Mvc;
using AgeRanger.Controllers;
using AgeRanger.Domain.Models;
using AgeRanger.Domain.Services;
using AgeRanger.Tests.Unit.Helpers;
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

            ((ViewResult)returned).ViewName.Should().Be("Index");
        }

        [TestMethod]
        [TestCategory("Unit-Controllers")]
        public void AddPerson_Call_Service_When_ModelState_Valid()
        {
            var mockService = new Mock<IPersonService>();

            mockService.Setup(m => m.AddPerson(It.IsAny<ConsolidatedPerson>()))
                .Returns(true);

            var controller = new PersonController(mockService.Object);

            var returned = controller
                .AddPerson(ConsolidatedPersonBuilder.GetConsolidatedPerson());

            mockService.Verify(m => m.AddPerson(It.IsAny<ConsolidatedPerson>()), Times.Once);

            ((HttpStatusCodeResult) returned).StatusCode.Should().Be(200);
        }


        [TestMethod]
        [TestCategory("Unit-Controllers")]
        public void AddPerson_Returns_Badrequest_When_ModelState_Invalid()
        {
            var mockService = new Mock<IPersonService>();
            var controller = new PersonController(mockService.Object);

            controller.ModelState.AddModelError("a", "b");

            var returned = controller
                .AddPerson(ConsolidatedPersonBuilder.GetConsolidatedPerson());

            mockService.Verify(m => m.AddPerson(It.IsAny<ConsolidatedPerson>()), Times.Never);

            ((HttpStatusCodeResult)returned).StatusCode.Should().Be(400);
        }
    }
}
