using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trucking.Context;
using Trucking.Entities;
using Trucking.Models.General;

namespace Trucking.Services.Trips
{
    public class InfoTripsRepository : IInfoTripsRepository
    {
        private readonly TruckContext _context;

        public InfoTripsRepository(TruckContext context)
        {
            _context = context;
        }

        public IEnumerable<Trip> GetTrips(int idTrucker);
        {
            return _context.Trips.Where(x => x.TruckerId == idTrucker).ToList();
        }

        public Trip GetTrip(int idTrucker, int idTrip) 
        {
            return _context.Trips.Where(x => x.TruckerId == idTrucker && x.Id == idTrip).FirstOrDefault();
        }

    }
}
