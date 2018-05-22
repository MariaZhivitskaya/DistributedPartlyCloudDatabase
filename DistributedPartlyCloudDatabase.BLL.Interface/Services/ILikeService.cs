using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using System.Collections.Generic;

namespace DistributedPartlyCloudDatabase.BLL.Interface.Services
{
    public interface ILikeService
    {
        void CreateLike(LikeEntity like);
        IEnumerable<LikeEntity> GetAllLikeEntities();
        bool IsInDatabase(int imageId, int userId);
    }
}
