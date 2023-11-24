using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trucking.Entities;
using Trucking.Models.General;
using Trucking.Enums;
using Trucking.Models.Create;
using Trucking.Models.Update;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Trucking.Services.Trips;

namespace Trucking.Controllers
{
    [ApiController]
    [Route("api/truckers/{idTrucker}/trips")]
    public class TripsController : Controller
    {
        private readonly IInfoTripsRepository _infoTripsRepository;
        private readonly IMapper _mapper;

        public TripsController(IInfoTripsRepository IInfoTripsRepository, IMapper mapper)
        {
            _infoTripsRepository = IInfoTripsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public JsonResult GetTrips(int idTrucker)
        {
            var trips = _infoTripsRepository.GetTrips(idTrucker);

            return new JsonResult(_mapper.Map<ICollection<TripDto>>(trips));
        }

        [HttpGet("{idTrip}", Name = "GetTrip")]
        public ActionResult GetTrip(int idTrucker, int idTrip)
        {
            Entities.Trip? trip = _infoTripsRepository.GetTrip(idTrucker, idTrip);
            if (trip is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TripDto>(trip));
        }

        [HttpPost(Name = "GetTrips")]
        public ActionResult<TripDto> CreateTrip(int idTrucker, CreateTripDto tripDto)
        {
            var trip = _mapper.Map<Trip>(tripDto);

            _infoTripsRepository.CreateTrip(idTrucker, tripDto);

            return CreatedAtRoute(
                "GetTrips",
                new
                {
                    Id = trip.Id
                },
                _mapper.Map<TripDto>(trip));
        }

        [HttpPut("{idTrip}")]
        public ActionResult UpdateTrip(int idTrucker, int idTrip, UpdateTripDto trip)
        {
            var existingTrip = _infoTripsRepository.GetTrip(idTrucker, idTrip);
            if (existingTrip == null) 
            {
                return NotFound();
            }

            _infoTripsRepository.UpdateTrip(idTrucker, idTrip, trip);

            _mapper.Map(trip, existingTrip);

            _infoTripsRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{idTrip}")]
        public ActionResult DeleteTrip(int idTrucker,int idTrip)
        {
            var tripdelete = _infoTripsRepository.GetTrip(idTrucker, idTrip);
            if (tripdelete == null)
            {
                return NotFound();
            }

            _infoTripsRepository.DeleteTrip(idTrucker, idTrip);

            _infoTripsRepository.SaveChanges();

            return NoContent();
        }
    }
}
