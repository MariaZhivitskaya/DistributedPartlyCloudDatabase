namespace DistributedPartlyCloudDatabase.DAL.Interface.DTO
{
    public class DalImage : IEntity
    {
        public int Id { get; set; }
        public byte[] BinaryImage { get; set; }
        public string UserNickname { get; set; }
        public string HashCode { get; set; }
    }
}
