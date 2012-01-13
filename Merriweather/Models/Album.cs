using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MvcMusicStore.Models;

namespace Merriweather.Models
{
    public class Album
    {
        public virtual Genre Genre { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual Band Band { get; set; }
        //public virtual Artist Artist { get; set; }

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

        //[DataType(DataType.Text)]
        //[DisplayName("Product")]
        //public string ProductId { get; set; }

        //[DisplayName("Artist")]
        //public int ArtistId { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
            ErrorMessage = "Price must be between 0.01 and 100.00")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Text)]
        [StringLength(160)]
        public string Heading { get;set; }

        [DataType(DataType.Text)]
        [Required]
        [UIHint("UploadImage")]
        public string PictureUrl{get;set; }

        [DataType(DataType.Date)]
        public DateTime LiveDate { get; set; }

        [DataType(DataType.Text)]
        [UIHint("UploadImage")]
        public string PlaylistPicture{ get; set;}

        [DataType(DataType.Text)]
        [UIHint("Editor")]
        public string Article {get;set;}

        [DataType(DataType.Text)]
        public string Gemm{ get; set;}
    }
}