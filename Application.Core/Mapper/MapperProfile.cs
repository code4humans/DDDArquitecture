using AutoMapper;
using Domain.Core;

namespace Application.Core
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Home, HomeDTO>();
            CreateMap<HomeDTO, Home>();
        }
    }
}
