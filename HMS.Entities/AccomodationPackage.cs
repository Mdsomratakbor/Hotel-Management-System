using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    public  class AccomodationPackage:BaseEntities
    {
        public int AccomodationTypeID { get; set; }
        public AccomodationType AccomodationType { get; set; }
        public string NoOfRoom { get; set; }
        public decimal FeePerNight { get; set; } 
    }
}
