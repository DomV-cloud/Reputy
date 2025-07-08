namespace Reputy.Contracts.Address
{
    public record class AdressResponse
    {
        public string City { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string StreetNumber { get; set; } = null!;
    }
}
