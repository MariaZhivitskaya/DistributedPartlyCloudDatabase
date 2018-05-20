using DistributedPartlyCloudDatabase.BLL.Interface;
using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using DistributedPartlyCloudDatabase.BLL.Mappers;
using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace DistributedPartlyCloudDatabase.BLL.Services
{
    public class RoleService : IRoleService
    {
        private IDBOneRepositories DBOneRepositories;

        public RoleService(IDBOneRepositories DBOneRepositories)
        {
            this.DBOneRepositories = DBOneRepositories;
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return DBOneRepositories.RoleRepository.GetAll().Select(role => role.ToBllRole());
        }
    }
}
