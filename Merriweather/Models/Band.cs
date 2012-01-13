using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MvcMusicStore.Models;

namespace Merriweather.Models
{
    public class Band
    {
        [Key]
        [Required]
        public int Id{ get;set;}

        [DataType(DataType.Text)]
        [Required]
        public string Name{get;set;}

        [DataType(DataType.EmailAddress)]
        public string Email {get;set;}

        [DataType(DataType.ImageUrl)]
        [UIHint("UploadImage")]
        public string Picture{get;set;}

        [DataType(DataType.Text)]
        public string WebPage{get;set;}

        [DataType(DataType.MultilineText)]
        [UIHint("Editor")]
        public string Article{get;set;}

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}