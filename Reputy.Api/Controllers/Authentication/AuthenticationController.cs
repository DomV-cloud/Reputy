using Microsoft.AspNetCore.Mvc;
using Reputy.Api.Filters;
using Reputy.Application.Services.Authentication;
using Reputy.Contracts.Authentication;

namespace Reputy.Api.Controllers.Authentication
{
    [ApiController]
    [Route("auth")]
    [ErrorHandlingFilter]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(
            IAuthenticationService authenticationService,
            ILogger<AuthenticationController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        [HttpPost("register", Name = "register")]
        public IActionResult Register(RegisterRequest request)
        {
            try
            {
                var authResult = _authenticationService.Register(request);

                var response = new AuthenticationResponse(
                                   authResult.User.ID,
                                   authResult.User.FirstName,
                                   authResult.User.LastName,
                                   authResult.User.Email,
                                   authResult.Token);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login", Name = "login")]
        public IActionResult Login(LoginRequest request)
        {
            try
            {
                var authResult = _authenticationService.Login(
                   request.Email,
                   request.Password);

                var response = new AuthenticationResponse(
                    authResult.User.ID,
                    authResult.User.FirstName,
                    authResult.User.LastName,
                    authResult.User.Email,
                    authResult.Token
                    );

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
