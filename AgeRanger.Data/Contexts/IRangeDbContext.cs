using System.Data.Entity;
using AgeRanger.Entities;

namespace AgeRanger.Data.Contexts
{
    public interface IRangeDbContext
    {
        #region Public Members

        /// <summary>
        /// Default timeout for DB Connection
        /// </summary>
        int DefaultTimeout { get; }

        /// <summary>
        /// Extended timeout for the DB Connection
        /// </summary>
        int ExtendedTimeout { get; }

        /// <summary>
        /// Provides access to the AgeGroups DB Set
        /// </summary>
        IDbSet<AgeGroup> AgeGroups { get; set; }

        /// <summary>
        /// Provides Access to the Persons DB Set
        /// </summary>
        IDbSet<Person> Persons { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Allows you to save changes to the DB
        /// </summary>
        void SaveChanges();

        #endregion
    }
}