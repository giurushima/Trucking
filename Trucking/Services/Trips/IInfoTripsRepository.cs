using Trucking.Entities;
using Trucking.Models.Create;
using Trucking.Models.Update;

namespace Trucking.Services.Trips
{
    public interface IInfoTripsRepository
    {
        public IEnumerable<Trip> GetTrips(int idTrucker);
        public Trip? GetTrip(int idTrucker, int idTrip);
        public void CreateTrip(CreateTripDto trip);
        public void UpdateTrip(int idTrucker, int idTrip, UpdateTripDto trip);
        public void DeleteTrip(int idTrucker, int idTrip);
        public void SaveChanges();
    }
}
