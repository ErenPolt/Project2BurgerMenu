using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2BurgerMenu.Context;
using Project2BurgerMenu.Entities;
using PagedList;
using PagedList.Mvc;

namespace Project2BurgerMenu.Areas.Admin.Controllers
{
    [Authorize]//401 hatası vermeyi sağlar
    public class ProductController : Controller
    {
        BurgerMenuContext context=new BurgerMenuContext();
        public ActionResult ProductList(int page = 1)//Product Listeleme       
        {
            var values = context.Products.ToList().ToPagedList(page,4 );
            return View(values);
        }
        //--------------------------------------------------------------------
        //Product Veri Ekleme:

        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryId.ToString()

                                          }).ToList();
            ViewBag.V=values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        //-----------------------------------------------------------------------------
        //Product Veri Silme:
        public ActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        //--------------------------------------------------------------------------
        //Product Veri Güncelleme:

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()

                                           }).ToList();
            ViewBag.V = values;

            var value = context.Products.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var value = context.Products.Find(product.ProductId);
            value.ProductName = product.ProductName;
            value.ImageUrl=product.ImageUrl;
            value.Description = product.Description;
            value.Price = product.Price;
            value.CategoryId = product.CategoryId;
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }
		//------------------------------------------------------------------------------------------
		//Kategroi Ürünleri Tablosunda; Kategorisine göre Ürünleri Listeleme İşlemi:
		public ActionResult KategoriUrunleri(int id)
		{
			var values = context.Products.Where(x => x.CategoryId == id).ToList();
			return View(values);
		}
		//------------------------------------------------------------------------------------------------
		public ActionResult DealofTheDayChangeToTrue(int id)
		{
			var value = context.Products.Where(x => x.ProductId == id).FirstOrDefault();
			value.DealofTheDay = true;
			context.SaveChanges();
			return RedirectToAction("ProductList");
		}

		public ActionResult DealofTheDayChangeToFalse(int id)
		{
			var value = context.Products.Where(x => x.ProductId == id).FirstOrDefault();
			value.DealofTheDay = false;
			context.SaveChanges();
			return RedirectToAction("ProductList");
		}
	}
}