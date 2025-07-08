using Reputy.Contracts.Address;

namespace Reputy.Contracts.Advertisement
{
    public record class AdvertisementRealEstateResponse
    {
        public string Disposition { get; set; } = string.Empty;
        public decimal Size { get; init; }
        public string FormatedSize { get; init; } = string.Empty;

        public AdressResponse Address { get; set; } = null!;
    }
}
