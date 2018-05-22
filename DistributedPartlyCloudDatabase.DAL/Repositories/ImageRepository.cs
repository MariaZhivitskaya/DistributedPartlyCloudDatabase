using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using System.Data.Entity;
using DistributedPartlyCloudDatabase.DAL.Interface.DTO;
using System.Collections.Generic;
using DistributedPartlyCloudDatabase.ORM;
using System.Linq;
using Ninject;

namespace DistributedPartlyCloudDatabase.DAL.Repositories
{
    public class ImageRepository : RepositoryBase<DalImage>, IImageRepository
    {
        private readonly DbContext context;

        public ImageRepository(DbContext dbContext)
            : base(dbContext)
        {
            context = (context ?? (AzureEntityModel)dbContext);
        }

        public void Create(DalImage dalImage)
        {
            var image = new Image()
            {
                BinaryImage = dalImage.BinaryImage,
                UserNickname = dalImage.UserNickname,
                NumberOfLikes = dalImage.NumberOfLikes,
                HashCode = dalImage.HashCode
            };

            context.Set<Image>().Add(image);
        }

        public new IEnumerable<DalImage> GetAll()
        {
            return context.Set<Image>().Select(img => new DalImage()
            {
                Id = img.Id,
                BinaryImage = img.BinaryImage,
                UserNickname = img.UserNickname,
                NumberOfLikes = img.NumberOfLikes,
                HashCode = img.HashCode
            });
        }

        public DalImage GetById(int id)
        {
            Image ormImg = context.Set<Image>().FirstOrDefault(image => image.Id == id);

            return new DalImage()
            {
                Id = ormImg.Id,
                BinaryImage = ormImg.BinaryImage,
                UserNickname = ormImg.UserNickname,
                NumberOfLikes = ormImg.NumberOfLikes,
                HashCode = ormImg.HashCode
            };
        }
    }
}
