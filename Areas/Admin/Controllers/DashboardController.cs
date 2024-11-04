using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2BurgerMenu.Context;
using Project2BurgerMenu.Entities;

namespace Project2BurgerMenu.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        BurgerMenuContext context=new BurgerMenuContext();
        public ActionResult Index()
        {

			ViewBag.productNames = context.Products.Select(p => p.ProductName).ToList();
			ViewBag.productPrices = context.Products.Select(p => p.Price).ToList();
			ViewBag.productCategory = context.Products.Select(p => p.Category.CategoryName).ToList();
			Random random = new Random();
			List<int> progressValues = new List<int>();
			for (int i = 0; i < ViewBag.productNames.Count; i++)
			{
				int randomProgress = random.Next(0, 101);
				progressValues.Add(randomProgress);
			}
			ViewBag.productProgress = progressValues;
			return View();
        }
    }
}