﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    public class AccomodationPackagePictures
    {
        public int ID { get; set; }
        public int AccomodationPackageID { get; set; }
        public int PictuerID { get; set; }
        public virtual Picture Picture { get; set; }

    }
}