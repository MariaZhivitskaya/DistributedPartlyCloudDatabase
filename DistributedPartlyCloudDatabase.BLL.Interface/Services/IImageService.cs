using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using System.Collections.Generic;

namespace DistributedPartlyCloudDatabase.BLL.Interface.Services
{
    public interface IImageService
    {
        void CreateImage(ImageEntity imageEntity);
        IEnumerable<ImageEntity> GetAllImageEntities();
        IEnumerable<ImageEntity> GetByUserNickname(string userNickname);
        ImageEntity GetImageEntity(int id);
    }
}
