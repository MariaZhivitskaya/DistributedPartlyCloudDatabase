﻿namespace DistributedPartlyCloudDatabase.BLL.Interface.Entities
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public byte[] BinaryImage { get; set; }
        public string UserNickname { get; set; }
    }
}