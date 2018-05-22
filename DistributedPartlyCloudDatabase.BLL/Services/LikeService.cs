using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using DistributedPartlyCloudDatabase.BLL.Mappers;
using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace DistributedPartlyCloudDatabase.BLL.Services
{
    public class LikeService : ILikeService
    {
        private IDBTwoRepositories DBTwoRepositories;

        public LikeService(IDBTwoRepositories DBTwoRepositories)
        {
            this.DBTwoRepositories = DBTwoRepositories;
        }

        public void CreateLike(LikeEntity like)
        {
            DBTwoRepositories.LikeRepository.Create(like.ToDalLike());
            DBTwoRepositories.Commit();
        }

        public IEnumerable<LikeEntity> GetAllLikeEntities()
        {
            return DBTwoRepositories.LikeRepository
                .GetAll()
                .Select(like => like.ToBllLike());
        }

        public bool IsInDatabase(int imageId, int userId)
        {
            var elem = DBTwoRepositories.LikeRepository
                .GetAll()
                .Where(like => like.ImageId == imageId && like.UserId == userId);

            return elem.Any();
        }
    }
}
