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
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucking.Controllers
{
    [ApiController]
    [Route("api/truckers/{idTrucker}/trips")]
    public class TripsController : Controller
    {
        private readonly TruckContext _context;
        public TripsController(TruckContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TripDto>> GetTrips(int idTrucker)
        {
            return Ok(_context.Trips.Where(x => x.TruckerId == idTrucker).ToList());
        }

        [HttpGet("{idTrip}", Name = "GetTrip")]
        public ActionResult<IEnumerable<TripDto>> GetTrip(int idTrucker, int idTrip)
        {
            return Ok(_context.Trips.Where(x => x.TruckerId == idTrucker && x.Id == idTrip).FirstOrDefault());
        }
        [HttpPost]
        public async Task<IActionResult> CreateTrip(int idTrucker, CreateTripDto trip)
        {

            _context.Truckers.FirstOrDefault(x => x.Id == idTrucker);

            var newTrip = new Trip
            {
                Id = trip.Id,
                Source = trip.Source,
                Destiny = trip.Destiny,
                Description = trip.Description,
                TripStatus = trip.TripStatus,
                TruckerId = trip.TruckerId,
            };
            _context.Trips.Add(newTrip);
            _context.SaveChanges();

            return Ok(newTrip);
        }
        [HttpPut("{idTrip}")]
        public ActionResult UpdateTrip(int idTrucker, int idTrip, UpdateTripDto trip)
        {
            var updateTrip = _context.Trips.Where(x => x.TruckerId == idTrucker && x.Id == idTrip).FirstOrDefault();
            
            if (updateTrip != null)
            {
                updateTrip.Source = trip.Source;
                updateTrip.Destiny = trip.Destiny;
                updateTrip.Description = trip.Description;
                updateTrip.TripStatus = trip.TripStatus;
                updateTrip.TruckerId = trip.TruckerId;

                _context.SaveChanges();
            }
            return Ok(updateTrip);
        }

        [HttpDelete("{idTrip}")]
        public ActionResult<IEnumerable<TripDto>> DeleteTrip(int idTrucker,int idTrip)
        {
            var deleteid = _context.Trips.Where(x => x.TruckerId == idTrucker && x.Id == idTrip).FirstOrDefault();

            _context.Trips.Remove(deleteid);

            _context.SaveChanges();

            return Ok(deleteid);
        }
    }
}
