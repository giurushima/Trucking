using Trucking.Entities;

namespace Trucking.Application.Services.UsersDb
{
    public interface IInfoUsersRepository
    {
        public IEnumerable<User> GetUsers();    
    }
}
