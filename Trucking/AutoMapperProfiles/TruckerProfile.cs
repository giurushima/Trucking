using AutoMapper;
using Trucking.Entities;
using Trucking.Models.General;
using Trucking.Models.Create;
using Trucking.Models.Update;

namespace Trucking.AutoMapperProfiles
{
    public class TruckerProfile : Profile
    {
        public TruckerProfile() {
            CreateMap<Entities.Trucker, Models.General.TruckerDto>();
            CreateMap<Models.Create.CreateTruckerDto, Entities.Trucker>();
            CreateMap<Models.Update.UpdateTripDto, Entities.Trucker>();
        }
    }
}
