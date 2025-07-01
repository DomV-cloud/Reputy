namespace Reputy.Contracts.Advertisement
{
    public record class AdvertisementRealEstateResponse
    {
        public string Disposition { get; init; } = string.Empty;
        public string Location { get; init; } = string.Empty;
        public decimal Size { get; init; }
    }
}
