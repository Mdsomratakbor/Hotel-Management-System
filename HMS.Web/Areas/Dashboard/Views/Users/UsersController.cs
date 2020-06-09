using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Web.Areas.Dashboard.Controllers
{
    public class UsersController : Controller
    {
        // GET: Dashboard/Users
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listing()
        {
            return View();
        }
        public ActionResult Action()
        {
            return View();
        }
    }
}