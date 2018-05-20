using DistributedPartlyCloudDatabase.ORM;

namespace DistributedPartlyCloudDatabase.DAL.Interface.Repositories
{
    public interface IDBOneRepositories : IUnitOfWork<EntityModel>
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
    }
}
