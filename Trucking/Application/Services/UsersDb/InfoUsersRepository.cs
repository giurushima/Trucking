using Microsoft.EntityFrameworkCore;
using Trucking.Application.Models.Create;
using Trucking.Application.Models.Update;
using Trucking.Context;
using Trucking.Entities;
using Trucking.Models.Create;

namespace Trucking.Application.Services.UsersDb
{
    public class InfoUsersRepository : IInfoUsersRepository
    {
        internal readonly TruckContext _context;

        public InfoUsersRepository(TruckContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public User GetUser(int idUser)
        {
            return _context.Users.Where(x => x.Id == idUser).FirstOrDefault();
        }

        public void CreateUser(CreateUserDto user)
        {
            var newUser = new User
            {
                Name = user.Name,
                UserName = user.UserName,
                Password = user.Password,
            };
            _context.Users.Add(newUser);
            SaveChanges();
        }

        public void UpdateUser(int id, UpdateUserDto user)
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.Id == id);

            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;

                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
