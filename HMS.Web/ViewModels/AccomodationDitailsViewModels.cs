using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Web.ViewModels
{
    public class AccomodationDitailsViewModel
    {
        public AccomodationType AccomodationType { get; set; }
        public List<AccomodationPackage> AccomodationPackages { get; set; }
        public List<Accomodation> Accomodations { get; set; }
    }
}