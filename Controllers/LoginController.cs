﻿using Project2BurgerMenu.Context;
using Project2BurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;




namespace Project2BurgerMenu.Controllers
{
    public class LoginController : Controller
    {
        BurgerMenuContext context = new BurgerMenuContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x=> x.UserName==admin.UserName && x.Password==admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["x"]=values.UserName.ToString();
                return RedirectToAction("Index", "Dashboard", new {area="Admin"} );
            }
            else
            {
                return View(admin);
            }    
        }
		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();//Oturumu kapatma metodu
			
			return RedirectToAction("Index", "Login");
		}
	}
}