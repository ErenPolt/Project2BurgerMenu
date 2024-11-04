using Project2BurgerMenu.Context;
using Project2BurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2BurgerMenu.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        BurgerMenuContext context=new BurgerMenuContext();
        public ActionResult CategoryList()//Kategorileri listeleme
        {
            var values = context.Categories.ToList();
            return View(values);
        }
        //-------------------------------------------------------------------------------------
        //////Yeni Kategori Ekleme:
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        //-----------------------------------------------------------------------------------------
        //Kategori Silme:
        public ActionResult DeleteCategory(int id)
        {
            var values = context.Categories.Find(id);
            context.Categories.Remove(values);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        //----------------------------------------------------------------------------------------
        //Kategori Güncelleme:
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = context.Categories.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var values=context.Categories.Find(category.CategoryId);
            values.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        //-------------------------------------------------------------------------------------------
    }
}