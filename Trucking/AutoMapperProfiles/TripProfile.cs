using Trucking.Models.Create;
using Trucking.Models.Update;
using Trucking.Models.General;
using Trucking.Models;
using Trucking.Entities;
using AutoMapper;

namespace Trucking.AutoMapperProfiles
{
    public class TripProfile : Profile
    {
        public TripProfile() { 
            CreateMap<Entities.Trip, TripDto>();
            CreateMap<Models.Create.CreateTripDto, Entities.Trip>();
            CreateMap<Models.Update.UpdateTripDto, Entities.Trip>();
        }
    }
}
