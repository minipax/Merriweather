using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Merriweather.Models;
using Merriweather.ViewModels;
using MvcMusicStore.ViewModels;

namespace MvcMusicStore.Models
{ 
    public class BandRepository : IBandRepository
    {
        MerriweatherContext context = new MerriweatherContext();

        public IEnumerable<Band> GetAllBands(params Expression<Func<Band, object>>[] includeProperties)
        {
            IQueryable<Band> query = context.Bands;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            query.Include("Artists");
            return query.ToList();
        }

        public Band GetById(int id)
        {
            return context.Bands.Find(id);
        }

        public void InsertOrUpdate(Band band)
        {
            if (band.Id == default(int)) {
                // New entity
                context.Bands.Add(band);
            } else {
                // Existing entity
                context.Bands.Attach(band);
                context.Entry(band).State = EntityState.Modified;
            }
        }



        public void Delete(int id)
        {
            var band = context.Bands.Find(id);
            context.Bands.Remove(band);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">BandId</param>
        /// <param name="checkedList"></param>
        public void UpdateArtists(int id, CheckedList<Artist> checkedList)
        {
            var band = context.Bands.Include(x=>x.Artists).Single(x=>x.Id == id);
            foreach (var artist in checkedList)
            {
                //There is no artist registered with this band, so add it
                if (artist.Value == true && !DoesThisBandHaveThisArtist(artist.Key.Id,band))
                {
                    if (band.Artists == null)
                    {
                        band.Artists = new List<Artist>();
                    }
                    band.Artists.Add(context.Artists.Find(artist.Key.Id));
                }
                else if (artist.Value == false && DoesThisBandHaveThisArtist(artist.Key.Id, band))
                    band.Artists.Remove(context.Artists.Find(artist.Key.Id));
            }
            Save();
        }

        public bool DoesThisBandHaveThisArtist(int artistId, Band band)
        {
            //Check to see if there are any bands attached at all
            if (band.Artists.Count() > 0)
            {
                var bandArtists = band.Artists;
                var doesBandHaveArtist = bandArtists.Any(a => a.Id == artistId);
                return doesBandHaveArtist;
            }
            else
                return false;
        }
    }

	public interface IBandRepository
    {
		IEnumerable<Band> GetAllBands(params Expression<Func<Band, object>>[] includeProperties);
		Band GetById(int id);
		void InsertOrUpdate(Band band);
        void Delete(int id);
        void Save();
	    void UpdateArtists(int id, CheckedList<Artist> checkedList);
    }
}