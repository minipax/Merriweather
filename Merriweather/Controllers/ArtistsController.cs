using System.Web.Mvc;
using Merriweather.Models;
using MvcMusicStore.Models;

namespace Merriweather.Controllers
{   
    public class ArtistsController : Controller
    {
		private readonly IArtistRepository artistRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ArtistsController() : this(new ArtistRepository())
        {
        }

        public ArtistsController(IArtistRepository artistRepository)
        {
			this.artistRepository = artistRepository;
        }

        //
        // GET: /Artist/

        public ViewResult Index()
        {
            return View(artistRepository.GetAllArtists(artist => artist.Bands));
        }

        //
        // GET: /Artist/Details/5

        public ViewResult Details(int id)
        {
            return View(artistRepository.GetById(id));
        }

        //
        // GET: /Artist/Create
        [Authorize]
        public ActionResult Create()
        {

            return View();
        } 

        //
        // POST: /Artist/Create

        [HttpPost, Authorize]
        public ActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                ViewBag.HtmlContent = artist.Article;
                artistRepository.InsertOrUpdate(artist);
                artistRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Artist/Edit/5
 [Authorize]
        public ActionResult Edit(int id)
        {
             return View(artistRepository.GetById(id));
        }

        //
        // POST: /Artist/Edit/5

        [HttpPost, Authorize]
        public ActionResult Edit(Artist artist)
        {
            if (ModelState.IsValid) {
                artistRepository.InsertOrUpdate(artist);
                artistRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Artist/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(artistRepository.GetById(id));
        }

        //
        // POST: /Artist/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            artistRepository.Delete(id);
            artistRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

