using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Reputy.Domain.Entities
{
    public class Address : EntityBase
    {
        [Required]
        [JsonPropertyName("city")]
        public string City { get; set; } = null!;

        [Required]
        [JsonPropertyName("street")]
        public string Street { get; set; } = null!;

        [Required]
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; } = null!;

        [Required]
        [JsonPropertyName("street_number")]
        public string StreetNumber { get; set; } = null!;

        [ForeignKey(nameof(AdvertisementRealEstate))]
        public Guid AdvertisementRealEstateId { get; set; }

        public AdvertisementRealEstate AdvertisementRealEstate { get; set; } = null!;
    }
}
