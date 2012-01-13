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
    public class WebpageRepository : IWebpageRepository
    {
        MerriweatherContext context = new MerriweatherContext();

        public WebpageRepository()
        {
            if (!context.Webpages.Any(x => x.Name == "Home"))
            {
                context.Webpages.Add(new Webpage
                {
                    Name = "Home",
                    PageContent = StaticOldBackup.HomePage,
                    IsPublished = true
                });
                context.SaveChanges();
            }
        }

        public IEnumerable<Webpage> GetAllWebpages(params Expression<Func<Webpage, object>>[] includeProperties)
        {
            IQueryable<Webpage> query = context.Webpages;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

        public Webpage GetById(int id)
        {
            return context.Webpages.Find(id);
        }

        public void InsertOrUpdate(Webpage webpage)
        {
            if (webpage.Id == default(int)) {
                // New entity
                context.Webpages.Add(webpage);
            } else {
                // Existing entity
                context.Webpages.Attach(webpage);
                context.Entry(webpage).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var webpage = context.Webpages.Find(id);
            context.Webpages.Remove(webpage);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

	public interface IWebpageRepository
    {
		IEnumerable<Webpage> GetAllWebpages(params Expression<Func<Webpage, object>>[] includeProperties);
		Webpage GetById(int id);
		void InsertOrUpdate(Webpage webpage);
        void Delete(int id);
        void Save();
    }
}