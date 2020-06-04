using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Web.Areas.Dashboard.Controllers
{
    public class AccomodationTypeController : Controller
    {
        // GET: Dashboard/AccomodationType
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ListingView()
        {
            return PartialView();
        }
    }
}