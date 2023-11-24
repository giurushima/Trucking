using Trucking.Entities;

namespace Trucking.Services.Auth
{
    public interface IAuthenticationServices
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
    }
}
