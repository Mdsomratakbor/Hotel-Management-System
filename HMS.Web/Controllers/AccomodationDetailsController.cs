using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Web.Controllers
{
    public class AccomodationDetailsController : Controller
    {
        // GET: AccomodationDetails
        public ActionResult Index(int accomodationTypeId)
        {
            return View();
        }
    }
}