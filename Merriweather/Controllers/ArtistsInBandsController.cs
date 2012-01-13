using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merriweather.Models;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class ArtistsInBandsController : Controller
    {
        MerriweatherContext db = new MerriweatherContext();
        private IArtistRepository artistRepository;

        public ArtistsInBandsController()
        {
            artistRepository = new ArtistRepository();
        }

        //[HttpPost]
        //public ActionResult ArtistsInBand(Dictionary<Artist, bool> model)
        //{
        //    artistRepository = new MvcMusicStore.Models.ArtistRepository();
        //    return new EmptyResult();
        //}

        //public ActionResult ArtistsInBand(int id)
        //{
        //    var artists = artistRepository.GetAllArtists();
        //    var dict = artists.ToDictionary(i => i,k=>artistRepository.HasBand(k.Id));
        //    return PartialView(dict);
        //}
    }
}
