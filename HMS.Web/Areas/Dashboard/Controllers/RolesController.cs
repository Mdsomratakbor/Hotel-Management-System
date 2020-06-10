using HMS.Entities;
using HMS.Services;
using HMS.Web.Areas.Dashboard.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HMS.Web.Areas.Dashboard.Controllers
{
    public class RolesController : Controller
    {
        private HMSSignInManagerService _signInManager;
        private HMSUserManagerService _userManager;
        private HMSRolesManagerService _roleManager;

        public RolesController()
        {
        }

        public RolesController(HMSUserManagerService userManager, HMSSignInManagerService signInManager, HMSRolesManagerService roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
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
        public HMSRolesManagerService RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().GetUserManager<HMSRolesManagerService>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        // GET: Dashboard/Users
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Listing(string searchTearm, int? pageNo, int? pageSize)
        {
            RolesListingModel model = new RolesListingModel();
            pageNo = pageNo ?? 1;
            pageSize = pageSize ?? 10;
            model.Roles = SearchRoles(searchTearm,  pageNo, pageSize.Value);
            int totalItems = SearchRolesCount(searchTearm);
            model.Pager = new Pager(totalItems, pageNo, pageSize.Value);
            model.SearchTerm = searchTearm;
            model.PageNo = pageNo.Value;
            model.PageSize = pageSize.Value;
            return PartialView("_Listing", model);
        }
        [HttpGet]
        public async Task<PartialViewResult> Action(string id)
        {
            RolesModel model = new RolesModel();
            if (!string.IsNullOrEmpty(id))
            {
                //var user = await UserManager.FindByIdAsync(id);
                //model.ID = user.Id;
                //model.FullName = user.FullName;
                //model.Email = user.Email;
                //model.UserName = user.UserName;
                //model.Address = user.Address;
                //model.Country = user.Country;
                //model.City = user.City;

            }
            return PartialView("_Action", model);
        }
        [HttpPost]
        public async Task<JsonResult> Action(RolesModel model)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var message = "";
            IdentityResult data = null;
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(model.ID))
                    {
                        //var user = await UserManager.FindByIdAsync(model.ID);
                        //user.FullName = model.FullName;
                        //user.Email = model.Email;
                        //user.UserName = model.UserName;
                        //user.Address = model.Address;
                        //user.Country = model.Country;
                        //user.City = model.City;
                        //data = await UserManager.UpdateAsync(user);
                    }
                    else
                    {
                        //var user = new HMSUser();
                        //user.FullName = model.FullName;
                        //user.Email = model.Email;
                        //user.UserName = model.UserName;
                        //user.Address = model.Address;
                        //user.Country = model.Country;
                        //user.City = model.City;
                        //data = await UserManager.CreateAsync(user);
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
            if (data.Succeeded)
            {
                message = "users Save Successfully!!";
                result.Data = new { Success = true, Message = message };
            }
            else
            {
                result.Data = new { Success = false, Message = string.Join(",", data.Errors) };
            }
            return result;

        }

        public async Task<JsonResult> Delete(string id)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            dynamic message = "";
            IdentityResult data = null;
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var user = await UserManager.FindByIdAsync(id);
                    data = await UserManager.DeleteAsync(user);
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
            if (data.Succeeded)
            {
                message = "User Delete Successfully!!";
                result.Data = new { Success = true, Message = message };
            }
            else
            {
                result.Data = new { Success = false, Message = string.Join(",", data.Errors) };
            }

            return result;
        }


        public IEnumerable<IdentityRole> SearchRoles(string searchTearm,  int? pageNo, int pageSize)
        {
            var roles = RoleManager.Roles.AsQueryable();
            if (string.IsNullOrEmpty(searchTearm) == false)
            {
                roles = roles.Where(x => x.Name.ToLower().Contains(searchTearm.ToLower()));
            }
            return roles.OrderByDescending(x => x.Name).Skip((pageNo.Value - 1) * pageSize).Take(pageSize);
        }
        public int SearchRolesCount(string searchTearm)
        {
            var roles = RoleManager.Roles.AsQueryable();
            if (string.IsNullOrEmpty(searchTearm) == false)
            {
                roles = roles.Where(x => x.Name.ToLower().Contains(searchTearm.ToLower()));
            }
            return roles.Count();
        }
    }
}