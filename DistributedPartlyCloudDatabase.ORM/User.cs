using System;
using System.ComponentModel.DataAnnotations;

namespace DistributedPartlyCloudDatabase.ORM
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Nickname { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
