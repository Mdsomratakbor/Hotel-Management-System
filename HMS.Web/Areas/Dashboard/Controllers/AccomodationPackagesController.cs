using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Web.Areas.Dashboard.Controllers
{
    public class AccomodationPackagesController : Controller
    {
        // GET: Dashboard/AccomodationPackages
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Listing()
        {
            return PartialView();
        }
        public PartialViewResult Action()
        {
            return PartialView();
        }
        //[HttpPost]
        //public JsonResult Action()
        //{
        //    return JsonResult resutl = new JsonResult();
        //}

    }
}