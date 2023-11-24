using Trucking.Entities;
using Trucking.Services.Users;

namespace Trucking.Services.Auth
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUsersRepository _userRepository;

        public AuthenticationServices(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? ValidateUser(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            return _userRepository.ValidateUser(authenticationRequest);
        }
    }
}
