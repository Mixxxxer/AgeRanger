using System.Data.Entity;
using AgeRanger.Data.Configuration;
using AgeRanger.Data.Initializers;
using AgeRanger.Entities;
using AgeRanger.Interfaces.Data.Contexts;

namespace AgeRanger.Data.Contexts
{
    public class RangeDbContext : BaseDbContext<RangeDbContext>, IRangeDbContext
    {
        #region Public Members

        public int DefaultTimeout => DefaultCommandTimeout;

        public int ExtendedTimeout => LongCommandTimeout;

        public IDbSet<AgeGroup> AgeGroups { get; set; }

        public IDbSet<Person> Persons { get; set; }

        #endregion

        #region Constructor

        public RangeDbContext() : base("RangerConnection")
        {
        }

        #endregion

        #region Protected Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            RangeConfiguration.Configure(modelBuilder);

            var sqliteConnectionInitializer = new RangeInitializer(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

        #endregion

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
