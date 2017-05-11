using System;
using System.Collections.Generic;
using System.Linq;
using AgeRanger.Data.Repositories;
using AgeRanger.Domain.Exceptions;
using AgeRanger.Domain.Helpers;
using AgeRanger.Domain.Models;

namespace AgeRanger.Domain.Services
{
    public class PersonService : IPersonService
    {
        #region Injected Members

        private readonly IRangeRepository rangeRepository;

        private readonly IPersonServiceHelper personServiceHelper;

        #endregion

        #region Constructor

        public PersonService(IRangeRepository rangeRepository, 
            IPersonServiceHelper personServiceHelper)
        {
            this.rangeRepository = rangeRepository;
            this.personServiceHelper = personServiceHelper;
        }

        #endregion

        #region Public Methods

        public bool AddPerson(ConsolidatedPerson consolidatedPerson)
        {
            try
            {
                rangeRepository.AddPerson(personServiceHelper.ToEntity(consolidatedPerson));
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
                var entity = rangeRepository.GetPerson(id);

                if (entity == null)
                    return false;

                rangeRepository.DeletePerson(entity);
            }
            catch (Exception exception)
            {
                throw new PersonException(exception.Message, exception);
            }

            return true;
        }

        public ConsolidatedPerson GetPerson(long id)
        {
            var person = rangeRepository.GetPerson(id);

            if (person == null)
                return null;

            var ageGroups = rangeRepository.GetAgeGroups();

            return personServiceHelper.ToConsolidatedPerson(ageGroups, person);
        }

        public IList<ConsolidatedPerson> GetPersons()
        {
            var persons = rangeRepository.GetPersons();
            var ageGroups = rangeRepository.GetAgeGroups();

            return personServiceHelper
                .ToConsolidatedPersons(ageGroups, persons)
                .ToList();
        }

        public bool UpdatePerson(ConsolidatedPerson consolidatedPerson)
        {
            try
            {
                var entity = rangeRepository.GetPerson(consolidatedPerson.Id);

                if (entity == null)
                    return false;

                rangeRepository.UpdatePerson(entity, personServiceHelper.ToEntity(consolidatedPerson));
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
