using Application.Core;
using System;
using System.Collections.Generic;

namespace Application.Contracts
{
    public interface IHomeService 
    {
        HomeDTO Get(int id);
        IEnumerable<HomeDTO> GetAll();
        IEnumerable<HomeDTO> FindByAddress(string address);
        void Add(HomeDTO entidad);
        void Delete(HomeDTO entidad);
    }
}
