using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using DistributedPartlyCloudDatabase.ORM;

namespace DistributedPartlyCloudDatabase.DAL.Repositories
{
    public class DBOneRepositories : UnitOfWork<EntityModel>, IDBOneRepositories
    {
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;

        public IUserRepository UserRepository
        {
            get
            {
                return this.userRepository 
                    ?? (this.userRepository = new UserRepository(base.Context));
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                return this.roleRepository 
                    ?? (this.roleRepository = new RoleRepository(base.Context));
            }
        }
    }
}
