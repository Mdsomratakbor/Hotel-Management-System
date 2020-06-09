using HMS.Entities;
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
        public PartialViewResult Listing(string searchTearm, string roleID, int? pageNo, int? pageSize)
        {
            UserListingModel model = new UserListingModel();
            pageNo = pageNo ?? 1;
            pageSize = pageSize ?? 10;
            model.Users = SearchUsers(searchTearm, roleID, pageNo, pageSize.Value);
            model.RoleID = roleID;            
            int totalItems = SearchUsersCount(searchTearm,roleID);
            model.Pager = new Pager(totalItems, pageNo, pageSize.Value);
            model.SearchTerm = searchTearm;
            model.PageNo = pageNo.Value;
            model.PageSize = pageSize.Value;
            return PartialView("_Listing", model);
        }
        [HttpGet]
        public PartialViewResult Action(string id)
        {
            UserModel model = new UserModel();
            if (string.IsNullOrEmpty(id))
            {
                //_Accomodation = _AccomodationService.GetAccomodationById(id.Value);
                //model.ID = _Accomodation.ID;
                //model.Name = _Accomodation.Name;
                //model.AccomodationPackageID = _Accomodation.AccomodationPackageID;
                //model.Description = _Accomodation.Description;
            }
           // model.Roles = _AccomodationPackagesService.GetAllAccomodationPackage();

            return PartialView("_Action", model);
        }
        [HttpPost]
        public JsonResult Action(AccomodationModel model)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var message = "";
            bool users = false;
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
                        //users = _AccomodationService.UpdateAccomodation(_Accomodation);
                    }
                    else
                    {
                        //_Accomodation.ID = model.ID;
                        //_Accomodation.Name = model.Name;
                        //_Accomodation.Description = model.Description;
                        //_Accomodation.AccomodationPackageID = model.AccomodationPackageID;
                        //users = _AccomodationService.SaveAccomodation(_Accomodation);
                    }

                }
                else
                {
                    message = "Please enter valid users!!";

                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            if (users)
            {
                message = "users Save Successfully!!";
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
            var users = false;
            try
            {
                if (id > 0)
                {
                    //_Accomodation = _AccomodationService.GetAccomodationById(id);
                    //users = _AccomodationService.DeleteAccomodation(_Accomodation);
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
            if (users)
            {
                message = "users Delete Successfully !!";
                result.Data = new { Success = true, Message = message };
            }
            else
            {
                result.Data = new { Success = false, Message = message };
            }

            return result;
        }


        public IEnumerable<HMSUser> SearchUsers(string searchTearm, string roleId, int? pageNo, int pageSize)
        {
            var users = UserManager.Users.AsQueryable();
            if (string.IsNullOrEmpty(searchTearm) == false)
            {
                users = users.Where(x => x.Email.ToLower().Contains(searchTearm.ToLower()));
            }
            if (string.IsNullOrEmpty(roleId))
            {
                //users = users.Where(x => x.AccomodationPackageID == accomodationPackageId).ToList();
            }
            return users.OrderByDescending(x => x.Email).Skip((pageNo.Value - 1) * pageSize).Take(pageSize);
        }
        public int SearchUsersCount(string searchTearm, string roleId)
        {
            var data = UserManager.Users;
            if (string.IsNullOrEmpty(searchTearm) == false)
            {
                data = data.Where(x => x.Email.ToLower().Contains(searchTearm.ToLower()));
            }
            {
               // data = data.Where(x => x.AccomodationPackageID == accomodationPackageId).ToList();
            }
            return data.Count();
        }
    }
}