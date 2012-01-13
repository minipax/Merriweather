using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Merriweather.Models;

namespace MvcMusicStore.Models
{ 
    public class ArtistRepository : IArtistRepository
    {
        MerriweatherContext context = new MerriweatherContext();

        public IEnumerable<Artist> GetAllArtists(params Expression<Func<Artist, object>>[] includeProperties)
        {
            IQueryable<Artist> query = context.Artists;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            query.Include("Bands");
            return query.ToList();
        }

        public Artist GetById(int id)
        {
            return context.Artists.Find(id);
        }

        public void InsertOrUpdate(Artist artist)
        {
            if (artist.Id == default(int)) {
                // New entity
                context.Artists.Add(artist);
            } else {
                // Existing entity
                context.Artists.Attach(artist);
                context.Entry(artist).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var artist = context.Artists.Find(id);
            context.Artists.Remove(artist);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

	public interface IArtistRepository
    {
		IEnumerable<Artist> GetAllArtists(params Expression<Func<Artist, object>>[] includeProperties);
		Artist GetById(int id);
		void InsertOrUpdate(Artist artist);
        void Delete(int id);
        void Save();
    }
}