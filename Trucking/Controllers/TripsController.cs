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
    }
}
