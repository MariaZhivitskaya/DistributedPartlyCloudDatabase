using System.ComponentModel.DataAnnotations;

namespace DistributedPartlyCloudDatabase.ORM
{
    public class Like
    {
        public int Id { get; set; }

        [Required]
        public int ImageId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
