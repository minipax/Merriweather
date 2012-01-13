using System.Data.Entity;

namespace Merriweather.Models
{
    public class MerriweatherContext : DbContext
    {
        public DbSet<MvcMusicStore.Models.Webpage> Webpages { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<MvcMusicStore.Models.Cart> Carts { get; set; }
        public DbSet<MvcMusicStore.Models.Genre> Genres { get; set; }
        public DbSet<MvcMusicStore.Models.Order> Orders { get; set; }
        public DbSet<MvcMusicStore.Models.Song> Songs { get; set; }

        public MerriweatherContext()
        {
            // Instructions:
            //  * You can add custom code to this file. Changes will *not* be lost when you re-run the scaffolder.
            //  * If you want to regenerate the file totally, delete it and then re-run the scaffolder.
            //  * You can delete these comments if you wish
            //  * If you want Entity Framework to drop and regenerate your database automatically whenever you 
            //    change your model schema, uncomment the following line:
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MerriweatherContext>());
        }

    }
}