using HMS.Entities;
using HMS.Services;
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
        private SharedService _SharedService;

        public SharedController()
        {
            _SharedService = new SharedService();

        }
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
            List<object> pictuerJSON = new List<object>();
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var picture = files[i];
                    var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/AccomodationPackage/"), fileName);
                    picture.SaveAs(path);
                    var dbPictuer = new Picture();
                    dbPictuer.URL = fileName;
                    int pictureID = _SharedService.SavePicture(dbPictuer);
                    pictuerJSON.Add(new { ID = pictureID, URL = dbPictuer.URL });

                }
                result.Data = new { Success = true, pictuerJSON };
            }
            
            catch (Exception ex)
            {
                result.Data = new { Success = false, Message = ex.Message };
            }
            return result;
        }
    }
}