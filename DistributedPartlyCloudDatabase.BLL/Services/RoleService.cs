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
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return roleRepository.GetAll().Select(role => role.ToBllRole());
        }
    }
}
