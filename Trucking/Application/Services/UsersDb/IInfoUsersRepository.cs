using Trucking.Application.Models.Create;
using Trucking.Application.Models.Update;
using Trucking.Entities;
using Trucking.Models.Update;

namespace Trucking.Application.Services.UsersDb
{
    public interface IInfoUsersRepository
    {
        public IEnumerable<User> GetUsers();
        public User? GetUser(int idUser);
        public void CreateUser(CreateUserDto user);
        public void UpdateUser(int id, UpdateUserDto user);
        public void DeleteUser(int id);
        public void SaveChanges();
    }
}
