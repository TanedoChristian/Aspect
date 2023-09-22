using AutoMapper;
using UserApi.Dto;
using UserApi.Entities;

namespace UserApi.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}
