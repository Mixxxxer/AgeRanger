using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using AgeRanger.Entities;


namespace AgeRanger.Data.Configuration
{
    [ExcludeFromCodeCoverage]
    public class RangeConfiguration
    {
        #region Public Methods

        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigureAgeGroupEntity(modelBuilder);
            ConfigurePersonEntity(modelBuilder);
        }

        #endregion

        #region Private Methods

        private static void ConfigureAgeGroupEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeGroup>().ToTable("AgeGroup");
        }

        private static void ConfigurePersonEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
        }

        #endregion
    }
}
