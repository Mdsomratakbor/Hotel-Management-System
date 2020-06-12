using HMS.Entities;
using HMS.Services;
using HMS.Web.Areas.Dashboard.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HMS.Web.Areas.Dashboard.Controllers
{
    public class UsersController : Controller
    {
        private HMSSignInManagerService _signInManager;
        private HMSUserManagerService _userManager;
        private HMSRolesManagerService _roleManager;

        public UsersController()
        {
        }

        public UsersController(HMSUserManagerService userManager, HMSSignInManagerService signInManager, HMSRolesManagerService roleManager)
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
        public PartialViewResult Listing(string searchTearm, string roleID, int? pageNo, int? pageSize)
        {
            UserListingModel model = new UserListingModel();
            pageNo = pageNo ?? 1;
            pageSize = pageSize ?? 10;
            model.Users = SearchUsers(searchTearm, roleID, pageNo, pageSize.Value);
            model.Roles = RoleManager.Roles;
            model.RoleID = roleID;
            int totalItems = SearchUsersCount(searchTearm, roleID);
            model.Pager = new Pager(totalItems, pageNo, pageSize.Value);
            model.SearchTerm = searchTearm;
            model.PageNo = pageNo.Value;
            model.PageSize = pageSize.Value;
            return PartialView("_Listing", model);
        }
        [HttpGet]
        public async Task<PartialViewResult> Action(string id)
        {
            UserModel model = new UserModel();
            if (!string.IsNullOrEmpty(id))
            {
                var user = await UserManager.FindByIdAsync(id);
                model.ID = user.Id;
                model.FullName = user.FullName;
                model.Email = user.Email;
                model.UserName = user.UserName;
                model.Address = user.Address;
                model.Country = user.Country;
                model.City = user.City;               

            }
            return PartialView("_Action", model);
        }
        [HttpPost]
        public async Task<JsonResult> Action(UserModel model)
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
                        var user = await UserManager.FindByIdAsync(model.ID);
                        user.FullName = model.FullName;
                        user.Email = model.Email;
                        user.UserName = model.UserName;
                        user.Address = model.Address;
                        user.Country = model.Country;
                        user.City = model.City;
                        data = await UserManager.UpdateAsync(user);
                    }
                    else
                    {
                        var user = new HMSUser();
                        user.FullName = model.FullName;
                        user.Email = model.Email;
                        user.UserName = model.UserName;
                        user.Address = model.Address;
                        user.Country = model.Country;
                        user.City = model.City;
                        data = await UserManager.CreateAsync(user, model.Password);

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
                message = "Data Save Successfully!!";
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
                message = "Data Delete Successfully!!";
                result.Data = new { Success = true, Message = message };
            }
            else
            {
                result.Data = new { Success = false, Message = string.Join(",", data.Errors) };
            }

            return result;
        }

        [HttpGet]
        public async Task<PartialViewResult> UserRoles(string id)
        {

            UserRolesModel model = new UserRolesModel();
            if (!string.IsNullOrEmpty(id))
            {
                var users = await UserManager.FindByIdAsync(id);

                model.UserID = id;
                var userRolesIDs = users.Roles.Select(x => x.RoleId).ToList();
                model.UserRoles = RoleManager.Roles.Where(x => userRolesIDs.Contains(x.Id)).ToList();
                model.Roles = RoleManager.Roles.Where(x => !userRolesIDs.Contains(x.Id));
            }
            return PartialView("_UserRoles", model);
        }
   
        [HttpPost]
        public async Task<JsonResult> UserRoleOperation( string userId, string roleId, bool isDelete = false)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var message = "";
            IdentityResult data = null;
            try
            {
                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(roleId))
                {
                    var user = await UserManager.FindByIdAsync(userId);
                    var role = await RoleManager.FindByIdAsync(roleId); 
                    if (user != null && role != null)
                    {
                        if (!isDelete)
                            data = await UserManager.AddToRoleAsync(userId, role.Name);
                        else if (isDelete)
                            data = await UserManager.RemoveFromRoleAsync(userId, role.Name);
                        else
                            message = "Invalid operation";
                    }
                    else
                    {
                        message = "Please enter valid data !!";
                    }
                }
                else
                {
                    message = "Please enter valid data !!";

                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            if (data.Succeeded)
            {
                if (!isDelete) message = "Data Save Successfully!!";
                else message = "User Role Remove Successfully!!";

                result.Data = new { Success = true, Message = message };
            }
            else
            {
                result.Data = new { Success = false, Message = string.Join(",", data.Errors) };
            }
            return result;

        }


        public List<HMSUser> SearchUsers(string searchTearm, string roleId, int? pageNo, int pageSize)
        {
            var users = UserManager.Users.AsQueryable();
            if (string.IsNullOrEmpty(searchTearm) == false)
            {
                users = users.Where(x => x.Email.ToLower().Contains(searchTearm.ToLower())|| x.FullName.ToLower().Contains(searchTearm.ToLower()) || x.UserName.ToLower().Contains(searchTearm.ToLower()) || x.Country.ToLower().Contains(searchTearm.ToLower())|| x.City.ToLower().Contains(searchTearm.ToLower()));
            }
            if (!string.IsNullOrEmpty(roleId))
            {
                users = users.Where(x => x.Roles.Select(y=>y.RoleId).Contains(roleId));
            }
            return users.OrderByDescending(x => x.Email).Skip((pageNo.Value - 1) * pageSize).Take(pageSize).ToList();
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