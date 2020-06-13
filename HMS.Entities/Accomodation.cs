using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    public  class Accomodation : BaseEntities
    {
        public int AccomodationPackageID { get; set; }
        public AccomodationPackage AccomodationPackage { get; set; }
        public string Description { get; set; }
        public List<AccomodationPictures> AccomodationPictures { get; set; }
    }
}
