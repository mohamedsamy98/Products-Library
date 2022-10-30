﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_API_Core.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
