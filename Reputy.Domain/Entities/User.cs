using Reputy.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Reputy.Domain.Entities
{
    public class User : EntityBase
    {
        [Required]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [JsonPropertyName("LastName")]
        public string LastName { get; set; } = null!;

        [JsonPropertyName("firstName")]
        public string FullName => String.Join(FirstName, LastName);

        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [JsonPropertyName("password")]
        public string? Password { get; set; } //temp, should by mandatory

        [Required]
        [JsonPropertyName("role")]
        public Role Role { get; set; }

        public string? Salt { get; set; } //temp, should by mandatory

        [JsonPropertyName("avatar_url")]
        public string? AvatarUrl { get; set; }

        [JsonPropertyName("averageRating")]
        public decimal AverageRating { get; set; } = 0;

        [Required]
        [JsonPropertyName("isVerified")]
        public bool IsVerified { get; set; } = false;

        [JsonPropertyName("advertisements")]
        public List<Advertisement> Advertisements { get; set; } = [];

        [JsonPropertyName("references_written")]
        public List<Reference> ReferencesWritten { get; set; } = [];

        [JsonPropertyName("references_received")]
        public List<Reference> ReferencesReceived { get; set; } = [];

        [JsonPropertyName("rentals_landlord")]
        public List<Rental> RentalsAsLandlord { get; set; } = [];

        [JsonPropertyName("rentals_tenant")]
        public List<Rental> RentalsAsTenant { get; set; } = new();
    }
}
