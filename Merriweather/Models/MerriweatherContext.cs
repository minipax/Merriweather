using System.Data.Entity;
using System.Linq;
using MvcMusicStore.Models;

namespace Merriweather.Models
{
    public class MerriweatherContext : DbContext
    {
        public DbSet<Webpage> Webpages { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Product> Products { get; set; }

        public MerriweatherContext()
        {
            // Instructions:
            //  * You can add custom code to this file. Changes will *not* be lost when you re-run the scaffolder.
            //  * If you want to regenerate the file totally, delete it and then re-run the scaffolder.
            //  * You can delete these comments if you wish
            //  * If you want Entity Framework to drop and regenerate your database automatically whenever you 
            //    change your model schema, uncomment the following line:
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MerriweatherContext>());
            //AddStaticData();
        }

        public void AddStaticData()
        {
            Artists.Add(new Artist
                            {
                                Name = "Kathy Reid-Naiman",
                                Email = "kathy@merriweather.ca",
                                WebPageUrl = "",
                                ImageUrl = "",
                                Article =
                                    @"<p><span><span>Kathy Reid-Naiman</span> </span>is a full time children's performer, and a member of <a href='http://www.mits.on.ca/'>Mariposa in the Schools</a>, an organization dedicated to bringing quality musical experiences to school children in Ontario. She is also a member of the <a href='http://www.cmnonline.org/'>Children's Music Network</a>. Her children's recordings; Tickles &amp; Tunes, More Tickles &amp; Tunes, Say Hello to the Morning, A Smooth Road to London Town, On My Way to Dreamland and Reaching For the Stars!&nbsp;have become very popular with pre-school teachers and families with toddler's &amp; young children. She has been teaching classes for young children 6 months to 6 years old and their caregivers since 1982 in libraries in Ontario. She is currently running classes in&nbsp;<a href='http://www.library.aurora.on.ca/page/children/programs/preschoolers'> Aurora,</a>&nbsp; and&nbsp; <a href='http://www.uxlib.com/modules/kid_teen/kids/kprog.html'>Uxbridge</a>.</p>
                                    <p></p>
                                    <p></p>
                                    <p>Kathy has presented workshops for the American Library Association, the Ontario Library Association, the Southern Ontario Libraries Services, Frontier College, the National Association for the Education of the Young Child, the California Association for the Education of the Young Child and the Children&rsquo;s Music Network&rsquo;s national gatherings.</p>
                                    <p></p>
                                    <p>Kathy is very active as a folk-musician. She plays with Arnie Naiman as <a href='http://www.merriweather.ca/artist.aspx?ID=18'>Ragged but Right</a> and she is the fiddler for The Toronto Women's Sword Team.</p>
                                    <p>She has performed at Mariposa, Winnipeg, Northern Lights festivals and The International Sword Gathering in Scarborough, England and has been on staff at <a href='http://www.cdss.org/'>Pinewoods Music and Dance Camp</a> in Massachusetts and Ogontz Camp in New Hampshire and <a href='http://www.mgl.ca/%7Ejhcole/thewoods/thewoods.html'>The Woods</a> music and dance camp in Muskoka.&nbsp;She plays guitar, fiddle, Appalachian dulcimer, autoharp and banjo uke.</p>
                                    <p></p>
                                    <p><a href='http://www.merriweather.ca/artist.aspx?ID=18'>Ragged But Right</a> has released a brand new cd of mostly old time singing duets. The cd is called <a href='http://www.merriweather.ca/albums.aspx?ID=37'>'Down Harmony Road'</a> and is available at Elderly Instruments, County Sales, CD Baby in the U.S.A. and directly from us Merriweather Records and Paypal in Canada.</p>"
                            });
            var arnie = new Artist
                            {
                                Name = "Arnie Naiman",
                                Email = "arnie@merriweather.ca",
                                Article =
                                    @"<div id='ArtistContent'>
                <font style='font-size: 10pt;'><font style='font-size: 18pt;'><span style='font-family: Arial;'></span></font>M<font style='font-size: 10pt;'><span style='font-family: Arial;'>y interest in banjo playing began after attending The Mariposa Folk Festival and Fiddler's Green Folk Club in Toronto in the mid 1970's. I was so impressed with hearing Michael Cooney and Ola Belle Reed that I was determined to get a banjo and become a singer of folk songs. I acquired a Stewart MacDonald Eagle banjo put together from a kit, and Pete Seeger's instructional book and was quickly able to handle the frailing style of playing.</span></font></font> <p style='font-family: Arial;'><font style='font-size: 10pt;'>Shortly after, I met Kurt Metzler who let me listen to his collection of recordings which opened up a new world of traditional music to my ears. I listened to music from the 1920's and 30's from the golden age of recorded stringband and early country music. Uncle Dave Macon, Charlie Poole and The North Carolina Ramblers, The Carter Family, The Delmore Brothers were among those included, as well as revivalists The New Lost City Ramblers- who were a major influence on my playing, and who were current exponents of this music they called 'Old Time Music'.</font></p> <p style='font-family: Arial;'><font style='font-size: 10pt;'>The following year banjo in hand, while waiting in line for tickets to The Mariposa Festival, some strangers with fiddles asked me if I'd play a tune with them. I sheepishly said that I was just a beginner and only knew two fiddle tunes, but I got out the banjo and my very first jam session was in the making. The realization that an instant connection could be made with total strangers through music had a profound effect on me. I started compiling a repertoire of fiddle tunes on the banjo in a more complex downpicking clawhammer style.</font></p> <p style='font-family: Arial;'><font style='font-size: 10pt;'>I attended other festivals that specialized in 'Old Time Music' and thus became a part of a vast community of great players and wonderful people. I hung out with Pete and Ellen Vigour from Virginia who were, and still are inspirational to my musical development. The live presence of the music I was hearing was exciting and intoxicating, and gradually became absorbed into my very soul. I started performing with Kurt Metzler at various venues as 'The Potatoe Pancakes' and we landed a job singing songs and playing instrumental music for a consecutive seven year stint in a pub.</font></p><p style='font-family: Arial;'><font style='font-size: 10pt;'><br></font></p> <p style='font-family: Arial;'><font style='font-size: 10pt;'>I met my wife <a href='http://208.106.133.235/artist.aspx?ID=1'>Kathy Reid</a> within the music community and we began performing and playing music for country and square dances, clubs and festivals and music camps. We organized a weekly folk music performance with the goal of including good local performer's participation, and we named our duo </font><a href='http://www.merriweather.ca/artist.aspx?ID=18'>Ragged But Right</a><font style='font-size: 10pt;'>. <br></font></p><p style='font-family: Arial;'>Ragged But Right
 has released a new cd of mostly old time singing duets. The cd is 
called <a href='http://www.merriweather.ca/albums.aspx?ID=37'>'Down 
Harmony Road'</a></p><p style='font-family: Arial;'><font style='font-size: 10pt;'><br></font></p><p style='font-family: Arial;'><font style='font-size: 10pt;'>I met <a href='http://208.106.133.235/artist.aspx?ID=3'>Chris Coole</a> who quickly accumulated a repertoire of fiddle tunes on the banjo and together with Kathy on guitar and myself on fiddle, and later on<a href='http://208.106.133.235/artist.aspx?ID=22'> Erynn Marshall </a>on fiddle as well, performed as 'The Extraordinary Stringband' and played southern style music for dances.</font></p> <p style='font-family: Arial;'><font style='font-size: 10pt;'>It was during our late night practices that Chris and I discovered that we had each composed some interesting banjo tunes of our own. We decided to record some of these along with some traditional music and the CD <a href='http://208.106.133.235/albums.aspx?ID=9'>'5 Strings Attached With No Backing' </a>was born. After encouraging feedback from the recording, we decided to do occasional club performances together. <a href='http://208.106.133.235/albums.aspx?ID=10'>Volume 2</a> was recorded 3 years later. <br></font></p><p style='font-family: Arial;'><br></p><p style='font-family: Arial;'><font style='font-size: 10pt;'><a href='albums.aspx?ID=11'>THE BANJO SPECIAL</a></font><font style='font-size: 10pt;'> featuring various styles of banjo music together with <a href='http://www.merriweather.ca/artist.aspx?ID=3'>Chris Coole</a>, <a href='http://208.106.133.235/artist.aspx?ID=4'>Chris Quinn</a>, and <a href='http://208.106.133.235/artist.aspx?ID=5'>Brian Taheny&nbsp;</a> was the next recording project along with banjo extravaganza concerts. <br></font></p><p style='font-family: Arial;'><font style='font-size: 10pt;'><br></font></p><p style='font-family: Arial;'><font style='font-size: 10pt;'>Rounder records has released&nbsp; <a href='http://www1.gemm.com/item/OLD--TIME--BANJO--FESTIVAL---d-VARIOUS--ARTISTS/OLD--TIME--BANJO--FESTIVAL/GML1414065429/'>'The Old Time Banjo Festival'</a></font> produced by Grammy Award winner Cathy Fink&nbsp; featuring todays finest banjo players including Arnie Naiman and Chris Coole.</p><p style='font-family: Arial;'><br></p><p style='font-family: Arial;'>Arnie performs with Chris Coole, The Banjo Special, Ragged But Right, and also currently plays banjo in the Virginia based old-time String Band,&nbsp; <a href='http://www.merriweather.ca/artist.aspx?ID=30'>Albemarle Ramblers</a>. The band has released a new cd for 2010 called <a href='http://www.merriweather.ca/albums.aspx?ID=48'>'Gentleman from Virginia' </a>on Merriweather Records<br></p><br><br><p style='font-family: Arial;'><br></p><p style='font-family: Arial;'>Arnie is a member of<a href='http://www.local1000.com/'> <span class='top'>THE TRAVELING MUSICIANS UNION</span> Local 1000 AFM</a></p><p style='font-family: Arial;'><br></p><p style='font-family: Arial;'>Visit <a href='http://www.myspace.com/albemarleramblers'>Albemarle Rambler Myspace</a></p><p style='font-family: Arial;'>Visit <a href='http://www.myspace.com/raggedbutright'>Ragged But Right </a><a href='http://www.myspace.com/raggedbutright'>Myspace</a><br></p><p style='font-family: Arial;'><font style='font-size: 10pt;'>Visit My <a href='http://www.banjohangout.org/my/arnie/'>Banjohangout Page</a></font></p><p style='font-family: Arial;'><br></p><p style='font-family: Arial;'><font style='font-size: 10pt;'><a href='http://www.banjohangout.org/my/arnie/'><br></a></font></p><p style='font-family: Arial;'><br></p><p style='font-family: Arial;'><font style='font-size: 10pt;'><a href='http://www.banjohangout.org/my/arnie/'><br></a></font></p><p style='font-family: Arial;'><br></p><p style='font-family: Arial;'><font style='font-size: 10pt;'><br></font></p></div>"

                            };
            Artists.Add(arnie);

            var ramblers = new Band
                               {
                                   Name = "Albemarle Ramblers",
                                   Article =
                                       @"<font style='font-size: 12pt;'><span style='font-weight: bold;'>Dick Harrington </span>- guitar, vocals</font><br>As a boy Dick Harrington sang folk songs with his grandma.&nbsp; In the early ' 60s he sang and played guitar nightly in a coffee house. In the ' 70s having settled in Virginia, he became inspired mainly by Pete and Ellen Vigour, to play old-time music exclusively and take up fiddle. Dick has recorded with Victoria Young, Afton Mountain String Band and <a href='http://www.troublesomecreekstringband.com/'>Troublesome Creek</a><br><br><font style='font-size: 12pt;'><span style='font-weight: bold;'>Pete Vigour </span>- fiddle, vocals and fingerpicking banjo </font><br><a href='http://vigourmusic.com/Welcome.html'>Pete Vigour</a> is lucky enough to play and teach old-time music for a living.&nbsp; He lives in White Hall, Virginia with his wife Ellen, a fine mandolin player and dance caller.&nbsp; Pete and Ellen have played old-time music in <a href='http://unclehenrysfavorites.com/'>Uncle Henry's Favorites</a><span style='text-decoration: underline;'> </span>for 25 years with Jim Childress and Mark Beall, often featuring guest appearances by Arnie and Dick.<br><br><font style='font-size: 12pt;'><span style='font-weight: bold;'>Arnie Naiman</span> - clawhammer and fingerpicking banjo, vocals</font><br><a href='http://www.merriweather.ca/artist.aspx?ID=2'>Arnie Naiman</a> hails from Aurora Ontario, Canada. He has previously released his own recordings of banjo and old-time music and also performs with <a href='http://www.merriweather.ca/albums.aspx?ID=11'>The Banjo Special</a>, <a href='http://www.merriweather.ca/artist.aspx?ID=3'>Chris Coole </a>and <a href='http://www.merriweather.ca/artist.aspx?ID=18'>Ragged But Right</a>.&nbsp; He has played on recordings&nbsp; for other artists such as<a href='http://www.merriweather.ca/artist.aspx?ID=1'> Kathy Reid-Naiman</a>, The <a href='http://www.merriweather.ca/albums.aspx?ID=36'>Old Time Banjo Festival</a> (Rounder), Chris Coole, <a href='http://www.merriweather.ca/artist.aspx?ID=22'>Erynn Marshall</a>, Eve Goldberg, <a href='http://www.merriweather.ca/artist.aspx?ID=6'>Debbie Carroll</a>, Shelley Posen, and The Marigolds<br><br><font style='font-size: 12pt;'>Their New Old-Time String Band Release ,&nbsp; <a href='http://www.merriweather.ca/albums.aspx?ID=48'><span style='font-weight: bold;'>'Gentleman From Virginia'</span></a><br>M05AR&nbsp; - <span style='font-weight: bold; font-style: italic;'>Available NOW!</span></font><br><br><br><br>    <span style='font-weight: bold; font-style: italic; text-decoration: underline;'></span><font style='font-size: 14pt;'><br></font>See a Video Live Performance - <a rel='nofollow' target='_blank' href='http://www.youtube.com/watch?v=T3G3UIox6_Y'>Walking The Dog </a><br>
See a Video Live Performance - <a rel='nofollow' target='_blank' href='http://www.youtube.com/watch?v=YAUCH30qg3A'>The Glendy Burke</a><br>See a Video Live Performance - <a href='http://www.youtube.com/watch?v=bhH92M8wtVA'><span>Home In That 
Rock</span></a><br>See a Video Live Performance - <a href='http://www.youtube.com/watch?v=rr6I8bDP5-4'>On The Dixie Bee Line</a><br style='font-weight: bold;'><br><font style='font-size: 12pt;'><span style='font-weight: bold; font-style: italic;'>Visit the <a href='http://albemarleramblers.com/'>Albemarle Rambler Website!</a></span></font><br><br style='font-weight: bold; font-style: italic;'><span style='font-weight: bold; font-style: italic;'>Visit <a href='http://www.myspace.com/albemarleramblers'>Albemarle Rambler Myspace</a></span><br><br><font style='font-size: 10pt; font-style: italic; font-weight: bold;'>Visit Arnie Naiman's <a href='http://www.banjohangout.org/my/arnie/'>Banjohangout Page</a></font><br><br><br>"
                               };
            Bands.Add(ramblers);
            SaveChanges();
            arnie.Bands.Add(ramblers);

            


            var mp3 = new Song
                                 {
                                     Name = "Title Track",
                                     Href = "00-title.mp3"
                                 };

            var ogg = new Song
                          {
                              Name = "Title Track, ogg",
                              Href = "00-title.ogg"
                          };

            var oldTimeGenre = new Genre {Name = "Old Time"};

            var cd = new Product {Name = "CD - Canada", Price = (decimal) 22.5};

            var virginia = new Album
                               {
                                   Name = "Gentleman From Virginia",
                                   Heading = "Gentleman From Virginia by The Albemarle Ramblers",
                                   Article =
                                       @"'Straight Ahead old time southern string band music- the way we like it!
For years we've been friends in music and in life, and now here are some of our favorite tunes and songs.'

This wonderful collection from the Albemarle Ramblers contains a  variety of southern old-time ballads, songs, and tunes learned from Uncle Dave Macon, The Carter Family, Stephen Foster, and fiddlers such as Gerry Milnes, Robert Sykes, Tom Isenhour, James H. Chisholm, Mark Campbell and more plus a band arrangement of Arnie Naiman's banjo tune -'Walking The Dog' to top it off.

M05AR

'...The Albemarle Ramblers is a tight old-time stringband with strong arrangements, impeccable playing and singing, and an interesting collection of songs and tunes. Their CD is enjoyable listening and comes highly-recommended” - Steve Goldfield             Bluegrass Unlimited June 2010

“ What happens when three good friends, all of them excellent musicians, combine forces and form a band? They weld themselves into a fine band, that’s what! And we have this cd to prove it.' - Pete Peterson      The Old Time Herald        April-May 2010 issue'",
                                   Gemm = "RDFD344",
                                   Band = ramblers,
                                   Genre = oldTimeGenre
                               };
            virginia.Songs.Add(mp3);
            virginia.Songs.Add(ogg);
            virginia.Products.Add(cd);

            SaveChanges();
        }
    }
}