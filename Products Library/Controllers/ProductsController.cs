using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Products_Library.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using Web_API_Core.Entities;
using Web_API_Core.Services;

namespace Products_Library.Controllers
{
    [ApiController]
    [Route("api/products",Name ="GetProductForCategory")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        
        public ProductsController(IProductCategoryRepository productCategoryRepository,IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository?? throw new ArgumentNullException(nameof(productCategoryRepository));
            _mapper=mapper?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
       /* public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            var productsForCategoryFromRepo=_productCategoryRepository.GetProducts();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(productsForCategoryFromRepo));
        }*/
        public ActionResult<IEnumerable<ProductDto>>GetProducts(Guid categoryId)
        {
            
            IEnumerable<Product> productsForCategoryFromRepo;
            if (categoryId==Guid.Empty)
            {
                productsForCategoryFromRepo = _productCategoryRepository.GetProducts();
                return Ok(_mapper.Map<IEnumerable<ProductDto>>(productsForCategoryFromRepo));
            }
            if (!_productCategoryRepository.CategoryExists(categoryId))
            {
                return NotFound();
            }
            productsForCategoryFromRepo = _productCategoryRepository.GetProducts(categoryId);
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(productsForCategoryFromRepo));
        }

        [HttpGet("{productId}")]
        public ActionResult GetProduct(Guid productId)
        {
            var productForCategoryFromRepo=_productCategoryRepository.GetProduct(productId);
            if(productForCategoryFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductDto>(productForCategoryFromRepo));
        }
        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(ProductForCreationDto product)
        {
            
            var ProductEntity = _mapper.Map<Product>(product);
            _productCategoryRepository.AddProduct( ProductEntity);
            _productCategoryRepository.Save();

            var productToReturn=_mapper.Map<ProductDto>(ProductEntity);
            return CreatedAtRoute("GetProductForCategory", new
            {
                productId = productToReturn.Id
            }, productToReturn); 
        }
        [HttpDelete("{productId}")]
        public ActionResult DeleteProduct(Guid productId)
        {
            var productFromRepo=_productCategoryRepository.GetProduct(productId);
            if(productFromRepo == null)
            {
                return NotFound();
            }
            _productCategoryRepository.DeleteProduct(productFromRepo);
            _productCategoryRepository.Save();
            return NoContent();
        }
        [HttpPut("{productId}")]
        public ActionResult UpdateProduct(Guid productId,ProductForUpdateDto product)
        {
            var productFromRepo=_productCategoryRepository.GetProduct(productId);
            if(productId == null)
            {
                return NotFound();
            }
            if(product==null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _mapper.Map(product, productFromRepo);
            _productCategoryRepository.UpdateProduct(productFromRepo);
            _productCategoryRepository.Save();
            return NoContent();
        }
        [HttpPatch("{productId}")]
        public ActionResult PartiallyUpdateProduct(Guid productId,JsonPatchDocument<ProductForUpdateDto> patchDocument)
        {
            var productFromRepo = _productCategoryRepository.GetProduct(productId);
            if(productFromRepo==null)
            {
                return NotFound();
            }
            var productToPatch=_mapper.Map<ProductForUpdateDto>(productFromRepo);
            patchDocument.ApplyTo(productToPatch);
            _mapper.Map(productToPatch, productFromRepo);
            _productCategoryRepository.UpdateProduct(productFromRepo);
            _productCategoryRepository.Save();
            return NoContent();
        }

    }
}
