using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Merriweather.Models
{
    public class Product
    {
        public virtual ICollection<Album> Albums { get; set; }

        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
            ErrorMessage = "Price must be between 0.01 and 100.00")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
