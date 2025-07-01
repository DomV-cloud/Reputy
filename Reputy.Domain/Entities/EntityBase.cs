using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Reputy.Domain.Entities
{
    public abstract class EntityBase
    {
        [Required]
        [Key]
        [JsonPropertyName("id")]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
