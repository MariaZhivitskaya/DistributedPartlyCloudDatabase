using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using System.Collections.Generic;

namespace DistributedPartlyCloudDatabase.BLL.Interface.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntityById(int id);

        IEnumerable<UserEntity> GetAllUserEntities();

        void CreateUser(UserEntity user);

        UserEntity GetUserByNickname(string nickname);

        UserEntity GetUserByEmail(string email);


        //IEnumerable<UserEntity> GetUsersExceptCurrent(string currentUserEmail);

        //IEnumerable<UserEntity> GetUnbannedUsersExceptCurrent(string currentUserEmail);

        //void BanUnbanUser(string email);
    }
}
