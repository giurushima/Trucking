using Trucking.Services.Truckers;
using Trucking.Context;
using Trucking.Entities;
using Trucking.Models.Create;
using Trucking.Models.Update;
using Trucking.Models.General;

namespace Trucking.Services.Truckers
{
    public class InfoTruckersRepository : IInfoTruckersRepository
    {
        private readonly TruckContext _context;

        public InfoTruckersRepository(TruckContext context)
        {
            _context = context;
        }

        public IEnumerable<Trucker> GetTruckers()
        {
            return _context.Truckers;
        }

        public Trucker GetTrucker(int id)
        {
            return _context.Truckers.FirstOrDefault(t => t.Id == id);
        }

        public void CreateTrucker(CreateTruckerDto trucker)
        {
            var newTrucker = new Trucker
            {
                CompleteName = trucker.CompleteName,
                TruckerType = trucker.TruckerType,
            };
            _context.Truckers.Add(newTrucker);
            _context.SaveChanges();
        }
        public void UpdateTrucker(int id, UpdateTruckerDto trucker)
        {
            var existingTrucker = _context.Truckers.FirstOrDefault(x => x.Id == id);

            if(existingTrucker != null) {
                existingTrucker.CompleteName = trucker.CompleteName;
                existingTrucker.TruckerType = trucker.TruckerType;
            
                SaveChanges();
            }
        }
        public void DeleteTrucker(int id)
        {
            var trucker = _context.Truckers.FirstOrDefault(x => x.Id == id);
            if (trucker != null)
            {
                _context.Truckers.Remove(trucker);
                SaveChanges();
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
