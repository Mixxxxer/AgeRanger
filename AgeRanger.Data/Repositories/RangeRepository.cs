using System.Collections.Generic;
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
            return dbContext.AgeGroups.ToList();
        }

        public IEnumerable<Person> GetPersons()
        {
            return dbContext.Persons.ToList();
        }

        #endregion
    }
}
