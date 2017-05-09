using AgeRanger.Data.Contexts;
using AgeRanger.Data.Repositories;
using AgeRanger.Domain.Services;
using AgeRanger.Interfaces.Data.Contexts;
using AgeRanger.Interfaces.Data.Repositories;
using Ninject.Modules;

namespace AgeRanger.Infrastructure.Modules
{
    public class RangeNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRangeDbContext>().To<RangeDbContext>();
            Bind<IRangeRepository>().To<RangeRepository>();

            Bind<IPersonService>().To<PersonService>();
        }
    }
}
