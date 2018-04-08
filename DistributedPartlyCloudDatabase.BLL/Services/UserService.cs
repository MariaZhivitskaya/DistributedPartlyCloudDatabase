using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using System.Collections.Generic;
using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using DistributedPartlyCloudDatabase.DAL.Interface;
using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using DistributedPartlyCloudDatabase.BLL.Mappers;
using System.Linq;
using System;

namespace DistributedPartlyCloudDatabase.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        public void CreateUser(UserEntity user)
        {
            userRepository.Create(user.ToDalUser());
            unitOfWork.Commit();
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return userRepository.GetAll().Select(user => user.ToBllUser());
        }

        public UserEntity GetUserByEmail(string email)
        {
            return userRepository.GetByEmail(email).ToBllUser();
        }

        public UserEntity GetUserByNickname(string nickname)
        {
            return userRepository.GetByNickname(nickname).ToBllUser();
        }

        public UserEntity GetUserEntityById(int id)
        {
            return userRepository.GetById(id).ToBllUser();
        }
    }
}
