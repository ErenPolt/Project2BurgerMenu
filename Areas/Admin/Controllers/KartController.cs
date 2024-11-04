using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2BurgerMenu.Areas.Admin.Controllers
{
    public class KartController : Controller
    {
        // GET: Admin/Kart
        public ActionResult Index()
        {
            return View();
        }
    }
}