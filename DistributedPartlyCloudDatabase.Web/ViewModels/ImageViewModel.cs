namespace DistributedPartlyCloudDatabase.Web.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public byte[] BinaryImage { get; set; }
        public string UserNickname { get; set; }
        public string HashCode { get; set; }
    }
}