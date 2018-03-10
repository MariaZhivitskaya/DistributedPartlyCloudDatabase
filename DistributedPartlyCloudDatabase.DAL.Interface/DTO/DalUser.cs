using System;

namespace DistributedPartlyCloudDatabase.DAL.Interface.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Nickname { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public int RoleId { get; set; }
    }
}
