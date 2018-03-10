using System.Collections.Generic;

namespace DistributedPartlyCloudDatabase.BLL.Interface.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleEntity> GetAllRoleEntities();
    }
}
