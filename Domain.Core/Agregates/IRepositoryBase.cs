using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Core
{
    public interface IRepositoryBase<Entity> : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
        Entity Get(int id);
        IEnumerable<Entity> GetAll();
        IEnumerable<Entity> Find(Expression<Func<Entity, bool>> predicate);
        Entity FindSingleOrDefault(Expression<Func<Entity, bool>> predicate);
        void Add(Entity entity);
        void Delete(Entity entity);

    }
}
