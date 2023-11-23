using AutoMapper;

namespace Trucking.AutoMapper
{
    public class TruckerProfile : Profile
    {
        public TruckerProfile() 
        {
            CreateMap<Entities.Trucker, Models.General.TripDto>();
            CreateMap<Models.Create.CreateTruckerDto, Entities.Trip>();
            CreateMap<Models.Update.UpdateTripDto, Entities.Trip>();
        }
    }
}
