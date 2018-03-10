using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DistributedPartlyCloudDatabase.ORM
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
