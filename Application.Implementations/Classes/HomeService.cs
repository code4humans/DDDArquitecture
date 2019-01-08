using Application.Contracts;
using Application.Core;
using AutoMapper;
using Domain.Contracts.Contracts;
using Domain.Core;
using System;
using System.Collections.Generic;

namespace Application.Implementations
{
    public class HomeService : IHomeService
    {
        private IHomeRepository _homeRepository;
        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }
        public void Add(HomeDTO entidad)
        {
            _homeRepository.Add(Mapper.Map<HomeDTO, Home>(entidad));
            _homeRepository.UnitOfWork.Complete();
        }

        public void Delete(HomeDTO entidad)
        {
            _homeRepository.Delete(Mapper.Map<HomeDTO, Home>(entidad));
            _homeRepository.UnitOfWork.Complete();
        }

        public IEnumerable<HomeDTO> FindByAddress(string address)
        {
            return Mapper.Map<IEnumerable<Home>,
                              IEnumerable<HomeDTO>>(_homeRepository.Find(x => x.Address.Contains(address)));

        }

        public HomeDTO Get(int id)
        {
            return Mapper.Map<Home, HomeDTO>(_homeRepository.Get(id));
        }

        public IEnumerable<HomeDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Home>,
                              IEnumerable<HomeDTO>>(_homeRepository.GetAll());            
        }


    }
}
