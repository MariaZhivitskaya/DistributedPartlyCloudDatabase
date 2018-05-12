using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using System.Data.Entity;
using DistributedPartlyCloudDatabase.DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using DistributedPartlyCloudDatabase.ORM;
using System.Linq;

namespace DistributedPartlyCloudDatabase.DAL.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly DbContext context;

        public ImageRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalImage dalImage)
        {
            var image = new Image()
            {
                BinaryImage = dalImage.BinaryImage,
                UserNickname = dalImage.UserNickname
            };

            context.Set<Image>().Add(image);
        }

        public IEnumerable<DalImage> GetAll()
        {
            return context.Set<Image>().Select(img => new DalImage()
            {
                Id = img.Id,
                BinaryImage = img.BinaryImage,
                UserNickname = img.UserNickname
            });
        }

        public DalImage GetById(int id)
        {
            Image ormImg = context.Set<Image>().FirstOrDefault(image => image.Id == id);

            return new DalImage()
            {
                Id = ormImg.Id,
                BinaryImage = ormImg.BinaryImage,
                UserNickname = ormImg.UserNickname
            };
        }
    }
}
