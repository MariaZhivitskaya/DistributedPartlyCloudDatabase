using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using DistributedPartlyCloudDatabase.ORM;

namespace DistributedPartlyCloudDatabase.DAL.Repositories
{
    public class DBTwoRepositories : UnitOfWork<AzureEntityModel>, IDBTwoRepositories
    {
        private IImageRepository imageRepository;
        private ILikeRepository likeRepository;

        public IImageRepository ImageRepository
        {
            get
            {
                return this.imageRepository 
                    ?? (this.imageRepository = new ImageRepository(base.Context));
            }
        }

        public ILikeRepository LikeRepository
        {
            get
            {
                return this.likeRepository
                    ?? (this.likeRepository = new LikeRepository(base.Context));
            }
        }
    }
}
