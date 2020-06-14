using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS.Web.Areas.Dashboard.ViewModels
{
    public class RolesListingModel:Pagination
    {
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
    public class RolesModel
    {
        public string ID { get; set; }
        [Required(ErrorMessage ="Please provide role name")]
        public string Name { get; set; }
    }

}