using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Web.ViewModels
{
    public class HomeViewModel
    {
        public List<AccomodationType> AccomodationTypes { get; set; }
        public List<AccomodationPackage> AccomodtionPackages { get; set; }
    }
}