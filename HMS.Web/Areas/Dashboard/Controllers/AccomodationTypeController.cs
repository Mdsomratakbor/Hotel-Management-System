using HMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Web.Areas.Dashboard.Controllers
{
    public class AccomodationTypeController : Controller
    {
        private AccomodationTypeService _AccomodationTypeService;
        public AccomodationTypeController(AccomodationTypeService _AccomodationTypeService)
        {
            this._AccomodationTypeService = _AccomodationTypeService;
        }
        // GET: Dashboard/AccomodationType
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Listing()
        {
            var accomodationType = _AccomodationTypeService.GetAllAccomodationType();
            return PartialView("_Listing");
        }
    }
}