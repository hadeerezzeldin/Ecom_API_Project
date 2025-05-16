using AutoMapper;
using Ecom.Core.DTO.Photo;
using Ecom.Core.Models;

namespace Ecom.API.Mapper
{
    public class PhotoMapping :Profile
    {
        public PhotoMapping()
        {
            CreateMap<Photo, PhotoDTO>().ReverseMap();
        }
    }
}
