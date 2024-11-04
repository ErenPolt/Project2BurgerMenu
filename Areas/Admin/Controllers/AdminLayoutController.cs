using Project2BurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2BurgerMenu.Context;
using Newtonsoft.Json.Linq;


namespace Project2BurgerMenu.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
       BurgerMenuContext context=new BurgerMenuContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()//Üst Menü
        {
            return PartialView();
        }
        public PartialViewResult PartialSidebar()//Sol menü
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult PartialCategory()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return PartialView();
        }
    }
}