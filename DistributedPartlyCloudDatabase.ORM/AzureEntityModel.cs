using System.Data.Entity;

namespace DistributedPartlyCloudDatabase.ORM
{
    public class AzureEntityModel : DbContext
    {
        public AzureEntityModel() : base("name=AzureEntityModel") { }

        public virtual DbSet<Image> Images { get; set; }
    }
}
