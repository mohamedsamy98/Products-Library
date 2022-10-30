using Microsoft.EntityFrameworkCore;
using System;
using Web_API_Core.Entities;

namespace Web_API_Core.DbContexts
{
    public class ProductCategoryContext:DbContext
    {
        public ProductCategoryContext(DbContextOptions<ProductCategoryContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Electronics",
                    
                },
                new Category()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Clothes",
                    
                },
                new Category()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Name = "Gaming",
                },
                new Category()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Name = "Toys",
                },
                new Category()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Name = "Sports",
                });

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   CategoryId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Name = "Samsung TV",
                   Price = 15000,
                   Quantity=500,
                   ImgURL= "https://images.samsung.com/is/image/samsung/p6pim/eg/ua43au7000uxeg/gallery/eg-uhd-au7000-ua43au7000uxeg-422353015?$650_519_PNG$"
               },
               new Product
               {
                   Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   CategoryId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Name = "Shirt",
                   Price = 300,
                   Quantity = 500,
                   ImgURL = "https://m.media-amazon.com/images/I/31mu+UgobTL._AC_SX522_.jpg"
               },
               new Product
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   CategoryId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   Name = "FIFA 23",
                   Price = 1500,
                   Quantity = 500,
                   ImgURL = "https://www.imediastores.com/wp-content/uploads/2022/09/CD-Game-PS4-FIFA-2023-Standard-Edition-Arabic-Edition-1.jpg"
               },
               new Product
               {
                   Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   CategoryId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                   Name = "Adidas Ball",
                   Price = 2000,
                   Quantity = 500,
                   ImgURL = "https://st-adidas-egy.mncdn.com/mnresize/415/415/content/images/thumbs/0157325_ucl-pro-void-ball_he3777_back-center-view.jpeg"
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
