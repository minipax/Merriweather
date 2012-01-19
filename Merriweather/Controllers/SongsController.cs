using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{   
    public class SongsController : Controller
    {
		private readonly IAlbumRepository albumRepository;
		private readonly ISongRepository songRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public SongsController() : this(new AlbumRepository(), new SongRepository())
        {
        }

        public SongsController(IAlbumRepository albumRepository, ISongRepository songRepository)
        {
			this.albumRepository = albumRepository;
			this.songRepository = songRepository;
        }

        //
        // GET: /Song/

        public ViewResult Index()
        {
            return View(songRepository.GetAllSongs(song => song.Album));
        }

        //
        // GET: /Song/Details/5

        public ViewResult Details(int id)
        {
            return View(songRepository.GetById(id));
        }

        //
        // GET: /Song/Create

        public ActionResult Create()
        {
			ViewBag.PossibleAlbums = albumRepository.GetAllAlbums();
            return View();
        } 

        //
        // POST: /Song/Create

        [HttpPost]
        public ActionResult Create(Song song)
        {
            if (ModelState.IsValid) {
                songRepository.InsertOrUpdate(song);
                songRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleAlbums = albumRepository.GetAllAlbums();
				return View();
			}
        }
        
        //
        // GET: /Song/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleAlbums = albumRepository.GetAllAlbums();
             return View(songRepository.GetById(id));
        }

        //
        // POST: /Song/Edit/5

        [HttpPost]
        public ActionResult Edit(Song song)
        {
            if (ModelState.IsValid) {
                songRepository.InsertOrUpdate(song);
                songRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleAlbums = albumRepository.GetAllAlbums();
				return View();
			}
        }

        //
        // GET: /Song/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(songRepository.GetById(id));
        }

        //
        // POST: /Song/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            songRepository.Delete(id);
            songRepository.Save();

            return RedirectToAction("Index");
        }

        public string Upload()
        {
            var _uploadsFolder = HostingEnvironment.MapPath("~/Content/music/");
            var song = Request.Files[0];
            var filename = Path.GetFileName(song.FileName);
            song.SaveAs(Path.Combine(_uploadsFolder, filename));
            return filename;
        }
    }
}

