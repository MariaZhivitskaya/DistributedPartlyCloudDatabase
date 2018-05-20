using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedPartlyCloudDatabase.DAL
{
    public class RepositoryBase<TEntity> : Disposable, IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _dataContext;

        private IDbSet<TEntity> Dbset
        {
            get { return _dataContext.Set<TEntity>(); }
        }

        public RepositoryBase(DbContext dbContext)
        {
            _dataContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Dbset.AsEnumerable();
        }
    }
}
