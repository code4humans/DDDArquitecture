using Domain.Core;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.Persistence.Core
{
    public class MainContext : DbContext, IContextUnitOfWork
    {
        public MainContext() : base("DefaultConnection")
        {

        }

        IDbSet<Home> _homes;
        public IDbSet<Home> Homes
        {
            get
            {
                return _homes ?? (_homes = base.Set<Home>());
            }
        }

        public void Attach<Entity>(Entity entity) where Entity : class
        {
            if (Entry(entity).State == EntityState.Detached)
            {
                base.Set<Entity>().Attach(entity);
            }
        }

        public int Complete()
        {
            return base.SaveChanges();
        }
        public void SetModified<Entity>(Entity entity) where Entity : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        public new IDbSet<Entity> Set<Entity>() where Entity : class
        {
            return base.Set<Entity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = true;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
