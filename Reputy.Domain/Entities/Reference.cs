using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Reputy.Domain.Entities
{
    public class Reference : EntityBase
    {
        [ForeignKey(nameof(FromUserID))]
        [JsonPropertyName("from_user_id")]
        public Guid FromUserID { get; set; }

        [ForeignKey(nameof(ToUserID))]
        [JsonPropertyName("to_user_id")]
        public Guid ToUserID { get; set; }

        [ForeignKey(nameof(Rental))]
        [JsonPropertyName("rental_id")]
        public Guid RentalID { get; set; }

        [JsonPropertyName("rating")]
        [Precision(18, 4)]
        public decimal Rating { get; set; }

        [JsonPropertyName("comment")]
        public string? Comment { get; set; }

        [JsonIgnore]
        public User FromUser { get; set; } = null!;

        [JsonIgnore]
        public User ToUser { get; set; } = null!;

        [JsonPropertyName("rental")]
        public Rental Rental { get; set; }
    }
}
