using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2BurgerMenu.Entities;
using Project2BurgerMenu.Context;

namespace Project2BurgerMenu.Areas.Admin.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        BurgerMenuContext context=new BurgerMenuContext();
        public ActionResult InBox()//Aldığım mesaj
        {
            var userName = Session["x"];
            var email = context.Admins.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var values = context.Messages.Where(x => x.ReceiverEmail == email).ToList();
            return View(values);
        }
        public ActionResult SendBox()//Gönderdiğim mesaj
        {
            var userName = Session["x"];
            var email = context.Admins.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var values = context.Messages.Where(x => x.SenderMail == email).ToList();
            return View(values);
        }
		public PartialViewResult PartialDetailMessage(int id)
		{
			var values = context.Messages.Find(id);

			return PartialView(values);
		}
		public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var userName = Session["x"];
            var email = context.Admins.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            message.SenderMail=email;
            message.IsRead = false;
            message.SendDate= DateTime.Now;
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("SendBox","Message", new {area = "Admin"});
        }
		

	}
}