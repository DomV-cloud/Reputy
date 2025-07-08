namespace Reputy.Contracts.User
{
    public record LandLordResponse(string FullName, string? AvatarUrl, string AverageRating, string IsVerified);
}
