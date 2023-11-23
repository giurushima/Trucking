using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trucking.Context;
using Trucking.Entities;
using Trucking.Models.General;
using Trucking.Models.Create;
using Trucking.Models.Update;

namespace Trucking.Services.Trips
{
    public class InfoTripsRepository : IInfoTripsRepository
    {
        private readonly TruckContext _context;

        public InfoTripsRepository(TruckContext context)
        {
            _context = context;
        }

        public IEnumerable<Trip> GetTrips(int idTrucker)
        {
            return _context.Trips.Where(x => x.TruckerId == idTrucker).ToList();
        }

        public Trip GetTrip(int idTrucker, int idTrip) 
        {
            return _context.Trips.Where(x => x.TruckerId == idTrucker && x.Id == idTrip).FirstOrDefault();
        }

        public void CreateTrip(int idTrucker, CreateTripDto trip)
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
            SaveChanges();
        }
        public void UpdateTrip(int idTrucker, int idTrip, UpdateTripDto trip)
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
        }
        public void DeleteTrip(int idTrucker, int idTrip)
        {
            var deleteid = _context.Trips.Where(x => x.TruckerId == idTrucker && x.Id == idTrip).FirstOrDefault();

            _context.Trips.Remove(deleteid);

            _context.SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
