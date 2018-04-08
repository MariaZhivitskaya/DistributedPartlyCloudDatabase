using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using System;
using System.Collections.Generic;
using DistributedPartlyCloudDatabase.DAL.Interface.DTO;
using System.Data.Entity;
using DistributedPartlyCloudDatabase.ORM;
using System.Linq;

namespace DistributedPartlyCloudDatabase.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
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
