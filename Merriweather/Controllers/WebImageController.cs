using System;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
using System.Web.Mvc;
using Merriweather.Models;

namespace Merriweather.Controllers
{
    public interface IFileStore
    {
        Guid SaveUploadedFile(HttpPostedFileBase fileBase);
    }

    internal class DiskFileStore : IFileStore
    {

        private string _uploadsFolder = HostingEnvironment.MapPath("~/Content/uploads");

        public Guid SaveUploadedFile(HttpPostedFileBase fileBase)
        {
            var identifier = Guid.NewGuid();
            fileBase.SaveAs(GetDiskLocation(identifier));
            return identifier;
        }

        private string GetDiskLocation(Guid identifier)
        {
            return Path.Combine(_uploadsFolder, identifier.ToString());
        }
    }

    public class WebImageController : Controller
    {
        // In a real app, populate this using IoC so you can mock it for tests
        //private IFileStore _fileStore = new DiskFileStore();
        private string _uploadsFolder = HostingEnvironment.MapPath("~/Content/uploads");
        
        public string AsyncUpload()
        {

            var image = WebImage.GetImageFromRequest(); //Request.Files[0];
            image.Resize(200, 200);
            var filename = Path.GetFileName(image.FileName);
            image.Save(Path.Combine(_uploadsFolder, filename));
            return filename;
        }

        //    public ActionResult Upload(IImage model)
        //    {
        //        var image = WebImage.GetImageFromRequest();

        //        if (image != null)
        //        {
        //            if (image.Width > 500)
        //            {
        //                image.Resize(500, ((500 * image.Height) / image.Width));
        //            }

        //            var filename = Path.GetFileName(image.FileName);
        //            image.Save(Path.Combine("../TempImages", filename));
        //            filename = Path.Combine("~/TempImages", filename);

        //            model.ImageUrl = Url.Content(filename);
        //            var editModel = new EditorInputModel()
        //            {
        //                Image = model,
        //                Width = image.Width,
        //                Height = image.Height,

        //                Top = image.Height * 0.1,
        //                Left = image.Width * 0.9,
        //                Right = image.Width * 0.9,
        //                Bottom = image.Height * 0.9
        //            };
        //            return View("Editor", editModel);
        //        }

        //        return View("Index", model);
        //    }
        //}
    }

    public interface IImage
    {
        string ImageUrl { get; set; }
    }
}
