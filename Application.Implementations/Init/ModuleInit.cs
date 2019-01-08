using Application.Contracts;
using System.ComponentModel.Composition;
using Utilities.IoC;

namespace Application.Implementations
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IRegisterModules registerModules)
        {
            registerModules.RegisterType<IHomeService, HomeService>();

        }
    }
}
