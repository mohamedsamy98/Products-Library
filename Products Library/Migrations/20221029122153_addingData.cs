using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products_Library.Migrations
{
    public partial class addingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Electronics" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Clothes" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Gaming" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "Toys" },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ImgURL", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "https://images.samsung.com/is/image/samsung/p6pim/eg/ua43au7000uxeg/gallery/eg-uhd-au7000-ua43au7000uxeg-422353015?$650_519_PNG$", "Samsung TV", 15000f, 500 },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "https://m.media-amazon.com/images/I/31mu+UgobTL._AC_SX522_.jpg", "Shirt", 300f, 500 },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "https://www.imediastores.com/wp-content/uploads/2022/09/CD-Game-PS4-FIFA-2023-Standard-Edition-Arabic-Edition-1.jpg", "FIFA 23", 1500f, 500 },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "https://st-adidas-egy.mncdn.com/mnresize/415/415/content/images/thumbs/0157325_ucl-pro-void-ball_he3777_back-center-view.jpeg", "Adidas Ball", 2000f, 500 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2902b665-1190-4c70-9915-b9c2d7680450"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));
        }
    }
}
