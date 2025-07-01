using Reputy.Contracts.Authentication;

namespace Reputy.Application.Services.Authentication

{
    public interface IAuthenticationService
    {
        AuthenticationResult Register(RegisterRequest request);
        AuthenticationResult Login(string email, string password);
    }
}
