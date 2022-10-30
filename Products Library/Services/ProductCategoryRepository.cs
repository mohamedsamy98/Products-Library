using System;
using System.Collections.Generic;
using System.Linq;
using Web_API_Core.DbContexts;
using Web_API_Core.Entities;

namespace Web_API_Core.Services
{
    public class ProductCategoryRepository : IProductCategoryRepository, IDisposable
    {
        private readonly ProductCategoryContext _context;
        public ProductCategoryRepository(ProductCategoryContext context)
        {
            _context = context?? throw new ArgumentNullException(nameof(context));
        }
        public void AddProduct( Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product GetProduct( Guid productId)
        {
            if (productId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return _context.Products
              .Where(c => c.Id == productId).FirstOrDefault();
        }
        public IEnumerable<Product> GetProducts(Guid categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId);
        }


        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void AddCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            // the repository fills the id (instead of using identity columns)
            category.Id = Guid.NewGuid();

            foreach (var product in category.Products)
            {
                product.Id = Guid.NewGuid();
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public bool CategoryExists(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            return _context.Categories.Any(a => a.Id == categoryId);
        }

        
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList<Category>();
        }

        
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        public void UpdateProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        public Category GetCategory(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            return _context.Categories
              .Where(c => c.Id == categoryId).FirstOrDefault();
        }

    }
}
