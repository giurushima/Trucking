using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Trucking.Application.Models.Create;
using Trucking.Application.Models.General;
using Trucking.Application.Models.Update;
using Trucking.Application.Services.UsersDb;
using Trucking.Entities;
using Trucking.Models.General;
using Trucking.Models.Update;
using Trucking.Services.Users;

namespace Trucking.Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IInfoUsersRepository _infoUsersRepository;
        private readonly IMapper _mapper;

        public UsersController(IInfoUsersRepository IInfoUsersRepository, IMapper mapper)
        {
            _infoUsersRepository = IInfoUsersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            var users = _infoUsersRepository.GetUsers();

            return new JsonResult(_mapper.Map<ICollection<UserDto>>(users));
        }

        [HttpGet("{idUser}")]
        public ActionResult GetUser(int idUser)
        {
            Entities.User? user = _infoUsersRepository.GetUser(idUser);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost(Name = "GetUsers")]
        public ActionResult<UserDto> CreateUser(CreateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            _infoUsersRepository.CreateUser(userDto);

            return CreatedAtRoute(
                "GetUsers",
                new
                {
                    Id = user.Id,
                },
                _mapper.Map<UserDto>(user));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UpdateUserDto userDto)
        {
            var existingUser = _infoUsersRepository.GetUser(id);
            if (existingUser == null)
                return NotFound();

            _infoUsersRepository.UpdateUser(id, userDto);

            _mapper.Map(userDto, existingUser);

            _infoUsersRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userToDelete = _infoUsersRepository.GetUser(id);
            if (userToDelete == null)
            {
                return NotFound();
            }

            _infoUsersRepository.DeleteUser(id);

            _infoUsersRepository.SaveChanges();

            return NoContent();
        }
    }
}
