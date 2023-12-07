using System;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace ShopTARge22.Models.Accounts
{
	public class ChangePasswordViewModel
	{
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "The password does not match")]
        public string ConfirmPassword { get; set; }
    }
}

