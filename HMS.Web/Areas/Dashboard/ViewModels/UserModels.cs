using HMS.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Web.Areas.Dashboard.ViewModels
{
    public class UserListingModel
    {
        public IEnumerable<HMSUser> Users { get; set; }
        public string RoleID { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public string SearchTerm { get; set; }
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public Pager Pager { get; set; }

    }
    public class UserModel
    {
        public int ID { get; set; }
        public string RoleID { get; set; }
        public IdentityRole Role { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public string Name { get; set; }

    }
}