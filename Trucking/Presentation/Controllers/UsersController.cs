using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trucking.Application.Models.General;
using Trucking.Application.Services.UsersDb;
using Trucking.Models.General;
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

        [HttpGet("{idTrip}")]
        public ActionResult GetUser(int idUser)
        {
            Entities.User? user = _infoUsersRepository.GetUser(idUser);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(user));
        }
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
