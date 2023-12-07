using System;
using Microsoft.AspNetCore.Identity;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto.AccountsDtos;
using ShopTARge22.Core.ServiceInterface;

namespace ShopTARge22.ApplicationServices.Services
{
	public class AccountServices : IAccountServices
    {
		private readonly UserManager<ApplicationUser> _userManager;

		public AccountServices( UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<ApplicationUser> Register(ApplicationUserDto dto)
		{
			var user = new ApplicationUser()
			{
				UserName = dto.Email,
				Email = dto.Email,
				City = dto.City
			};

			var result = await _userManager.CreateAsync(user, dto.Password);

			if (result.Succeeded)
			{
				var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

				//var confirmationLink = Url.Action
			}

			return user;
		}

		public async Task<ApplicationUser> ConfirmEmail(string userId, string token)
		{
			var user = await _userManager.FindByIdAsync(userId);

			if (user == null)
			{
				string errorMessage = $"The user Id {userId} is not valid";
			}
			var result = await _userManager.ConfirmEmailAsync(user, token);

			return user;
		}
	}
}

