namespace DistributedPartlyCloudDatabase.DAL.Interface.DTO
{
    public class DalLike : IEntity
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int UserId { get; set; }
    }
}
