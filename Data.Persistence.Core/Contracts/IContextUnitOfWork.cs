using Domain.Core;
using System;
using System.Data.Entity;

namespace Data.Persistence.Core
{
    public interface IContextUnitOfWork : IUnitOfWork, IDisposable
    {
        IDbSet<Home> Homes { get; }
        IDbSet<Entity> Set<Entity>() where Entity : class;
        void Attach<Entity>(Entity entity) where Entity : class;
        void SetModified<Entity>(Entity entity) where Entity : class;
    }
}
