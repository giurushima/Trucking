using Trucking.Models.Create;
using Trucking.Models.Update;
using Trucking.Models.General;
using Trucking.Models;
using Trucking.Entities;
using AutoMapper;

namespace Trucking.AutoMapper
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Entities.Trip, Models.General.TripDto>();
            CreateMap<Models.Create.CreateTripDto, Entities.Trip>();
            CreateMap<Models.Update.UpdateTripDto, Entities.Trip>();
        }
    }
}
