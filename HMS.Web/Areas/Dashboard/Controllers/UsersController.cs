using HMS.Services;
using HMS.Web.Areas.Dashboard.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Web.Areas.Dashboard.Controllers
{
    public class UsersController : Controller
    {
        private HMSSignInManagerService _signInManager;
        private HMSUserManagerService _userManager;

        public UsersController()
        {
        }

        public UsersController(HMSUserManagerService userManager, HMSSignInManagerService signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public HMSSignInManagerService SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<HMSSignInManagerService>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public HMSUserManagerService UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<HMSUserManagerService>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Dashboard/Users
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Listing(string searchTearm, int? accomodationPackageId, int? pageNo, int? pageSize)
        {
            UserListingModel model = new UserListingModel();
            pageNo = pageNo ?? 1;
            pageSize = pageSize ?? 10;
            model.Users = UserManager.Users;
            //model.AccomodatioPackages = _AccomodationPackagesService.GetAllAccomodationPackage();
            int totalItems = 0; //_AccomodationService.TotalItemCount(searchTearm, accomodationPackageId);
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
                //_Accomodation = _AccomodationService.GetAccomodationById(id.Value);
                //model.ID = _Accomodation.ID;
                //model.Name = _Accomodation.Name;
                //model.AccomodationPackageID = _Accomodation.AccomodationPackageID;
                //model.Description = _Accomodation.Description;
            }
            //model.AccomodationPackage = _AccomodationPackagesService.GetAllAccomodationPackage();

            return PartialView("_Action", model);
        }
        [HttpPost]
        public JsonResult Action(AccomodationModel model)
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
                        //_Accomodation.Name = model.Name;
                        //_Accomodation.Description = model.Description;
                        //_Accomodation.AccomodationPackageID = model.AccomodationPackageID;
                        //data = _AccomodationService.UpdateAccomodation(_Accomodation);
                    }
                    else
                    {
                        //_Accomodation.ID = model.ID;
                        //_Accomodation.Name = model.Name;
                        //_Accomodation.Description = model.Description;
                        //_Accomodation.AccomodationPackageID = model.AccomodationPackageID;
                        //data = _AccomodationService.SaveAccomodation(_Accomodation);
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
                    //_Accomodation = _AccomodationService.GetAccomodationById(id);
                    //data = _AccomodationService.DeleteAccomodation(_Accomodation);
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