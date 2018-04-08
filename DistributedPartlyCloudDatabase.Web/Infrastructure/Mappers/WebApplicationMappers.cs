using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using DistributedPartlyCloudDatabase.Web.ViewModels;

namespace DistributedPartlyCloudDatabase.Web.Infrastructure.Mappers
{
    public static class WebApplicationMappers
    {
        public static UserEntity ToBllUser(this UserViewModel userViewModel) =>
            new UserEntity()
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
}