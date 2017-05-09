﻿using System.Collections.Generic;
using AgeRanger.Entities;

namespace AgeRanger.Interfaces.Data.Repositories
{
    public interface IRangeRepository
    {
        /// <summary>
        /// Adds a person to the repository
        /// </summary>
        void AddPerson(Person person);

        /// <summary>
        /// Removed a person from the repository
        /// </summary>
        void DeletePerson(Person person);

        /// <summary>
        /// Returns a list of all Age Groups
        /// </summary>
        IEnumerable<AgeGroup> GetAgeGroups();

        /// <summary>
        /// Returns a list of all Persons
        /// </summary>
        IEnumerable<Person> GetPersons();

        /// <summary>
        /// Finds a given person based on their Id
        /// </summary>
        Person GetPerson(long id);

        /// <summary>
        /// Updates an existing person
        /// </summary>
        void UpdatePerson(Person original, Person changed);
    }
}