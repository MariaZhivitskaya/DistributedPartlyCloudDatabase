using System.Data.Entity;

namespace DistributedPartlyCloudDatabase.ORM
{
    public class EntityModel : DbContext
    {
        public EntityModel() : base("name=EntityModel") { }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}
