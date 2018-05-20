using System.Collections.Generic;

namespace DistributedPartlyCloudDatabase.DAL.Interface.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
    }
}
