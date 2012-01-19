using System.Collections.Generic;

namespace Merriweather.Models
{
    public class Genre
    {
        public int      Id     { get; set; }
        public string   Name        { get; set; }
        public string   Description { get; set; }
        public virtual List<Album> Albums   { get; set; }
    }
}