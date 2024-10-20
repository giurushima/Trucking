﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trucking.Application.Models.General;
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
    } 
}
