using HMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS.Web.Areas.Dashboard.ViewModels
{
    public class AccomodationPackagesListingModel
    {
        public List<AccomodationPackage> AccomodationPackages { get; set; }
        public string SearchTerm { get; set; }
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public Pager Pager { get; set; }
    }
    public class AccomodationPackagesModel
    {
        public int ID { get; set; }
        [Required (ErrorMessage ="Please provide Accomodation Package Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide Accomodation Type")]
        public int AccomodationTypeID { get; set; }
        public List<AccomodationType> AccomodationType { get; set; }
        [Required(ErrorMessage = "Please provide no of room in this package")]
        public string NoOfRoom { get; set; }
        [Required(ErrorMessage = "Please provide Fee Per Night in this package")]
        public decimal FeePerNight { get; set; }
    }
}