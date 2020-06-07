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
    public class AccomodationController : Controller
    {
        private AccomodationService _AccomodationService;
        private Accomodation _Accomodation;
        private AccomodationPackagesService _AccomodationPackagesService;
        public AccomodationController()
        {
            _AccomodationPackagesService = new AccomodationPackagesService();
            _AccomodationService = new AccomodationService();
            _Accomodation = new Accomodation();
        }
        // GET: Dashboard/AccomodationType
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Listing(string searchTearm,int? AccomodationPackageId, int? pageNo, int? pageSize)
        {
            AccomodationListingModel model = new AccomodationListingModel();
            pageNo = pageNo ?? 1;
            pageSize = pageSize ?? 10;
            model.Accomodations = _AccomodationService.GetAllAccomodation(searchTearm, AccomodationPackageId.Value, pageNo.Value, pageSize.Value);
            int totalItems = _AccomodationService.TotalItemCount(searchTearm);
            model.Pager = new Pager(totalItems, pageNo, pageSize.Value);
            model.SearchTerm = searchTearm;
            model.PageNo = pageNo.Value;
            model.PageSize = pageSize.Value;
            return PartialView("_Listing", model);
        }
        [HttpGet]
        public PartialViewResult Action(int? id)
        {
            AccomodationModel model = new AccomodationModel();
            if (id.HasValue)
            {
                _Accomodation = _AccomodationService.GetAccomodationById(id.Value);
                //model.ID = _AccomodationService.ID;
                //model.NoOfRoom = _AccomodationService.NoOfRoom;
                //model.AccomodationTypeID = _AccomodationService.AccomodationTypeID;
                //model.FeePerNight = _AccomodationService.FeePerNight;
            }
            model.AccomodationPackage = _AccomodationPackagesService.GetAllAccomodationPackage();

            return PartialView("_Action", model);
        }
        [HttpPost]
        public JsonResult Action(AccomodationPackagesModel model)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var message = "";
            bool data = false;
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ID > 0)
                    {
                        //_Accomodation = _AccomodationService.GetAccomodationById(model.ID);
                        //_Accomodation.NoOfRoom = model.NoOfRoom;
                        //_Accomodation.Name = model.Name;
                        //_Accomodation.FeePerNight = model.FeePerNight;
                        //_Accomodation.AccomodationTypeID = model.AccomodationTypeID;
                        //data = _AccomodationService.UpdateAccomodationType(_Accomodation);
                    }
                    else
                    {
                        //_Accomodation.ID = model.ID;
                        //_Accomodation.Name = model.Name;
                        //_Accomodation.NoOfRoom = model.NoOfRoom;
                        //_Accomodation.FeePerNight = model.FeePerNight;
                        //_Accomodation.AccomodationTypeID = model.AccomodationTypeID;
                        //data = _AccomodationService.SaveAccomodationType(_Accomodation);
                    }

                }
                else
                {
                    message = "Please enter valid data!!";

                }

            }
            catch (Exception ex)
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

        public JsonResult Delete(int id)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            dynamic message = "";
            var data = false;
            try
            {
                if (id > 0)
                {
                    _Accomodation = _AccomodationService.GetAccomodationById(id);
                    data = _AccomodationService.DeleteAccomodation(_Accomodation);
                }
                else
                {
                    message = "Please click valid item";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            if (data)
            {
                message = "Data Delete Successfully !!";
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