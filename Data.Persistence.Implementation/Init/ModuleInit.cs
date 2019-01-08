using Data.Persistence.Core;
using Domain.Contracts.Contracts;
using System;
using System.ComponentModel.Composition;
using Utilities.IoC;

namespace Data.Persistence.Implementation
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IRegisterModules registerModules)
        {
            registerModules.RegisterType<IContextUnitOfWork, MainContext>();
            registerModules.RegisterType<IHomeRepository, HomeRepository>();
        }
    }
}
