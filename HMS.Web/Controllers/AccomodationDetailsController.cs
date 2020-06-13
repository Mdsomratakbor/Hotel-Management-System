using HMS.Services;
using HMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HMS.Web.Controllers
{
    public class AccomodationDetailsController : Controller
    {
        private AccomodationTypeService _AccomodationTypeService;
        private AccomodationPackagesService _AccomodationPackagesService;
        private AccomodationService _AccomodationService;
        private AccomodationDitailsViewModel _model;
        public AccomodationDetailsController()
        {
            _AccomodationTypeService = new AccomodationTypeService();
            _AccomodationPackagesService = new AccomodationPackagesService();
            _AccomodationService = new AccomodationService();
            _AccomodationTypeService = new AccomodationTypeService();
            _model = new AccomodationDitailsViewModel();
        }
        // GET: AccomodationDetails
        public  ActionResult Index(int accomodationTypeID, int? accomodationPackageID)
        {
            _model.AccomodationPackages =  _AccomodationPackagesService.GetAccomodationPackageByAccomodationTypeId(accomodationTypeID);
            _model.SelctedAccomodationPackageID = accomodationPackageID.HasValue? accomodationPackageID.Value:_model.AccomodationPackages.FirstOrDefault().ID;
            _model.Accomodations = _AccomodationService.GetAccomodationByAccomodationPackageId(_model.SelctedAccomodationPackageID);
            _model.AccomodationTypeId = accomodationTypeID;
            return View(_model);
        }
    }
}