using DistributedPartlyCloudDatabase.DAL.Interface.DTO;

namespace DistributedPartlyCloudDatabase.DAL.Interface.Repositories
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByNickname(string nickname);
    }
}
