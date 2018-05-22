using System.ComponentModel.DataAnnotations;

namespace DistributedPartlyCloudDatabase.ORM
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public byte[] BinaryImage { get; set; }

        [Required]
        public string UserNickname { get; set; }

        [Required]
        public int NumberOfLikes { get; set; }

        [Required]
        public string HashCode { get; set; }
    }
}
