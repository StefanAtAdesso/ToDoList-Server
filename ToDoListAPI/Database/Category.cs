﻿using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Database
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
