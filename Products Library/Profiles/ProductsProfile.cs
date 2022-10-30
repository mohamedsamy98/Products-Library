using AutoMapper;
using Products_Library.Models;
using Web_API_Core.Entities;

namespace Products_Library.Profiles
{
    public class ProductsProfile:Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto,Product>();
        }

    }
}
