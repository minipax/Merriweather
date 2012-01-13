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
    public class AlbumRepository : IAlbumRepository
    {
        MerriweatherContext context = new MerriweatherContext();

        public IEnumerable<Album> GetAllAlbums(params Expression<Func<Album, object>>[] includeProperties)
        {
            IQueryable<Album> query = context.Albums;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

        public Album GetById(int id)
        {
            return context.Albums.Find(id);
        }

        public void InsertOrUpdate(Album album)
        {
            if (album.Id == default(int)) {
                // New entity
                context.Albums.Add(album);
            } else {
                // Existing entity
                context.Albums.Attach(album);
                context.Entry(album).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var album = context.Albums.Find(id);
            context.Albums.Remove(album);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

	public interface IAlbumRepository
    {
		IEnumerable<Album> GetAllAlbums(params Expression<Func<Album, object>>[] includeProperties);
		Album GetById(int id);
		void InsertOrUpdate(Album album);
        void Delete(int id);
        void Save();
    }
}