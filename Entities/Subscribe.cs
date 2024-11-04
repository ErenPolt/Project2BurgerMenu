using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project2BurgerMenu.Entities
{
	public class Subscribe
	{
		public int SubscribeID { get; set; }

		[Required(ErrorMessage = "Email Giriniz")]//Reguired sayesinde email boş geçilemez..
		[EmailAddress(ErrorMessage = "Geçersiz Email Formatı")]//Email formatını komtrol eder.
		public string SubscribeEmail { get; set; }
	}
}