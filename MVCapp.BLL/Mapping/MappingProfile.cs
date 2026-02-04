
using AutoMapper;
using MVCapp.BLL.Dtos.Req;
using MVCapp.BLL.Dtos.Res;
using MVCapp.DAL.Entities;

namespace MVCapp.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
        }
    }
}