using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS.Web.Areas.Dashboard.ViewModels
{
    public class BaseClass
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please provide  Name")]
        public string Name { get; set; }
    }
}