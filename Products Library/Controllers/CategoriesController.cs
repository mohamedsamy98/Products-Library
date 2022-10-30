using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products_Library.Models;
using System;
using System.Collections.Generic;
using Web_API_Core.Entities;
using Web_API_Core.Services;

namespace Web_API_Core.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController:ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        public CategoriesController(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository ?? throw new ArgumentNullException(nameof(productCategoryRepository));
            _mapper=mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoriesFromRepo = _productCategoryRepository.GetCategories();
            //var categories = new List<CategoryDto>();
            /*foreach(var category in categoriesFromRepo)
            {
                categories.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                });
            }*/

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categoriesFromRepo));
        }
        [HttpGet("{categoryId}",Name ="GetCategory")]
        public IActionResult GetCategory(Guid categoryId)
        {
            var categoryFromRepo=_productCategoryRepository.GetCategory(categoryId);
            if(categoryFromRepo == null)
                return NotFound();
            return Ok(_mapper.Map<CategoryDto>(categoryFromRepo));
        }
        [HttpPost]
        public ActionResult CreateCategory(CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _productCategoryRepository.AddCategory(categoryEntity);
            _productCategoryRepository.Save();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);
            return CreatedAtRoute("GetCategory",
                new { categoryId = categoryToReturn.Id },
                categoryToReturn);

        }
    }
}
