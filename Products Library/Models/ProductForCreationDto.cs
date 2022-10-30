using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Products_Library.Models
{
    public class ProductForCreationDto:IValidatableObject
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string ImgURL { get; set; }
        [Required]
        public Guid categoryId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Price<0)
            {
                yield return new ValidationResult("The price value is negative please enter positive one", new[] { "ProductForCreationDto" });
            }
            if(Quantity<0)
            {
                yield return new ValidationResult("The quantity value is negative please enter positive one", new[] { "ProductForCreationDto" });
            }
        }
    }
}
