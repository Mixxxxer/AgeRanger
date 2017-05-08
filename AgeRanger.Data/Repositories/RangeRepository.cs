using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AgeRanger.Entities;
using AgeRanger.Interfaces.Data.Contexts;
using AgeRanger.Interfaces.Data.Repositories;

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
            var agegroups = dbContext.AgeGroups.Select(group => new AgeGroup()
                {
                    Id = group.Id,
                    MinAge = group.MinAge ?? 0,
                    MaxAge = group.MaxAge ?? int.MaxValue,
                    Description = group.Description ?? string.Empty
                })
                .AsNoTracking()
                .ToList();

            return agegroups;
        }

        public IEnumerable<Person> GetPersons()
        {
            return dbContext.Persons
                .AsNoTracking()
                .ToList();
        }

        #endregion
    }
}
