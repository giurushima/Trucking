using Trucking.Entities;
using Trucking.Models.Create;
using Trucking.Models.Update;

namespace Trucking.Services.Truckers
{
    public interface IInfoTruckersRepository
    {
        public IEnumerable<Trucker> GetTruckers();
        public Trucker? GetTrucker(int id);
        public void CreateTrucker(CreateTruckerDto trucker);
        public void UpdateTrucker(int id, UpdateTruckerDto trucker);
        public void DeleteTrucker(int id);
        public void SaveChanges();
    }
}
