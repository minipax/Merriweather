using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Merriweather.Controllers;
using MvcMusicStore.Models;

namespace Merriweather.Models
{
    public class Band :IImage
    {
        [Key]
        [Required]
        public int Id{ get;set;}

        [DataType(DataType.Text), Required]
        public string Name{get;set;}

        [DataType(DataType.EmailAddress)]
        public string Email {get;set;}

        [DataType(DataType.Text)]
        [UIHint("Image")]
        public string ImageUrl{get;set;}

        [DataType(DataType.Text)]
        public string WebPage{get;set;}

        [Column(TypeName = "ntext")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Article { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}