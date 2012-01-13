using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merriweather.Models;
using Merriweather.ViewModels;
using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;

namespace MvcMusicStore.Controllers
{   
    public class BandsController : Controller
    {
		private readonly IBandRepository bandRepository;
        private IArtistRepository artistRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public BandsController() : this(new BandRepository(), new ArtistRepository())
        {
        }

        public BandsController(IBandRepository _bandRepository, IArtistRepository _artistRepository)
        {
			bandRepository = _bandRepository;
            artistRepository = _artistRepository;
        }

        //
        // GET: /Bands/

        public ViewResult Index()
        {
            return View(bandRepository.GetAllBands(band => band.Albums, band => band.Artists));
        }

        //
        // GET: /Bands/Details/5

        public ViewResult Details(int id)
        {
            return View(bandRepository.GetById(id));
        }

        //
        // GET: /Bands/Create

        public ActionResult Create()
        {
            var model = new BandEditModel {ArtistCheckedList = GetArtistCheckBoxes()};
            return View(model);
        } 

        //
        // POST: /Bands/Create

        [HttpPost]
        public ActionResult Create(BandEditModel bandEditModel)
        {
            if (ModelState.IsValid)
            {
                bandRepository.InsertOrUpdate(bandEditModel.Band);
                bandRepository.Save();

                //Update the artists
                bandRepository.UpdateArtists(bandEditModel.Band.Id, bandEditModel.ArtistCheckedList);

                return RedirectToAction("Index");
            }
            else
            {
                return View(bandEditModel);
            }
            return View(bandEditModel);
        }
        
        //
        // GET: /Bands/Edit/5
 
        public ActionResult Edit(int id)
        {
            BandEditModel model = new BandEditModel {Band = bandRepository.GetById(id)};
            model.ArtistCheckedList = GetArtistCheckBoxes(id);
            return View(model);
        }

        private CheckedList<Artist> GetArtistCheckBoxes()
        {
            var artists = artistRepository.GetAllArtists();
            var checkList = new CheckedList<Artist>();
            foreach (var artist in artists)
            {
                checkList.Add(artist, false);
            }
            return checkList;
        }

        /// <summary>
        /// Band Id
        /// </summary>
        /// <param name="id">Band Id</param>
        /// <returns></returns>
        private CheckedList<Artist> GetArtistCheckBoxes(int id)
        {
            var artists = artistRepository.GetAllArtists();
            var checkList = new CheckedList<Artist>();
            foreach (var artist in artists)
            {
                bool isChecked = artist.Bands == null ? false : artist.Bands.Any(x => x.Id == id);
                checkList.Add(artist, isChecked);
            }
            return checkList;
        }

        //
        // POST: /Bands/Edit/5

        [HttpPost]
        public ActionResult Edit(BandEditModel bandEditModel)
        {
            if (ModelState.IsValid) {
                bandRepository.InsertOrUpdate(bandEditModel.Band);
                bandRepository.Save();
                bandRepository.UpdateArtists(bandEditModel.Band.Id, bandEditModel.ArtistCheckedList);
                return RedirectToAction("Index");
            } else {
                return View(bandEditModel);
			}
        }

        //
        // GET: /Bands/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(bandRepository.GetById(id));
        }

        //
        // POST: /Bands/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bandRepository.Delete(id);
            bandRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

