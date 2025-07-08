using Reputy.Application.HelperMethods.Authentication;
using Reputy.Application.Common.Interfaces;
using Reputy.Application.Common.Interfaces.Persistance;
using Reputy.Domain.Entities;
using Reputy.Contracts.Authentication;
using Reputy.Domain.Enums;

namespace Reputy.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Register(RegisterRequest request)
        {
            var salt = PasswordHasher.GenerateSalt();
            var generatedHashedPassword = PasswordHasher.HashPassword(request.Password, salt);
            User userByEmail = _userRepository.GetUserByEmail(request.Email);

            if (userByEmail != null)
            {
                throw new Exception("User with given email already exists");
            }

            var isRoleParsed = Enum.TryParse(request.Role, ignoreCase: true, out Role role);
            if (!isRoleParsed)
            {
                throw new Exception($"Parsing role {request.Role} failed");
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = generatedHashedPassword,
                Salt = salt,
                Role = role
            };

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            var userResponse = _userRepository.GetUserByEmail(email);
            if (userResponse is not User user)
            {
                throw new Exception("User with given email does not exists.");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);
            var isPasswordCorrect = PasswordHasher.VerifyPassword(password, user.Password, user.Salt);

            if (!isPasswordCorrect)
            {
                throw new Exception("Invalid password"); // TODO: Create own Exception with better exception messag
            }

            return new AuthenticationResult(
              user,
              token);
        }
    }
}
