using System;
using System.ComponentModel.DataAnnotations;

namespace ShopTARge22.Models.Accounts
{
	public class AddPasswordViewModel
	{
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

