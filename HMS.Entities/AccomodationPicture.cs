using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
   public class AccomodationPictures
    {
        [Key]
        public int ID { get; set; }

        public int AccomodationID { get; set; }
        [ForeignKey("Picture")]
        public int PictuerID { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
