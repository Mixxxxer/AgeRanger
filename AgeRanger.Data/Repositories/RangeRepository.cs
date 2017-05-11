using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AgeRanger.Data.Contexts;
using AgeRanger.Entities;

namespace AgeRanger.Data.Repositories
{
    public class RangeRepository : IRangeRepository
    {
        #region Provate Members

        private readonly IRangeDbContext dbContext;

        #endregion

        #region Constructor

        public RangeRepository(IRangeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public IEnumerable<AgeGroup> GetAgeGroups()
        {
            var agegroups = dbContext.AgeGroups.ToList();

            return agegroups.Select(group => new AgeGroup()
            {
                Id = group.Id,
                MinAge = group.MinAge ?? 0,
                MaxAge = group.MaxAge ?? int.MaxValue,
                Description = group.Description ?? string.Empty
            });
        }

        public IEnumerable<Person> GetPersons()
        {
            return dbContext.Persons
                .AsNoTracking()
                .ToList();
        }

        public Person GetPerson(long id)
        {
            return dbContext.Persons
                .AsNoTracking()
                .FirstOrDefault(person => person.Id == id);
        }

        public void AddPerson(Person person)
        {
            dbContext.Persons.Add(person);
            dbContext.SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            dbContext.Persons.Attach(person);
            dbContext.Persons.Remove(person);
            dbContext.SaveChanges();
        }

        public void UpdatePerson(Person original, Person changed)
        {
            dbContext.Persons.Attach(original);

            original.FirstName = changed.FirstName;
            original.LastName = changed.LastName;
            original.Age = changed.Age;

            dbContext.SaveChanges();
        }

        #endregion
    }
}
