using HMS.Entities;
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
        private AccomodationType _AccomodationType;
        public AccomodationTypeController()
        {
           _AccomodationTypeService = new AccomodationTypeService();
            _AccomodationType = new AccomodationType();
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
        [HttpGet]
        public PartialViewResult Action(int? id)
        {
              _AccomodationTypeService.GetAccomodationById(id.Value);
            return PartialView("_Action");
        }
        [HttpPost]
        public JsonResult Action(AccomodationTypeModel model)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var message = "";
            bool data = false;
            try
            {
                if (ModelState.IsValid)
                {
                    _AccomodationType.ID = model.ID;
                    _AccomodationType.Name = model.Name;
                    _AccomodationType.Description = model.Description;
                    data = _AccomodationTypeService.SaveAccomodationType(_AccomodationType);
                }
                else
                {
                    message = "Please enter valid data!!";
                   
                }
                         
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            if (data)
            { 
                message = "Data Save Successfully!!";
                result.Data = new { Success = true, Message = message };
            }                
            else
            {
                result.Data = new { Success = false, Message = message };
            }
            return result;

        }
    }
}