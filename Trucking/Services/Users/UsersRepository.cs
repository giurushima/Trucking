using Trucking.Entities;
using Trucking.Context;


namespace Trucking.Services.Users
{
    public class UsersRepository : IUsersRepository
    {
        internal readonly TruckContext _context;

        public UsersRepository(TruckContext context)
        {
            this._context = context;
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
