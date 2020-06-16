using HMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS.Web.Areas.Dashboard.ViewModels
{
    public class AccomodationListingModel : Pagination
    {
        public List<Accomodation> Accomodations { get; set; }
        public List<AccomodationPackage> AccomodatioPackages { get; set; }
    
    }
    public class AccomodationModel : BaseClass
    {

        public string PictureIDs { get; set; }
        [Required(ErrorMessage ="Please Provide Accomodation Package")]
        public int AccomodationPackageID { get; set; }
        public List<AccomodationPackage> AccomodationPackage { get; set; }
        public string Description { get; set; }
        public List<AccomodationPictures> AccomodationPictures { get; set; }
    }
}