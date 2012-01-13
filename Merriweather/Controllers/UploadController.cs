using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult Save(IEnumerable<HttpPostedFileBase> attachments)
        {
            // The Name of the Upload component is "attachments" 
            foreach (var file in attachments)
            {
                // Some browsers send file names with full path. This needs to be stripped.
                var fileName = Path.GetFileName(file.FileName);
                var physicalPath = Path.Combine(Server.MapPath("~/Content/uploads"), fileName);

                file.SaveAs(physicalPath);
            }
            // Return an empty string to signify success
            return Content("");
        }
        public ActionResult Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"
            foreach (var fullName in fileNames)
            {
                var fileName = Path.GetFileName(fullName);
                var physicalPath = Path.Combine(Server.MapPath("~/Content/uploads"), fileName);

                // TODO: Verify user permissions
                if (System.IO.File.Exists(physicalPath))
                {
                    System.IO.File.Delete(physicalPath);
                }
            }
            // Return an empty string to signify success
            return Content("");
        }


    }
}
