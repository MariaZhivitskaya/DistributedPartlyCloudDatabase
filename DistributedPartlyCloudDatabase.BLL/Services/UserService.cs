using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using System.Collections.Generic;
using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using DistributedPartlyCloudDatabase.DAL.Interface;
using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using DistributedPartlyCloudDatabase.BLL.Mappers;
using System.Linq;
using System;
using DistributedPartlyCloudDatabase.DAL.Repositories;

namespace DistributedPartlyCloudDatabase.BLL.Services
{
    public class UserService : IUserService
    {
        private IDBOneRepositories DBOneRepositories;
        
        public UserService(IDBOneRepositories DBOneRepositories)
        {
            this.DBOneRepositories = DBOneRepositories;
        }

        public void CreateUser(UserEntity user)
        {
            DBOneRepositories.UserRepository.Create(user.ToDalUser());
            DBOneRepositories.Commit();
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return DBOneRepositories.UserRepository.GetAll().Select(user => user.ToBllUser());
        }

        public UserEntity GetUserByEmail(string email)
        {
            return DBOneRepositories.UserRepository.GetByEmail(email).ToBllUser();
        }

        public UserEntity GetUserByNickname(string nickname)
        {
            return DBOneRepositories.UserRepository.GetByNickname(nickname).ToBllUser();
        }

        public UserEntity GetUserEntityById(int id)
        {
            return DBOneRepositories.UserRepository.GetById(id).ToBllUser();
        }
    }
}
