using AutoMapper;
using CartApi.Dto;
using CartApi.Entities;

namespace CartApi.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CartDto, Cart>().ReverseMap();
        }
    }
}
