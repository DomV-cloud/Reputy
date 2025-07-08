namespace Reputy.Contracts.Filter
{
    public record FilterResponse(List<string> Cities, List<string> Dispositions, int MinPrice, int MaxPrice);
}
