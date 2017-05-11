using AgeRanger.Data.Contexts;
using AgeRanger.Data.Repositories;
using AgeRanger.Domain.Helpers;
using AgeRanger.Domain.Services;
using AgeRanger.Helpers;
using Ninject.Modules;

namespace AgeRanger.Infrastructure
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
            Bind<IPersonViewModelHelper>().To<PersonViewModelHelper>();
        }

        #endregion
    }
}
