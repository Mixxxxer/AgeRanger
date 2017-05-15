using AgeRanger.Api.Helpers;
using AgeRanger.Data.Contexts;
using AgeRanger.Data.Repositories;
using AgeRanger.Domain.Helpers;
using AgeRanger.Domain.Services;
using Ninject.Modules;

namespace AgeRanger.Api.Infrastructure
{
    public class RangeNinjectModule : NinjectModule
    {
        #region Public Methods

        public override void Load()
        {
            Bind<IRangeDbContext>().To<RangeDbContext>();
            Bind<IRangeRepository>().To<RangeRepository>();

            Bind<IPersonService>().To<PersonService>();
            Bind<IPersonServiceHelper>().To<PersonServiceHelper>();

            Bind<IConfigHelper>().To<ConfigHelper>();
        }

        #endregion
    }
}
