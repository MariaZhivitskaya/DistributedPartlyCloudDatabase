using DistributedPartlyCloudDatabase.DAL.Interface.DTO;
using System.Collections.Generic;

namespace DistributedPartlyCloudDatabase.DAL.Interface.Repositories
{
    public interface ILikeRepository : IRepository<DalLike>
    {
        IEnumerable<DalLike> GetAll();
        DalLike GetById(int key);
        void Create(DalLike e);
    }
}
