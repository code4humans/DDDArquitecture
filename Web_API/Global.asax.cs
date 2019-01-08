using System.Web.Http;
using Utilities.IoC;

namespace Web_API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var unityContainer = UnityConfig.Initialize();
            ModuleLoader.LoadContainer(unityContainer, ".\\bin", "Application.Implementations.dll");
            ModuleLoader.LoadContainer(unityContainer, ".\\bin", "Data.Persistence.Implementation.dll");

            MapperInitializer.ConfigureMappings();
        }
    }
}
