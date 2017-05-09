using System;
using System.Collections.Generic;
using System.Linq;
using AgeRanger.Domain.Exceptions;
using AgeRanger.Domain.Models;
using AgeRanger.Entities;
using AgeRanger.Interfaces.Data.Repositories;

namespace AgeRanger.Domain.Services
{
    public interface IPersonService
    {
        #region Public Methods

        /// <summary>
        /// Adds a new person to the repository
        /// </summary>
        bool AddPerson(ConsolidatedPerson person);

        /// <summary>
        /// Removes a person from the repository
        /// </summary>
        bool DeletePerson(long id);

        /// <summary>
        /// Finds a person based on the given Id
        /// </summary>
        ConsolidatedPerson GetPerson(long id);

        /// <summary>
        /// Returns a list of all known persons
        /// </summary>
        IList<ConsolidatedPerson> GetPersons();

        /// <summary>
        /// Updates the details of a person based on the given Id
        /// </summary>
        bool UpdatePerson(ConsolidatedPerson person);

        #endregion  
    }

    public class PersonService : IPersonService
    {
        #region Injected Members

        private readonly IRangeRepository rangeRepository;

        #endregion

        #region Constructor

        public PersonService(IRangeRepository rangeRepository)
        {
            this.rangeRepository = rangeRepository;
        }

        #endregion

        #region Public Methods

        public bool AddPerson(ConsolidatedPerson person)
        {
            try
            {
                var entity = new Person()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Age = person.Age
                };

                rangeRepository.AddPerson(entity);
            }
            catch (Exception exception)
            {
                throw new PersonException(exception.Message, exception);
            }

            return true;
        }

        public bool DeletePerson(long id)
        {
            try
            {
                var person = rangeRepository.GetPerson(id);

                if (person == null)
                    return false;

                rangeRepository.DeletePerson(person);
            }
            catch (Exception exception)
            {
                throw new PersonException(exception.Message, exception);
            }

            return true;
        }

        public string GetDescriptionForAge(IEnumerable<AgeGroup> ageGroups, int age)
        {
            return ageGroups.First(range => age >= range.MinAge && age < range.MaxAge).Description;
        }

        public ConsolidatedPerson GetPerson(long id)
        {
            var person = rangeRepository.GetPerson(id);

            if (person == null)
                return null;

            var ageGroups = rangeRepository.GetAgeGroups();

            return new ConsolidatedPerson()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                AgeRangeDescription = GetDescriptionForAge(ageGroups, person.Age)
            };
        }

        public IList<ConsolidatedPerson> GetPersons()
        {
            var persons = rangeRepository.GetPersons();
            var ageGroups = rangeRepository.GetAgeGroups();

            var personRanges = persons.Select(person => new ConsolidatedPerson()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                AgeRangeDescription = GetDescriptionForAge(ageGroups, person.Age)
            });

            return personRanges.ToList();
        }

        public bool UpdatePerson(ConsolidatedPerson person)
        {
            try
            {
                var model = rangeRepository.GetPerson(person.Id);

                if (model == null)
                    return false;

                rangeRepository.UpdatePerson(model, new Person()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Age = person.Age
                });
            }
            catch (Exception exception)
            {
                throw new PersonException(exception.Message, exception);
            }

            return true;
        }

        #endregion  
    }
}
