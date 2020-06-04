using HMS.Services;
using HMS.Web.Areas.Dashboard.ViewModels;
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
        public AccomodationTypeController()
        {
           _AccomodationTypeService = new AccomodationTypeService();
        }
        // GET: Dashboard/AccomodationType
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Listing()
        {
            AccomodationTypeListingModel model = new AccomodationTypeListingModel();
            model.AccomodationTypes = _AccomodationTypeService.GetAllAccomodationType(); ;
            return PartialView("_Listing",model);
        }
    }
}