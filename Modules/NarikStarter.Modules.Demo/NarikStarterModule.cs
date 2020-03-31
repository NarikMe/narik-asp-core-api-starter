using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;
using Narik.Common.Services.Core;
using Narik.Common.Web.Infrastructure.Interfaces;
using Narik.Common.Web.Infrastructure.OData;
using NarikStarter.Data;
using NarikStarter.Modules.Demo.Services;
using Unity;
using Unity.Lifetime;

namespace NarikStarter.Modules.Demo
{
    public class NarikStarterModule : INarikWebModule
    {
        private readonly IUnityContainer _unityContainer;


        public NarikStarterModule(IUnityContainer unityContainer, IEnvironment environment)
        {
            _unityContainer = unityContainer;
            environment.AddModelAssembly(typeof(NarikStarterDbContext).Assembly);
        }

        public const string KEY = "NarikStarter";
        public string Key => KEY;
        public void Init()
        {
            _unityContainer.RegisterType<IAccountService, AccountService>(
                new ContainerControlledLifetimeManager());
        }

        public void RegisterOdataController(ODataModelBuilder builder)
        {
            ODataHelper.RegisterControllers(builder, GetType().Assembly);
        }

       

        public void RegisterSignalRHubs(IEndpointRouteBuilder configure)
        {
        }
    }
}
