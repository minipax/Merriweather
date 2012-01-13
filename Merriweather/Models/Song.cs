using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Merriweather.Models;

namespace MvcMusicStore.Models
{
    public class Song
    {
        public virtual Album Album { get; set; }

        [Key]
        public int Id{get;set;}

        [DataType(DataType.Text)]
        public string Name { get; set; }

        public int AlbumId{get;set;}

        [DataType(DataType.Text)]
        public string Href{get;set;}

    }
}