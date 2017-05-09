using System;
using System.Collections.Generic;
using System.Linq;
using AgeRanger.Domain.Exceptions;
using AgeRanger.Domain.Models;
using AgeRanger.Domain.Services;
using AgeRanger.Entities;
using AgeRanger.Interfaces.Data.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AgeRanger.Tests.Unit.Domain.Services
{
    [TestClass]
    public class PersonServiceTests
    {
        private Mock<IRangeRepository> mockRepo;

        [TestInitialize]
        public void Setup()
        {
            mockRepo = new Mock<IRangeRepository>();

            mockRepo.Setup(m => m.GetAgeGroups()).Returns(new List<AgeGroup>()
            {
                new AgeGroup() { Id = 1, Description = "Toddler", MinAge = 0, MaxAge = 2},
                new AgeGroup() { Id = 2, Description = "Child", MinAge = 2, MaxAge = 14},
                new AgeGroup() { Id = 3, Description = "Kauri tree", MinAge = 4999, MaxAge = int.MaxValue}
            });
        }

        [TestMethod]
        [TestCategory("Unit-Services-Range")]
        public void GetPersons_Returns_Description_For_Age_On_Lower_Bounds()
        {
            mockRepo.Setup(m => m.GetPersons()).Returns(new List<Person>()
            {
                new Person() { Id = 1, Age = 1, FirstName = "Bob", LastName = "Jones" }
            });

            var service = new PersonService(mockRepo.Object);

            var persons = service.GetPersons();

            persons.Count().Should().Be(1);

            persons[0].FirstName.Should().Be("Bob");
            persons[0].LastName.Should().Be("Jones");
            persons[0].AgeRangeDescription.Should().Be("Toddler");
        }

        [TestMethod]
        [TestCategory("Unit-Services-Range")]
        public void GetPersons_Returns_Description_For_Age()
        {
            mockRepo.Setup(m => m.GetPersons()).Returns(new List<Person>()
            {
                new Person() { Id = 1, Age = 3, FirstName = "Billy", LastName = "Jean" }
            });

            var service = new PersonService(mockRepo.Object);

            var persons = service.GetPersons();

            persons.Count().Should().Be(1);

            persons[0].FirstName.Should().Be("Billy");
            persons[0].LastName.Should().Be("Jean");
            persons[0].AgeRangeDescription.Should().Be("Child");
        }

        [TestMethod]
        [TestCategory("Unit-Services-Range")]
        public void GetPersons_Returns_Description_For_Age_On_Upper_Bounds()
        {
            mockRepo.Setup(m => m.GetPersons()).Returns(new List<Person>()
            {
                new Person() { Id = 1, Age = 5000, FirstName = "Mary", LastName = "Sue" }
            });

            var service = new PersonService(mockRepo.Object);

            var persons = service.GetPersons();

            persons.Count().Should().Be(1);

            persons[0].FirstName.Should().Be("Mary");
            persons[0].LastName.Should().Be("Sue");
            persons[0].AgeRangeDescription.Should().Be("Kauri tree");
        }

        [TestMethod]
        [TestCategory("Unit-Services-Range")]
        public void GetPersons_Returns_Descriptions_For_Multiple_Persons()
        {
            mockRepo.Setup(m => m.GetPersons()).Returns(new List<Person>()
            {
                new Person() { Id = 1, Age = 1, FirstName = "Bob", LastName = "Jones" },
                new Person() { Id = 1, Age = 3, FirstName = "Billy", LastName = "Jean" },
                new Person() { Id = 1, Age = 5000, FirstName = "Mary", LastName = "Sue" }
            });

            var service = new PersonService(mockRepo.Object);

            var persons = service.GetPersons();

            persons.Count().Should().Be(3);

            persons[0].AgeRangeDescription.Should().Be("Toddler");
            persons[1].AgeRangeDescription.Should().Be("Child");
            persons[2].AgeRangeDescription.Should().Be("Kauri tree");
        }

        [TestMethod]
        [TestCategory("Unit-Services-Range")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetPersons_Throws_Expected_Exception_When_Age_Not_Found()
        {
            mockRepo.Setup(m => m.GetPersons()).Returns(new List<Person>()
            {
                new Person() { Id = 1, Age = 22, FirstName = "Bob", LastName = "Jones" }
            });

            var service = new PersonService(mockRepo.Object);

            service.GetPersons();
        }

        [TestMethod]
        [TestCategory("Unit-Services-Range")]
        public void AddPerson_Returns_True_After_Successfull_Add()
        {
            var consolidatedPerson = new ConsolidatedPerson()
            {
                Id = 1, FirstName = "Bob", LastName = "Jones", Age = 60
            };

            var service = new PersonService(mockRepo.Object);

            var result = service.AddPerson(consolidatedPerson);

            mockRepo.Verify(m => m.AddPerson(It.IsAny<Person>()), Times.Once);

            result.Should().Be(true);
        }

        [TestMethod]
        [TestCategory("Unit-Services-Range")]
        [ExpectedException(typeof(PersonException))]
        public void AddPerson_Throws_PersonException_When_Db_Error_Occurs()
        {
            mockRepo.Setup(m => m.AddPerson(It.IsAny<Person>()))
                .Throws(new Exception(""));

            var consolidatedPerson = new ConsolidatedPerson()
            {
                Id = 1, FirstName = "Bob", LastName = "Jones", Age = 60
            };

            var service = new PersonService(mockRepo.Object);

            service.AddPerson(consolidatedPerson);
        }

        [TestMethod]
        [TestCategory("Unit-Services-Range")]
        public void Delete_Returns_False_If_Person_Not_Found()
        {
            Person notFound = null;

            mockRepo.Setup(m => m.GetPerson(It.IsAny<long>())).Returns(notFound);

            var service = new PersonService(mockRepo.Object);
            var result = service.DeletePerson(1);

            result.Should().Be(false);
        }

        [TestMethod]
        [TestCategory("Unit-Services-Range")]
        public void Delete_Returns_True_After_Successful_Delete()
        {
            mockRepo.Setup(m => m.GetPerson(It.IsAny<long>())).Returns(new Person()
            {
                Id = 1, FirstName = "Bob", LastName = "Jones", Age = 60
            });

            var service = new PersonService(mockRepo.Object);

            var result = service.DeletePerson(1);

            mockRepo.Verify(m => m.DeletePerson(It.IsAny<Person>()), Times.Once);

            result.Should().Be(true);

        }

        [TestMethod]
        [TestCategory("Unit-Services-Range")]
        [ExpectedException(typeof(PersonException))]
        public void DeletePerson_Throws_PersonException_When_Db_Error_Occurs()
        {
            mockRepo.Setup(m => m.GetPerson(It.IsAny<long>())).Returns(new Person()
            {
                Id = 1, FirstName = "Bob", LastName = "Jones", Age = 60
            });

            mockRepo.Setup(m => m.DeletePerson(It.IsAny<Person>()))
                .Throws(new Exception(""));

            var service = new PersonService(mockRepo.Object);

            service.DeletePerson(1);
        }
    }
}
