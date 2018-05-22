using DistributedPartlyCloudDatabase.ORM;

namespace DistributedPartlyCloudDatabase.DAL.Interface.Repositories
{
    public interface IDBTwoRepositories : IUnitOfWork<AzureEntityModel>
    {
        IImageRepository ImageRepository { get; }
        ILikeRepository LikeRepository { get; }
    }
}
