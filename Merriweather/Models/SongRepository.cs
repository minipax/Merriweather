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
    public class SongRepository : ISongRepository
    {
        MerriweatherContext context = new MerriweatherContext();

        public IEnumerable<Song> GetAllSongs(params Expression<Func<Song, object>>[] includeProperties)
        {
            IQueryable<Song> query = context.Songs;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

        public Song GetById(int id)
        {
            return context.Songs.Find(id);
        }

        public void InsertOrUpdate(Song song)
        {
            if (song.Id == default(int)) {
                // New entity
                context.Songs.Add(song);
            } else {
                // Existing entity
                context.Songs.Attach(song);
                context.Entry(song).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var song = context.Songs.Find(id);
            context.Songs.Remove(song);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

	public interface ISongRepository
    {
		IEnumerable<Song> GetAllSongs(params Expression<Func<Song, object>>[] includeProperties);
		Song GetById(int id);
		void InsertOrUpdate(Song song);
        void Delete(int id);
        void Save();
    }
}