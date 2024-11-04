using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2BurgerMenu.Entities;
using Project2BurgerMenu.Context;
using PagedList;
using PagedList.Mvc;

namespace Project2BurgerMenu.Areas.Admin.Controllers
{
    public class ReservationController : Controller
    {
        BurgerMenuContext context=new BurgerMenuContext();
        public ActionResult ReservationList(int page = 1)//Rezervasyon listeleme
        {
            var values = context.Reservations.ToList().ToPagedList(page, 5);
            return View(values);
        }
        //----------------------------------------------------------------------------------------------------------
        //Rezervasyon Tablosu Güncelleme:
        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var values = context.Reservations.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateReservation(Reservation reservation)
        {
            var values = context.Reservations.Find(reservation.ReservationId);
            values.Name = reservation.Name;
            values.Surname = reservation.Surname;
            values.Email = reservation.Email;
            values.Phone = reservation.Phone;
            values.PeopleCount = reservation.PeopleCount;
            values.ReservationDate = reservation.ReservationDate;
            values.Time = reservation.Time;
            values.Message = reservation.Message;
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
		//-------------------------------------------------------------------------------------------------------------------------
		//Rezervasyon durumunu "Onaylandı" olarak güncelleme:
		public ActionResult StatusChangeToConfirm(int id)
		{
			var value = context.Reservations.Where(x => x.ReservationId == id).FirstOrDefault();
			value.ReservationStatus = "Rezervasyon Onaylandı..";
			context.SaveChanges();
			return RedirectToAction("ReservationList");
		}
		//--------------------------------------------------------------------------------------------------------------------
		//Rezervasyon Durumu "Onay bekliyor" olarak güncelleme:
		public ActionResult StatusChangeToWait(int id)
		{
			var value = context.Reservations.Where(x => x.ReservationId == id).FirstOrDefault();
			value.ReservationStatus = "Rezervasyon Onay Bekleniyor..";
			context.SaveChanges();
			return RedirectToAction("ReservationList");
		}
		//--------------------------------------------------------------------------------------------------------------------
		//Rezervasyon Durumu "Rezervasyon İptal" olarak güncelleme:
		public ActionResult StatusChangeToCancel(int id)
		{
			var value = context.Reservations.Where(x => x.ReservationId == id).FirstOrDefault();
			value.ReservationStatus = "Rezervasyon İptal Edildi..";
			context.SaveChanges();
			return RedirectToAction("ReservationList");
		}
	}
}