using AutoMapper;
using Trucking.Entities;
using Trucking.Application.Models.Create;
using Trucking.Application.Models.General;
using Trucking.Application.Models.Update;

namespace Trucking.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<Entities.User, UserDto>();
            CreateMap<CreateUserDto, Entities.User>();
            CreateMap<UpdateUserDto, Entities.User>();
        }
    }
}
