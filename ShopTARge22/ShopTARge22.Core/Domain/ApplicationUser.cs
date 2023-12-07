using System;
using Microsoft.AspNetCore.Identity;

namespace ShopTARge22.Core.Domain
{
	public class ApplicationUser : IdentityUser
	{
		public string City { get; set; }
	}
}

