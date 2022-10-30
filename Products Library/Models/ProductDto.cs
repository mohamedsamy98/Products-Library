using System;

namespace Products_Library.Models
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string ImgURL { get; set; }
        public Guid CategoryId { get; set; }
    }
}
