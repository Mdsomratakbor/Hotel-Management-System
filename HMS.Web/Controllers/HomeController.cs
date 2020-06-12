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
        public HomeController()
        {
            _HomeViewModel = new HomeViewModel();
            _AccomodationTypeService = new AccomodationTypeService();
        }
        public ActionResult Index()
        {
            _HomeViewModel.AccomodationTypes = _AccomodationTypeService.GetAllAccomodationType();
            return View(_HomeViewModel);
        }

    }
}