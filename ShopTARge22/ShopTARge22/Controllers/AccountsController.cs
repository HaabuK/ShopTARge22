using System;
using Microsoft.AspNetCore.Mvc;

namespace ShopTARge22.Controllers
{
	public class AccountsController : Controller
	{
		public IActionResult Register()
		{
			return View();
		}
	}
}

