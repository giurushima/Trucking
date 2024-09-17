using Trucking.Entities;
using Trucking.Models.Auth;

namespace Trucking.Services.Auth
{
    public interface IAuthenticationServices
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
    }
}
