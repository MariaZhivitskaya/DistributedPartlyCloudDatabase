using DistributedPartlyCloudDatabase.DAL.Interface;
using System.Data.Entity;

namespace DistributedPartlyCloudDatabase.DAL.Repositories
{
    public class UnitOfWork<TContext> : Disposable, IUnitOfWork<TContext>
           where TContext : DbContext, new()
    {
        public DbContext Context { get; }
        // public IDbContextFactory Factory { get; }

        /* public UnitOfWork(DbContextFactory factory)
         {
             Factory = factory;
         }*/

        //public UnitOfWork(DbContext context)
        //{
        //    Context = context;
        //}

        public UnitOfWork()
        {
            Context = new TContext();
        }

        public void Commit()
        {
            Context?.SaveChanges();
        }

        //public void Dispose()
        //{
        //    Context?.Dispose();
        //}
    }
}
