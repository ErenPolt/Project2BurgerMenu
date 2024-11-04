using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2BurgerMenu.Context;
using Project2BurgerMenu.Entities;

namespace Project2BurgerMenu.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        BurgerMenuContext context = new BurgerMenuContext();
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Index(Contact contact)
		{
			contact.SendDate = DateTime.Now;
			contact.IsRead = false;
			context.Contacts.Add(contact);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		//---------------------------------------------------
		public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        //--------------------------------------------------
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        //-------------------------------------------------------
        public PartialViewResult PartialAbout()//Hakkmızda
        {
			var values = context.Abouts.ToList();
			return PartialView(values);
		}
        //-------------------------------------------------------
        public PartialViewResult PartialTodaysOffer() //öne çıkanlar
        {
            var values = context.Products.Where(x => x.DealofTheDay == true).ToList();
            return PartialView(values);
           
        }
        //--------------------------------------------------------
        public PartialViewResult PartialMenu()//Menü
        {
            var values = context.Products.ToList();
          return PartialView(values);
        }
        public PartialViewResult PartialCategory()//Partial içinde Partial kategori tablosunu listeliyoruz..
        {
            var values = context.Categories.Take(6).ToList();
            return PartialView(values);
        }
        //--------------------------------------------------------
        public PartialViewResult PartialGallery()//Galeri
        {
            return PartialView();
        }
        //--------------------------------------------------------
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        //---------------------------------------------------------
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        //----------------------------------------------------------
        [HttpGet]
        public PartialViewResult PartialReservation()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialReservation(Reservation reservation)//Rezervasyon Ekleme
        {
            reservation.ReservationStatus = "Onay Bekleniyor";
            reservation.PeopleCount = 0;
            reservation.ReservationDate= DateTime.Now;
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return PartialView();
        }
        //------------------------------------------------------------------------------
        
    }
} 