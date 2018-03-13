using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;

namespace DistributedPartlyCloudDatabase.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        //public IEnumerable<RoleEntity> GetAllRoleEntities()
        //{
        //    return roleRepository.GetAllRoles().Select(role => role.ToBllRole());
        //}
    }
}
