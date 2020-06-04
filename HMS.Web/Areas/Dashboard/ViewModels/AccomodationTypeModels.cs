﻿using HMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS.Web.Areas.Dashboard.ViewModels
{
    public class AccomodationTypeListingModel
    {
        public List<AccomodationType> AccomodationTypes { get; set; }
    }
    public class AccomodationTypeModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}