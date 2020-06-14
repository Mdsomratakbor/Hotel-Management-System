using HMS.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS.Web.Areas.Dashboard.ViewModels
{
    public class UserListingModel :Pagination
    {
        public IEnumerable<HMSUser> Users { get; set; }
        public string RoleID { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }

    }
    public class UserModel
    {
        public string ID { get; set; }
        [Required(ErrorMessage = "Please Enter Full Name")]      
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please Enter valid Email")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
  
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class UserRolesModel
    {
        public string UserID { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public IEnumerable<IdentityRole> UserRoles { get; set; }
    }
}