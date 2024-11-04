using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2BurgerMenu.Entities;
using Project2BurgerMenu.Context;

namespace Project2BurgerMenu.Areas.Admin.Controllers
{
    public class StatisticsController : Controller
    {
        BurgerMenuContext context=new BurgerMenuContext();
        public ActionResult Index()
        {
			ViewBag.categories = context.Categories.Count();//Kategori sayısı
			ViewBag.burger = context.Products.Where(x => x.CategoryId == 1).Count() +" " + "çeşit";//Burger SAyısı
			ViewBag.products = context.Products.Count();//Ürün sayısı
			ViewBag.avgPrice = context.Products.Select(x => x.Price).Average() +" " + "₺";//ürünlerin fiyatının ortalaması
			ViewBag.maxPrice = context.Products.Select(x => x.Price).Max() +" " + "₺";//En pahalı ürün
			ViewBag.minPrice = context.Products.Select(x => x.Price).Min() +" " + "₺";//En ucuz ürün
			ViewBag.reservations = context.Reservations.Count();//Rezervasyon sayısı
			ViewBag.canceledReservations = context.Reservations.Where(x => x.ReservationStatus == "Rezervasyon İptal Edildi..").Count();//İptal edilen rezervasyonlar
			ViewBag.acceptedReservations = context.Reservations.Where(x => x.ReservationStatus == "Rezervasyon Onaylandı..").Count();//Onaylanan Rezervasyon
			ViewBag.waitReservations = context.Reservations.Where(x => x.ReservationStatus == "Rezervasyon Onay Bekleniyor..").Count();//Onay bekleyen Rezervasyon
			ViewBag.admins = context.Admins.Count();//Admin Sayısı
			ViewBag.subscribes = context.Subscribes.Count();//Abone Sayısı
			return View();
			
        }
    }
}