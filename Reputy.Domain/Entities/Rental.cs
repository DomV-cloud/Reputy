using Reputy.Domain.Enums;
using System.Text.Json.Serialization;

namespace Reputy.Domain.Entities
{
    public class Rental : EntityBase
    {
        [JsonPropertyName("tenant_id")]
        public Guid TenantId { get; set; }

        [JsonPropertyName("landlord_id")]
        public Guid LandlordId { get; set; }

        [JsonPropertyName("advertisement_id")]
        public Guid AdvertisementID { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("status")]
        public RentalStatus Status { get; set; }

        [JsonPropertyName("tenant")]
        public User Tenant { get; set; }

        [JsonPropertyName("landlord")]
        public User Landlord { get; set; }

        [JsonPropertyName("advertisement")]
        public Advertisement Advertisement { get; set; }
    }
}
