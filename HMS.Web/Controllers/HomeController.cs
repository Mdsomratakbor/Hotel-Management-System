using HMS.Services;
using HMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private HomeViewModel _HomeViewModel;
        private AccomodationTypeService _AccomodationTypeService;
        private AccomodationPackagesService _AccomodationPackagesService;
        public HomeController()
        {
            _HomeViewModel = new HomeViewModel();
            _AccomodationTypeService = new AccomodationTypeService();
            _AccomodationPackagesService = new AccomodationPackagesService();
        }
        public ActionResult Index()
        {
            _HomeViewModel.AccomodationTypes = _AccomodationTypeService.GetAllAccomodationType();
            _HomeViewModel.AccomodtionPackages = _AccomodationPackagesService.GetAllAccomodationPackage();
            return View(_HomeViewModel);
        }

    }
}