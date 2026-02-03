
using AutoMapper;
using MVCapp.BLL.Dtos.Res;
using MVCapp.DAL.Entities;

namespace MVCapp.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}