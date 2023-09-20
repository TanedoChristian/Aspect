using AutoMapper;
using Microservices.UserApi.Dto;
using Microservices.UserApi.Entities;

namespace Microservices.UserApi.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UserRequestDto, User>().ReverseMap();
        }
    }
}
