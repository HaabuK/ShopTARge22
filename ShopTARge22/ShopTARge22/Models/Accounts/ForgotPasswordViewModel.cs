using System;
using System.ComponentModel.DataAnnotations;

namespace ShopTARge22.Models.Accounts
{
	public class ForgotPasswordViewModel
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

