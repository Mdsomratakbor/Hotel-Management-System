using HMS.Entities;
using System;
using System.Collections.Generic;
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
        public int AccomodationTypeID { get; set; }
        public List<AccomodationType> AccomodationType { get; set; }
        public string NoOfRoom { get; set; }
        public decimal FeePerNight { get; set; }
    }
}