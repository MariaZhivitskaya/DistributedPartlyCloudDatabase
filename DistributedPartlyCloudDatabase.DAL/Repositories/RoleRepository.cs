using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using System;
using System.Collections.Generic;
using DistributedPartlyCloudDatabase.DAL.Interface.DTO;
using System.Data.Entity;
using DistributedPartlyCloudDatabase.ORM;
using System.Linq;
using Ninject;

namespace DistributedPartlyCloudDatabase.DAL.Repositories
{
    public class RoleRepository : RepositoryBase<DalRole>, IRoleRepository
    {
        private EntityModel context;

        public RoleRepository(DbContext dbContext)
            : base(dbContext)
        {
            context = (context ?? (EntityModel)dbContext);
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().Select(dalRole => new DalRole()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            });
        }
    }
}
