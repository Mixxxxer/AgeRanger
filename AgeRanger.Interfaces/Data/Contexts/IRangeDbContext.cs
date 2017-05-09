using System.Data.Entity;
using AgeRanger.Entities;

namespace AgeRanger.Interfaces.Data.Contexts
{
    public interface IRangeDbContext
    {
        #region Public Members

        int DefaultTimeout { get; }

        int ExtendedTimeout { get; }

        IDbSet<AgeGroup> AgeGroups { get; set; }

        IDbSet<Person> Persons { get; set; }

        void SaveChanges();

        #endregion
    }
}