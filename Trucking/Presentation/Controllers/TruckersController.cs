using Microsoft.AspNetCore.Mvc;
using Trucking;
using System.ComponentModel.DataAnnotations;
using Trucking.Context;
using Microsoft.EntityFrameworkCore;
using Trucking.Entities;
using Trucking.Models.General;
using Trucking.Enums;
using Trucking.Models.Create;
using Trucking.Models.Update;
using AutoMapper;
using Trucking.Services.Truckers;
using Microsoft.AspNetCore.Authorization;

namespace Trucking.Controllers
{
    [ApiController]
    [Route("api/truckers")]
    [Authorize]
    public class TruckersController : Controller
    {
        private readonly IInfoTruckersRepository _infoTruckersRepository;
        private readonly IMapper _mapper;

        public TruckersController(IInfoTruckersRepository IInfoTruckersRepository, IMapper mapper)
        {
            _infoTruckersRepository = IInfoTruckersRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public JsonResult GetTruckers()
        {
            var truckers = _infoTruckersRepository.GetTruckers();

            return new JsonResult(_mapper.Map<ICollection<TruckerDto>>(truckers));
        }

        [HttpGet("{id}")]
        public ActionResult GetTrucker(int id, bool includeTrips = false)
        {
            var trucker = _infoTruckersRepository.GetTrucker(id, includeTrips);
            if (trucker == null)
                return NotFound();

            if (includeTrips)
                return Ok(_mapper.Map<TruckerDto>(trucker));

            return Ok(_mapper.Map<TruckerWithoutTripsDto>(trucker));
        }

        [HttpPost(Name = "GetTruckers")]
        public ActionResult<TruckerDto> CreateTrucker(CreateTruckerDto truckerDto) {

            var trucker = _mapper.Map<Trucker>(truckerDto);

            _infoTruckersRepository.CreateTrucker(truckerDto);

            return CreatedAtRoute(
                "GetTruckers",
                new
                {
                    Id = trucker.Id,
                },
                _mapper.Map<TruckerDto>(trucker));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTrucker(int id, UpdateTruckerDto trucker)
        {
            var existingTrucker = _infoTruckersRepository.GetTrucker(id, false);
            if (existingTrucker == null) 
                return NotFound();

            _infoTruckersRepository.UpdateTrucker(id, trucker);

            _mapper.Map(trucker, existingTrucker);

            _infoTruckersRepository.SaveChanges();

            return NoContent();
        }

        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public ActionResult DeleteTrucker(int id)
        {
            var truckerdelete = _infoTruckersRepository.GetTrucker(id, false);
            if (truckerdelete == null) 
            {
                return NotFound();
            }

            _infoTruckersRepository.DeleteTrucker(id);

            _infoTruckersRepository.SaveChanges();

            return NoContent();
        }
    }
}