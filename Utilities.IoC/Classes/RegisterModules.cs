using Unity;
using Unity.Lifetime;

namespace Utilities.IoC
{
    public class RegisterModules : IRegisterModules
    {
        private readonly IUnityContainer _container;
        public RegisterModules(IUnityContainer container)
        {
            _container = container;
        }

        public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            if (!withInterception)
            {
                _container.RegisterType<TFrom, TTo>();
            }
        }

        public void RegisterTypeWithLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }
    }
}
