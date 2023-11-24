using Trucking.Entities;
using Trucking.Models.Auth;

namespace Trucking.Services.Users
{
    public interface IUsersRepository
    {
        public User? ValidateUser(AuthenticationRequestBody authRequestBody);
        public bool SaveChange();
    }
}
