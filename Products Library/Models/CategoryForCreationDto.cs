using System.ComponentModel.DataAnnotations;

namespace Products_Library.Models
{
    public class CategoryForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
