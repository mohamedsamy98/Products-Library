using System;
using System.Collections.Generic;
using Web_API_Core.Entities;

namespace Web_API_Core.Services
{
    public interface IProductCategoryRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(Guid categoryId);
        Product GetProduct(Guid productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        IEnumerable<Category> GetCategories();
        Category GetCategory(Guid categoryId);
        void AddCategory(Category category);
        bool CategoryExists(Guid categoryId);
        bool Save();
    }
}
