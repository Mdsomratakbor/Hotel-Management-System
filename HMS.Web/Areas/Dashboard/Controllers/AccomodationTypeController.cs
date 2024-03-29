﻿using HMS.Entities;
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
        public PartialViewResult Listing(string searchTearm, int? pageNo, int? pageSize)
        {
            AccomodationTypeListingModel model = new AccomodationTypeListingModel();
            pageNo = pageNo ?? 1;
            pageSize = pageSize ?? 10;
            model.AccomodationTypes = _AccomodationTypeService.GetAllAccomodationType(searchTearm, pageNo.Value, pageSize.Value);
            int totalItems = _AccomodationTypeService.TotalItemCount(searchTearm);
            model.Pager = new Pager(totalItems, pageNo, pageSize.Value);
            model.SearchTerm = searchTearm;
            model.PageNo = pageNo.Value;
            model.PageSize = pageSize.Value;
            return PartialView("_Listing",model);
        }
        [HttpGet]
        public PartialViewResult Action(int? id)
        {
            AccomodationTypeModel model = new AccomodationTypeModel();
            if (id.HasValue)
            {
                _AccomodationType = _AccomodationTypeService.GetAccomodationById(id.Value);
                model.ID = _AccomodationType.ID;
                model.Name = _AccomodationType.Name;
                model.Description = _AccomodationType.Description;
            }

            return PartialView("_Action",model);
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
                    if (model.ID > 0)
                    {
                        _AccomodationType = _AccomodationTypeService.GetAccomodationById(model.ID);
                        _AccomodationType.Name = model.Name;
                        _AccomodationType.Description = model.Description;
                        data = _AccomodationTypeService.UpdateAccomodationType(_AccomodationType);
                    }
                    else
                    {
                        _AccomodationType.ID = model.ID;
                        _AccomodationType.Name = model.Name;
                        _AccomodationType.Description = model.Description;
                        data = _AccomodationTypeService.SaveAccomodationType(_AccomodationType);
                    }
                   
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
                    _AccomodationType = _AccomodationTypeService.GetAccomodationById(id);
                     data = _AccomodationTypeService.DeleteAccomodationType(_AccomodationType);
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