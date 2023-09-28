﻿using System.ComponentModel.DataAnnotations;

namespace RecipesApi.Model
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }        
    }
}
