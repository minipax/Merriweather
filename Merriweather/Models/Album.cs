using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcMusicStore.Models;
using Merriweather.Controllers;

namespace Merriweather.Models
{
    public class Album : IImage
    {
        public virtual Genre Genre { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual Band Band { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Band")]
        public int BandId { get; set; }

        [Required]
        [DisplayName("Genre")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        [StringLength(160)]
        public string Heading { get;set; }

        [DataType(DataType.Text)]
        [UIHint("Image")]
        public string ImageUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime LiveDate { get; set; }

        [DataType(DataType.Text)]
        [UIHint("Image")]
        public string PlaylistPicture{ get; set;}

        [Column(TypeName = "ntext")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Article { get; set; }

        [DataType(DataType.Text)]
        public string Gemm{ get; set;}

       
    }
}