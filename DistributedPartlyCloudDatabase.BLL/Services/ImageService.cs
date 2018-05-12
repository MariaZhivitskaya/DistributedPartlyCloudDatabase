using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using System;
using System.Collections.Generic;
using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using DistributedPartlyCloudDatabase.DAL.Interface;
using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using DistributedPartlyCloudDatabase.BLL.Mappers;
using System.Linq;

namespace DistributedPartlyCloudDatabase.BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageRepository imageRepository;

        public ImageService(IUnitOfWork unitOfWork, IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateImage(ImageEntity imageEntity)
        {
            imageRepository.Create(imageEntity.ToDalImage());
            unitOfWork.Commit();
        }

        public IEnumerable<ImageEntity> GetAllImageEntities()
        {
            return imageRepository
                .GetAll()
                .Select(img => img.ToBllImage());
        }

        public IEnumerable<ImageEntity> GetByUserNickname(string userNickname)
        {
            return imageRepository
                .GetAll()
                .Where(img => img.UserNickname == userNickname)
                .Select(img => img.ToBllImage());
        }

        public ImageEntity GetImageEntity(int id)
        {
            return imageRepository.GetById(id).ToBllImage();
        }
    }
}
