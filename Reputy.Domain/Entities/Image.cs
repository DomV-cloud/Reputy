namespace Reputy.Domain.Entities
{
    public class Image : EntityBase
    {
        public Guid AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
        public string Url { get; set; } = null!;
    }
}
