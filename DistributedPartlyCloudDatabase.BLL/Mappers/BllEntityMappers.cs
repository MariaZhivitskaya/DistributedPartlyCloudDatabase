using DistributedPartlyCloudDatabase.BLL.Interface;
using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using DistributedPartlyCloudDatabase.DAL.Interface.DTO;

namespace DistributedPartlyCloudDatabase.BLL.Mappers
{
    public static class BllEntityMappers
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser()
            {
                Id = userEntity.Id,
                Email = userEntity.Email,
                Password = userEntity.Password,
                Nickname = userEntity.Nickname,
                Surname = userEntity.Surname,
                Name = userEntity.Name,
                Birthdate = userEntity.Birthdate,
                RoleId = userEntity.RoleId
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return dalUser == null
                ? null
                : new UserEntity()
                {
                    Id = dalUser.Id,
                    Email = dalUser.Email,
                    Password = dalUser.Password,
                    Nickname = dalUser.Nickname,
                    Surname = dalUser.Surname,
                    Name = dalUser.Name,
                    Birthdate = dalUser.Birthdate,
                    RoleId = dalUser.RoleId
                };
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            return new RoleEntity()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }

        public static DalImage ToDalImage(this ImageEntity imageEntity)
        {
            return new DalImage()
            {
                Id = imageEntity.Id,
                BinaryImage = imageEntity.BinaryImage,
                UserNickname = imageEntity.UserNickname,
                HashCode = imageEntity.HashCode
            };
        }

        public static ImageEntity ToBllImage(this DalImage dalImage)
        {
            return new ImageEntity()
            {
                Id = dalImage.Id,
                BinaryImage = dalImage.BinaryImage,
                UserNickname = dalImage.UserNickname,
                HashCode = dalImage.HashCode
            };
        }
    }
}
