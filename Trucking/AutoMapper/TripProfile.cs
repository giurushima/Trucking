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
            CreateMap<Entities.Trip, Models.TripDto>();
            CreateMap<Models.CreateTripDto, Entities.Trip>();
            CreateMap<Models.UpdateTripDto, Entities.Trip>();
        }
    }
}
