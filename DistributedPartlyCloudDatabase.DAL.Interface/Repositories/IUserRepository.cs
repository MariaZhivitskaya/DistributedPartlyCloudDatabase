using DistributedPartlyCloudDatabase.DAL.Interface.DTO;

namespace DistributedPartlyCloudDatabase.DAL.Interface.Repositories
{
    public interface IUserRepository : IRepository<DalUser>
    {

        DalUser GetById(int id);

        void Create(DalUser entity);

        DalUser GetByNickname(string nickname);

        DalUser GetByEmail(string email);
    }
}
