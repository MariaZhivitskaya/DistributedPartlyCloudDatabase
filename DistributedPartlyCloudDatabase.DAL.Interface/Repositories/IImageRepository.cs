using DistributedPartlyCloudDatabase.DAL.Interface.DTO;

namespace DistributedPartlyCloudDatabase.DAL.Interface.Repositories
{
    public interface IImageRepository : IRepository<DalImage>
    {
        void Create(DalImage dalImage);
        //DalImage GetById(int id);
    }
}
