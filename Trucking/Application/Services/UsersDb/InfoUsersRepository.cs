using Microsoft.EntityFrameworkCore;
using Trucking.Context;
using Trucking.Entities;

namespace Trucking.Application.Services.UsersDb
{
    public class InfoUsersRepository : IInfoUsersRepository
    {
        private readonly TruckContext _context;

        public InfoUsersRepository(TruckContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }
    }
}
