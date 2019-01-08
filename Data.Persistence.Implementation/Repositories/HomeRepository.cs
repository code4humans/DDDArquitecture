using Data.Persistence.Core;
using Data.Persistence.Repository;
using Domain.Contracts.Contracts;
using Domain.Core;

namespace Data.Persistence.Implementation
{
    public class HomeRepository : RepositoryBase<Home>, IHomeRepository
    {
        public HomeRepository(IContextUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

    }
}
