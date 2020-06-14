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
    public class AccomodationPackagesController : Controller
    {
        private AccomodationPackagesService _AccomodationPackagesService;
        private AccomodationPackage _AccomodationPackage;
        private AccomodationTypeService _AccomodationTypeService;
        private SharedService _SharedService;
        private Picture _Picture;
        public AccomodationPackagesController()
        {
            _AccomodationPackagesService = new AccomodationPackagesService();
            _AccomodationPackage = new AccomodationPackage();
            _AccomodationTypeService = new AccomodationTypeService();
            _Picture = new Picture();
            _SharedService = new SharedService();
        }
        // GET: Dashboard/AccomodationType
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Listing(string searchTearm, int? pageNo, int? pageSize)
        {
            AccomodationPackagesListingModel model = new AccomodationPackagesListingModel();
            pageNo = pageNo ?? 1;
            pageSize = pageSize ?? 10;
            model.AccomodationPackages = _AccomodationPackagesService.GetAllAccomodationPackage(searchTearm, pageNo.Value, pageSize.Value);
            int totalItems = _AccomodationPackagesService.TotalItemCount(searchTearm);
            model.Pager = new Pager(totalItems, pageNo, pageSize.Value);
            model.SearchTerm = searchTearm;
            model.PageNo = pageNo.Value;
            model.PageSize = pageSize.Value;
            return PartialView("_Listing", model);
        }
        [HttpGet]
        public PartialViewResult Action(int? id)
        {
            AccomodationPackagesModel model = new AccomodationPackagesModel();
            if (id.HasValue)
            {
                _AccomodationPackage = _AccomodationPackagesService.GetAccomodationPackagesById(id.Value);
                model.ID = _AccomodationPackage.ID;
                model.NoOfRoom = _AccomodationPackage.NoOfRoom;
                model.AccomodationTypeID = _AccomodationPackage.AccomodationTypeID;
                model.FeePerNight = _AccomodationPackage.FeePerNight;
            }
                model.AccomodationType = _AccomodationTypeService.GetAllAccomodationType();

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
                        _AccomodationPackage = _AccomodationPackagesService.GetAccomodationPackagesById(model.ID);
                        _AccomodationPackage.NoOfRoom = model.NoOfRoom;
                        _AccomodationPackage.Name = model.Name;
                        _AccomodationPackage.FeePerNight = model.FeePerNight;
                        _AccomodationPackage.AccomodationTypeID = model.AccomodationTypeID;
                        data = _AccomodationPackagesService.UpdateAccomodationPackages(_AccomodationPackage);
                    }
                    else
                    {
                        List<int> picturesIDs = model.PictureIDs.Split(',').Select(x => int.Parse(x)).ToList();
                        var pictures = _SharedService.GetPicturesByIDs(picturesIDs);
                        _AccomodationPackage.AccomodationPackagePictures = new List<AccomodationPackagePictures>();
                        _AccomodationPackage.AccomodationPackagePictures.AddRange(pictures.Select(x => new AccomodationPackagePictures() { PictuerID = x.ID }));
                        _AccomodationPackage.ID = model.ID;
                        _AccomodationPackage.Name = model.Name;
                        _AccomodationPackage.NoOfRoom = model.NoOfRoom;
                        _AccomodationPackage.FeePerNight = model.FeePerNight;
                        _AccomodationPackage.AccomodationTypeID = model.AccomodationTypeID;
                        data = _AccomodationPackagesService.SaveAccomodationPackages(_AccomodationPackage);
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
                    _AccomodationPackage = _AccomodationPackagesService.GetAccomodationPackagesById(id);
                    data = _AccomodationPackagesService.DeleteAccomodationPackages(_AccomodationPackage);
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