using System;
using System.ComponentModel.DataAnnotations;
using ShopTARge22.Utilities;
using Xunit.Sdk;

namespace ShopTARge22.Models.Accounts
{
	public class RegisterViewModel
	{
        [Required]
        [EmailAddress]
        //[ValidEmailDomain(allowedDomain: ".com", ErrorMessage = "Email must end with .com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password does not match")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }
    }
}

