using AutoMapper;
using Ecom.Core.DTO.Category;
using Ecom.Core.Models;

namespace Ecom.API.Mapper
{
    public class CategoryMapping :Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.CategoryDescription)).ReverseMap();





        }
    }
}
