using System.Web.Mvc;
using Merriweather.Models;
using MvcMusicStore.Models;

namespace Merriweather.Controllers
{   
    public class AlbumsController : Controller
    {
		private readonly IBandRepository bandRepository;
		private readonly IGenreRepository genreRepository;
		private readonly IAlbumRepository albumRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public AlbumsController() : this(new BandRepository(), new GenreRepository(), new AlbumRepository())
        {
        }

        public AlbumsController(IBandRepository bandRepository, IGenreRepository genreRepository, IAlbumRepository albumRepository)
        {
			this.bandRepository = bandRepository;
			this.genreRepository = genreRepository;
			this.albumRepository = albumRepository;
        }

        //
        // GET: /Album/

        public ViewResult Index()
        {
            return View(albumRepository.GetAllAlbums(album => album.OrderDetails, album => album.Songs, album => album.Band, album => album.Genre));
        }

        //
        // GET: /Album/Details/5

        public ViewResult Details(int id)
        {
            return View(albumRepository.GetById(id));
        }

        //
        // GET: /Album/Create

        public ActionResult Create()
        {
			ViewBag.PossibleBands = bandRepository.GetAllBands();
			ViewBag.PossibleGenres = genreRepository.GetAllGenres();
            return View();
        } 

        //
        // POST: /Album/Create

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid) {
                albumRepository.InsertOrUpdate(album);
                albumRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleBands = bandRepository.GetAllBands();
				ViewBag.PossibleGenres = genreRepository.GetAllGenres();
				return View();
			}
        }
        
        //
        // GET: /Album/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleBands = bandRepository.GetAllBands();
			ViewBag.PossibleGenres = genreRepository.GetAllGenres();
             return View(albumRepository.GetById(id));
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid) {
                albumRepository.InsertOrUpdate(album);
                albumRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleBands = bandRepository.GetAllBands();
				ViewBag.PossibleGenres = genreRepository.GetAllGenres();
				return View();
			}
        }

        //
        // GET: /Album/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(albumRepository.GetById(id));
        }

        //
        // POST: /Album/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            albumRepository.Delete(id);
            albumRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

