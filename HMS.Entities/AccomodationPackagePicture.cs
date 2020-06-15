using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    public class AccomodationPackagePictures
    {
        [Key]
        public int ID { get; set; }

        public int AccomodationPackageID { get; set; }

        [ForeignKey("Picture")]
        public virtual int PictuerID { get; set; }       
        public virtual Picture Picture { get; set; }

    }
}
