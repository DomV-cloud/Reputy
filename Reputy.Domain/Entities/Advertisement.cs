using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Reputy.Domain.Entities
{
    public class Advertisement : EntityBase
    {
        [ForeignKey(nameof(User))]
        [JsonPropertyName("user_id")]
        public Guid UserId { get; set; }

        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; } = null!; // should be object

        [Required]
        [JsonPropertyName("realEstate")]
        public AdvertisementRealEstate AdvertisementRealEstate { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        

        [JsonPropertyName("isShared")]
        public bool IsShared { get; set; } = false;

        [Required]
        [Precision(18, 4)]
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [Precision(18, 4)]
        [JsonPropertyName("deposit")]
        public decimal? Deposit { get; set; }

        [JsonPropertyName("pets_allowed")]
        public bool PetsAllowed { get; set; }

        [JsonPropertyName("image_urls")]
        public List<string> ImageUrls { get; set; } = [];

        [JsonPropertyName("landlord")]
        public User Landlord { get; set; }
    }
}
