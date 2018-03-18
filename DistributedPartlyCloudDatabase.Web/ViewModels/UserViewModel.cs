using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistributedPartlyCloudDatabase.Web.ViewModels
{
    public class UserViewModel
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