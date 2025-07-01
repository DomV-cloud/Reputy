namespace Reputy.Contracts.Authentication
{
    /// <summary>
    /// Record - is good to use for readonly use-cases, like data tranfer (DTO)
    /// </summary>
    public record RegisterRequest
    (
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Role
    );
}
