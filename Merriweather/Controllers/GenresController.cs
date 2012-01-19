using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merriweather.Models;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{   
    public class GenresController : Controller
    {
		private readonly IGenreRepository genreRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public GenresController() : this(new GenreRepository())
        {
        }

        public GenresController(IGenreRepository genreRepository)
        {
			this.genreRepository = genreRepository;
        }

        //
        // GET: /Genre/

        public ViewResult Index()
        {
            return View(genreRepository.GetAllGenres(genre => genre.Albums));
        }

        //
        // GET: /Genre/Details/5

        public ViewResult Details(int id)
        {
            return View(genreRepository.GetById(id));
        }

        //
        // GET: /Genre/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Genre/Create

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid) {
                genreRepository.InsertOrUpdate(genre);
                genreRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Genre/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(genreRepository.GetById(id));
        }

        //
        // POST: /Genre/Edit/5

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid) {
                genreRepository.InsertOrUpdate(genre);
                genreRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Genre/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(genreRepository.GetById(id));
        }

        //
        // POST: /Genre/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            genreRepository.Delete(id);
            genreRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

