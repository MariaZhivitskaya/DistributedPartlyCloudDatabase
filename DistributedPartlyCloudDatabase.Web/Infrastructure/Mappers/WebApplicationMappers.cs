using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using DistributedPartlyCloudDatabase.Web.ViewModels;

namespace DistributedPartlyCloudDatabase.Web.Infrastructure.Mappers
{
    public static class WebApplicationMappers
    {
        public static UserEntity ToBllUser(this UserViewModel userViewModel)
        {
            return new UserEntity()
            {
                Id = userViewModel.Id,
                Email = userViewModel.Email,
                Password = userViewModel.Password,
                Nickname = userViewModel.Nickname,
                Surname = userViewModel.Surname,
                Name = userViewModel.Name,
                Birthdate = userViewModel.Birthdate,
                RoleId = userViewModel.RoleId
            };
        }

        public static ImageEntity ToBllImage(this ImageViewModel imageViewModel)
        {
            return new ImageEntity()
            {
                Id = imageViewModel.Id,
                BinaryImage = imageViewModel.BinaryImage,
                UserNickname = imageViewModel.UserNickname,
                HashCode = imageViewModel.HashCode
            };
        }
    }
}