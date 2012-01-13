using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Merriweather.Controllers;

namespace Merriweather.Models
{
    public class Artist :IImage
    {
        [Required, Key]
        public int Id { get; set; }

        [DataType(DataType.Text), Required]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [UIHint("Image")]
        public string ImageUrl { get; set; }

        [DataType(DataType.Text)]
        public string WebPageUrl { get; set; }

        [Column(TypeName = "ntext")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Article { get; set; }

        public virtual ICollection<Band> Bands { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

    }
}