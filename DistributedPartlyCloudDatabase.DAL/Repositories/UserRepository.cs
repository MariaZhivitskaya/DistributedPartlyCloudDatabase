using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;
using DistributedPartlyCloudDatabase.DAL.Interface.DTO;
using System.Data.Entity;
using DistributedPartlyCloudDatabase.ORM;

namespace DistributedPartlyCloudDatabase.DAL.Repositories
{
    public class UserRepository : RepositoryBase<DalUser>, IUserRepository
    {
        private EntityModel context;

        public UserRepository(DbContext dbContext)
            : base(dbContext)
        {
            context = (context ?? (EntityModel)dbContext);
        }

        public void Create(DalUser entity)
        {
            var user = new User()
            {
                Email = entity.Email,
                Password = entity.Password,
                Surname = entity.Surname,
                Name = entity.Name,
                Nickname = entity.Nickname,
                Birthdate = entity.Birthdate,
                RoleId = entity.RoleId
            };

           // uow.Commit();
            context.Set<User>().Add(user);
        }

        public new IEnumerable<DalUser> GetAll()
        {

            return context.Set<User>().Select(user => new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Surname = user.Surname,
                Name = user.Name,
                Nickname = user.Nickname,
                Birthdate = user.Birthdate,
                RoleId = user.RoleId
            });
        }

        public DalUser GetByEmail(string email)
        {
            User ormUser = context.Set<User>().FirstOrDefault(user => user.Email == email);
          

            return ormUser != null
                ? new DalUser()
                {
                    Id = ormUser.Id,
                    Email = ormUser.Email,
                    Password = ormUser.Password,
                    Surname = ormUser.Surname,
                    Name = ormUser.Name,
                    Nickname = ormUser.Nickname,
                    Birthdate = ormUser.Birthdate,
                    RoleId = ormUser.RoleId
                }
                : null;
        }

        public DalUser GetById(int id)
        {
            User ormUser = ormUser = context.Set<User>().FirstOrDefault(user => user.Id == id);

            return new DalUser()
            {
                Id = ormUser.Id,
                Email = ormUser.Email,
                Password = ormUser.Password,
                Surname = ormUser.Surname,
                Name = ormUser.Name,
                Nickname = ormUser.Nickname,
                Birthdate = ormUser.Birthdate,
                RoleId = ormUser.RoleId
            };
        }

        public DalUser GetByNickname(string nickname)
        {
            User ormUser = context.Set<User>().FirstOrDefault(user => user.Nickname == nickname);

            return ormUser != null
                ? new DalUser()
                {
                    Id = ormUser.Id,
                    Email = ormUser.Email,
                    Password = ormUser.Password,
                    Surname = ormUser.Surname,
                    Name = ormUser.Name,
                    Nickname = ormUser.Nickname,
                    Birthdate = ormUser.Birthdate,
                    RoleId = ormUser.RoleId
                }
                : null;
        }
    }
}
