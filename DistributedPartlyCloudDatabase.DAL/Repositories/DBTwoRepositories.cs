using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using DistributedPartlyCloudDatabase.ORM;

namespace DistributedPartlyCloudDatabase.DAL.Repositories
{
    public class DBTwoRepositories : UnitOfWork<AzureEntityModel>, IDBTwoRepositories
    {
        private IImageRepository imageRepository;

        public IImageRepository ImageRepository
        {
            get
            {
                return this.imageRepository 
                    ?? (this.imageRepository = new ImageRepository(base.Context));
            }
        }
    }
}
