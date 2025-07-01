namespace Reputy.Contracts.Advertisement
{
    public record class AdvertisementResponse
    {
        public Guid ID { get; init; }
        public string? ImageUrl { get; init; }
        public string Title { get; init; }
        public decimal Price { get; init; }
        public AdvertisementRealEstateResponse AdvertisementRealEstate { get; init; }
    }

}
