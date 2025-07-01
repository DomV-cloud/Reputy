namespace Reputy.Contracts.Reference
{
    public record ReferenceResponse
    (
        Guid ID,
        Guid FromUserID,
        decimal Rating,
        DateTime CreatedAt,
        string? Comment
        );
}
