using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2BurgerMenu.Entities;
using Project2BurgerMenu.Context;

namespace Project2BurgerMenu.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        BurgerMenuContext context=new BurgerMenuContext();
        public ActionResult Index()//About tablosunu listeleme işlemi
        {
            var values=context.Abouts.ToList();
            return View(values);
        }
		//------------------------------------------------------------------------
		//About tablosu veri silme:
		public ActionResult DeleteAbout(int id)
		{
			var values = context.Abouts.Find(id);
			context.Abouts.Remove(values);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		//------------------------------------------------------------------------------------
		//About Tablosu Veri Ekleme:
		[HttpGet]
		public ActionResult CreateAbout()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateAbout(About about)
		{
			context.Abouts.Add(about);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		//--------------------------------------------------------------------------------
		//About Tablosu Veri Güncelleme:
		[HttpGet]
		public ActionResult UpdateAbout(int id)
		{
			var values = context.Abouts.Find(id);
			return View(values);
		}

		[HttpPost]
		public ActionResult UpdateAbout(About about)
		{
			var values = context.Abouts.Find(about.AboutID);
			values.Subtitle = about.Subtitle;
			values.Title = about.Title;
			values.Description = about.Description;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		//-------------------------------------------------------------------------------------
	}
}