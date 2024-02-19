namespace EventEasel.Data.Entities
{
    public class Photo : BaseEntity<int>
    {
        public string CloudUrl { get; set; }

        public string LocalAddress { get; set; }

        public string S3BucketAddress { get; set; }

        public byte[] ImgBytes { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
