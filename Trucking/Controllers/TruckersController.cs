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

namespace Trucking.Controllers
{
    [ApiController]
    [Route("api/truckers")]
    public class TruckersController : Controller
    {
        private readonly IInfoTruckersRepository _infoTruckersRepository;
        private readonly IMapper _mapper;

        public TruckersController(IInfoTruckersRepository IInfoTruckersRepository, IMapper mapper)
        {
            _infoTruckersRepository = IInfoTruckersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public JsonResult GetTruckers()
        {
            var truckers = _infoTruckersRepository.GetTruckers();

            return new JsonResult(_mapper.Map<ICollection<TruckerDto>>(truckers));
        }

        [HttpGet("{id}")]
        public ActionResult GetTrucker(int id)
        {
            Entities.Trucker? trucker = _infoTruckersRepository.GetTrucker(id);
            if (trucker is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TruckerDto>(trucker));
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
            var existingTrucker = _infoTruckersRepository.GetTrucker(id);
            if (existingTrucker == null) 
            {
                return NotFound();
            }

            _infoTruckersRepository.UpdateTrucker(id, trucker);

            _mapper.Map(trucker, existingTrucker);

            _infoTruckersRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTrucker(int id)
        {
            var truckerdelete = _infoTruckersRepository.GetTrucker(id);
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