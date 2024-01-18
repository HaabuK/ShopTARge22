using System;
using System.ComponentModel.DataAnnotations;
using ShopTARge22.Utilities;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace ShopTARge22.Models.Accounts
{
	public class ResetPasswordViewModel
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password does not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Delete Password")]
        public bool DeletePassword { get; set; }

        public string Token { get; set; }
    }
}

