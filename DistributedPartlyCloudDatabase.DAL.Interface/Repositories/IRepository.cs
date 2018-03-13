using DistributedPartlyCloudDatabase.DAL.Interface.DTO;
using System;
using System.Collections.Generic;

namespace DistributedPartlyCloudDatabase.DAL.Interface.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
    }
}
