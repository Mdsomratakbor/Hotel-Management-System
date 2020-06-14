using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Web.Areas.Dashboard.Controllers
{
    public class SharedController : Controller
    {
        // GET: Dashboard/Shared
        public ActionResult Index()
        {
            return View();
        }

        
        public JsonResult UploadPicture()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var files = Request.Files;
            for(int i=0; i<files.Count; i++)
            {
                var picture = files[i];
                var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images/AccomodationPackage/"), fileName);
                picture.SaveAs(path);
            }
            return result;
        }
    }
}