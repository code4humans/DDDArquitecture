using Data.Persistence.Core;
using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace Data.Persistence.Repository
{
    public class RepositoryBase<Entity> : IRepositoryBase<Entity> where Entity : class
    {
        private readonly IContextUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
        public RepositoryBase(IContextUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Entity entity)
        {
            _unitOfWork.Set<Entity>().Add(entity);
        }

        public void Delete(Entity entity)
        {
            _unitOfWork.Set<Entity>().Remove(entity);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Entity FindSingleOrDefault(Expression<Func<Entity, bool>> predicate)
        {
            return _unitOfWork.Set<Entity>().FirstOrDefault(predicate);
        }
        public IEnumerable<Entity> Find(Expression<Func<Entity, bool>> predicate)
        {
            return _unitOfWork.Set<Entity>().Where(predicate);
        }

        public Entity Get(int id)
        {
            return _unitOfWork.Set<Entity>().Find(id);
        }

        public IEnumerable<Entity> GetAll()
        {
            return _unitOfWork.Set<Entity>().ToList();
        }
    }
}
