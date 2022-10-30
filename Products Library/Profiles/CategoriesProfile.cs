using AutoMapper;
using Products_Library.Models;
using Web_API_Core.Entities;

namespace Products_Library.Profiles
{
    public class CategoriesProfile :Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(
                dest=>dest.Name,
                opt=>opt.MapFrom(src=>src.Name));
            CreateMap<CategoryForCreationDto,Category>();

        }
    }
}
