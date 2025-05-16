using AutoMapper;
using Ecom.Core.DTO.Product;
using Ecom.Core.Models;

namespace Ecom.API.Mapper
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>().ForMember(x=>x.CategoryNaame , op=> op.MapFrom(src => src.category.CategoryName))
                .ForMember(x => x.Photos, op => op.MapFrom(src => src.Photos))
                .ReverseMap();
            CreateMap<AddProductDTO ,Product>().ForMember(x=>x.Photos, op=>op.Ignore()).ReverseMap();
            CreateMap<UpdateProductDTO, Product>().ForMember(x => x.Photos, op => op.Ignore()).ReverseMap();


        }

    }
}
