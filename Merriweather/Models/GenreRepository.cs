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
    public class GenreRepository : IGenreRepository
    {
        MerriweatherContext context = new MerriweatherContext();

        public IEnumerable<Genre> GetAllGenres(params Expression<Func<Genre, object>>[] includeProperties)
        {
            IQueryable<Genre> query = context.Genres;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

        public Genre GetById(int id)
        {
            return context.Genres.Find(id);
        }

        public void InsertOrUpdate(Genre genre)
        {
            if (genre.GenreId == default(int)) {
                // New entity
                context.Genres.Add(genre);
            } else {
                // Existing entity
                context.Genres.Attach(genre);
                context.Entry(genre).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var genre = context.Genres.Find(id);
            context.Genres.Remove(genre);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

	public interface IGenreRepository
    {
		IEnumerable<Genre> GetAllGenres(params Expression<Func<Genre, object>>[] includeProperties);
		Genre GetById(int id);
		void InsertOrUpdate(Genre genre);
        void Delete(int id);
        void Save();
    }
}