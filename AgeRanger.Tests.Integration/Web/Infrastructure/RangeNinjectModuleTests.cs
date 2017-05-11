using System.Linq;
using AgeRanger.Data.Contexts;
using AgeRanger.Data.Repositories;
using AgeRanger.Domain.Helpers;
using AgeRanger.Domain.Services;
using AgeRanger.Helpers;
using AgeRanger.Infrastructure;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Activation.Caching;

namespace AgeRanger.Tests.Integration.Web.Infrastructure
{
    [TestClass]
    public class RangeNinjectModuleTests
    {
        private static IKernel kernel;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            kernel = new StandardKernel(new RangeNinjectModule());
        }

        [TestMethod]
        [TestCategory("Integration-Infrastructure")]
        public void Ninject_Kernel_Should_Return_Person_Context()
        {
            var context = kernel.Get<IRangeDbContext>();

            context.Should().NotBeNull();

            kernel.Release(context);
        }

        [TestMethod]
        [TestCategory("Integration-Infrastructure")]
        public void Ninject_Kernel_Should_Return_Person_Repository()
        {
            var repository = kernel.Get<IRangeRepository>();

            repository.Should().NotBeNull();

            kernel.Release(repository);
        }

        [TestMethod]
        [TestCategory("Integration-Infrastructure")]
        public void Ninject_Kernel_Should_Return_Person_Service()
        {
            var service = kernel.Get<IPersonService>();

            service.Should().NotBeNull();

            kernel.Release(service);
        }

        [TestMethod]
        [TestCategory("Integration-Infrastructure")]
        public void Ninject_Kernel_Should_Return_Person_Service_Helper()
        {
            var service = kernel.Get<IPersonServiceHelper>();

            service.Should().NotBeNull();

            kernel.Release(service);
        }


        [TestMethod]
        [TestCategory("Integration-Infrastructure")]
        public void Ninject_Kernel_Should_Return_PersonViewModel_Helper()
        {
            var service = kernel.Get<IPersonViewModelHelper>();

            service.Should().NotBeNull();

            kernel.Release(service);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            var module = kernel.GetModules()
                .First(m => m is RangeNinjectModule);
                
            kernel.Unload(module.Name);

            kernel.Components.Get<ICache>().Clear();
        }
    }
}
