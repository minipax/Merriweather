using System.ComponentModel.DataAnnotations;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// A class which represents the Webpages table in the Merriweather Database.
    /// </summary>


    public class Webpage
    {
        [ScaffoldColumn(false)]
        [Key]
        public int Id {get;set;}

        [DataType(DataType.Text)]
        public string Name {get; set;}

        [Column(TypeName = "ntext")]
        [UIHint("Editor")]
        public string PageContent { get;set; }

        public bool IsPublished {get;set;}

    }
}