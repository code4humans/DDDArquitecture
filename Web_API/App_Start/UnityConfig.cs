using System.Web.Http;
using Unity;
using Unity.WebApi;
using Utilities.IoC;

namespace Web_API
{
    public static class UnityConfig
    {
        public static IUnityContainer Initialize()
        {
            var container = BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {
            ModuleLoader.LoadContainer(container, ".\\bin", "Application.*.dll");
            ModuleLoader.LoadContainer(container, ".\\bin", "Domain.*.dll");
            ModuleLoader.LoadContainer(container, ".\\bin", "Data.Persistence*.dll");
        }
    }
}
