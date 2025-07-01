using Microsoft.EntityFrameworkCore;
using Reputy.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Reputy.Domain.Entities
{
    public class AdvertisementRealEstate : EntityBase
    {
        [ForeignKey(nameof(Advertisement))]
        public Guid AdvertisementId { get; set; }

        public Advertisement Advertisement { get; set; } = null!;

        [Required]
        [JsonPropertyName("location")]
        public string Location { get; set; } = null!; // split address into object

        [Required]
        [JsonPropertyName("disposition")]
        public Disposition Disposition { get; set; }

        [Required]
        [JsonPropertyName("rentalType")]
        public TypeOfRental RentalType { get; set; }

        [Required]
        [Precision(18, 4)]
        [JsonPropertyName("size")]
        public decimal Size { get; set; }

        [JsonPropertyName("formatedSize")]
        public string FormatedSize => String.Join(Size.ToString(), "m2"); 
    }
}
