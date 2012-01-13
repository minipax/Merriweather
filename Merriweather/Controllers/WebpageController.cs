using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{   
    public class WebpageController : Controller
    {
		private readonly IWebpageRepository webpageRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public WebpageController() : this(new WebpageRepository())
        {
        }

        public WebpageController(IWebpageRepository webpageRepository)
        {
			this.webpageRepository = webpageRepository;
        }

        //
        // GET: /Webpage/

        public ViewResult Index()
        {
            return View(webpageRepository.GetAllWebpages());
        }

        //
        // GET: /Webpage/Details/5

        public ViewResult Details(int id)
        {
            return View(webpageRepository.GetById(id));
        }

        //
        // GET: /Webpage/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Webpage/Create

        [HttpPost]
        public ActionResult Create(Webpage webpage)
        {
            if (ModelState.IsValid) {
                webpageRepository.InsertOrUpdate(webpage);
                webpageRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Webpage/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(webpageRepository.GetById(id));
        }

        //
        // POST: /Webpage/Edit/5

        [HttpPost]
        public ActionResult Edit(Webpage webpage)
        {
            if (ModelState.IsValid) {
                webpageRepository.InsertOrUpdate(webpage);
                webpageRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Webpage/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(webpageRepository.GetById(id));
        }

        //
        // POST: /Webpage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            webpageRepository.Delete(id);
            webpageRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

