using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2BurgerMenu.Context;
using Project2BurgerMenu.Entities;

namespace Project2BurgerMenu.Areas.Admin.Controllers
{
    public class ProfileController : Controller
    {
        BurgerMenuContext context=new BurgerMenuContext();
        [Authorize]
        public ActionResult MyProfileList()
        {
            var userName = Session["x"]; 
            var values=context.Admins.Where(x=>x.UserName == userName).FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public ActionResult MyProfileList(Project2BurgerMenu.Entities.Admin admin)
        {
            var userName = Session["x"];
            var values = context.Admins.Where(x => x.UserName == userName).FirstOrDefault();
            values.UserName = admin.UserName;
            values.Surname= admin.Surname;
            values.Name= admin.Name;
            values.Password= admin.Password;
            values.Email= admin.Email;
            context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}