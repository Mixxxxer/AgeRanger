using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using AgeRanger.Data.Contexts;
using AgeRanger.Entities;
using SQLite.CodeFirst;

namespace AgeRanger.Data.Initializers
{
    [ExcludeFromCodeCoverage]
    public class RangeInitializer : SqliteDropCreateDatabaseWhenModelChanges<RangeDbContext>, IRangeInitializer
    {
        #region Constructor

        public RangeInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder)
        {
        }

        #endregion

        #region Protected Methods

        protected override void Seed(RangeDbContext context)
        {
            context.Set<AgeGroup>().AddRange
            (new[]
            {
                new AgeGroup() { Id = 1, MinAge = null  , MaxAge = 2, Description = "Toddler" },
                new AgeGroup() { Id = 2, MinAge =  2    , MaxAge = 14, Description = "Child" },
                new AgeGroup() { Id = 3, MinAge =  14   , MaxAge = 20, Description = "Teenager" },
                new AgeGroup() { Id = 4, MinAge =  20   , MaxAge = 25, Description = "Early twenties" },
                new AgeGroup() { Id = 5, MinAge =  25   , MaxAge = 30, Description = "Almost thirty" },
                new AgeGroup() { Id = 6, MinAge =  30   , MaxAge = 50, Description = "Very adult" },
                new AgeGroup() { Id = 7, MinAge =  50   , MaxAge = 70, Description = "Kinda old" },
                new AgeGroup() { Id = 8, MinAge =  70   , MaxAge = 99, Description = "Old" },
                new AgeGroup() { Id = 9, MinAge =  99   , MaxAge = 110, Description = "Very old" },
                new AgeGroup() { Id = 10, MinAge = 110  , MaxAge = 199, Description = "Crazy ancient" },
                new AgeGroup() { Id = 11, MinAge = 199  , MaxAge = 4999, Description = "Vampire" },
                new AgeGroup() { Id = 12, MinAge = 4999 , MaxAge = null, Description = "Kauri tree" },
            });

            context.SaveChanges();
        }

        #endregion  
    }
}
