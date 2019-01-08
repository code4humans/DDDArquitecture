using Application.Core;
using AutoMapper;

namespace Utilities.IoC
{
    public sealed class MapperInitializer : Profile
    {
        public static void ConfigureMappings()
        {
            Mapper.Initialize(
                map =>
                {
                    map.AddProfile<MapperProfile>();
                });
        }
    }
}
