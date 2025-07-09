using Reputy.Contracts.Image;

namespace Reputy.Contracts.Advertisement
{
    /// <summary>
    /// for now it is used with few properties, but in a future could be expendable
    /// </summary>
    public record class AdvertisementDetailResponse : BaseAdvertisementResponse
    {
        public string? Description { get; init; }

        public List<ImageResponse> Images { get; init; } = [];
    }
}
