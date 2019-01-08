namespace Utilities.IoC
{
    public interface IRegisterModules
    {
        void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
        void RegisterTypeWithLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
    }
}
