using Aspect.ProductAPI.DTO;
using Aspect.ProductAPI.Entities;
using AutoMapper;

namespace Aspect.ProductAPI.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<PhotoDto, ProductPhoto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
