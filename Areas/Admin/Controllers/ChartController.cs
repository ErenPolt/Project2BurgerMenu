using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2BurgerMenu.Entities;
using Project2BurgerMenu.Context;
using Microsoft.Ajax.Utilities;
using System.Web.WebPages;

namespace Project2BurgerMenu.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        BurgerMenuContext context = new BurgerMenuContext();
        public ActionResult ProductChart()//Ana Grafik
        {
			return View();
		}
		//----------------------------------------------------------
		public ActionResult CategoryProductChart()// Kategori ve ürün sayısı ilişkisi
		{
			
			var data = context.Categories
				.Where(c => c.Products.Count > 0)
				.Select(c => new
				{
					CategoryName = c.CategoryName,
					ProductCount = c.Products.Count
				})
				.ToList();
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public ActionResult CategoryProductChartt()// BUrgerler
		{

			var data = context.Products
				.Where(c => c.CategoryId == 1 )
				.Select(c => new
				{
					ProductName = c.ProductName,
					ProductCount = c.CategoryId
				})
				.ToList();
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		//-------------------------------------------------------------------------------------------------------------------------------
		public ActionResult DealofTheDaysChart()//Fırsat Menüsü
		{
			return View();
		}

		public ActionResult DealofTheDaysCategory()
		{
			var data = context.Products
				.Where(c => c.DealofTheDay == true).GroupBy(c => c.Category.CategoryName)
				.Select(g => new
				{
					DealName = g.Key,
					DealCategory = g.Count()
				})
				.ToList();

			return Json(data, JsonRequestBehavior.AllowGet);
		}
		//-------------------------------------------------------------------------------------------------------------------
		public ActionResult ReservationDateChart()//Rezervasyon
		{
			return View();
		}

		public ActionResult ReservationChart()
		{
			var data = context.Reservations
	   .GroupBy(c => c.Time) // Yalnızca saat kısmını al
	   .Select(g => new
	   {
		   // Tarih kısmını gün/ay/yıl formatında döndür
		   ReservationDate = g.Key,
		   ReservationCount = g.Count()
	   })
	   .ToList();

			return Json(data, JsonRequestBehavior.AllowGet);
		}

	}
}