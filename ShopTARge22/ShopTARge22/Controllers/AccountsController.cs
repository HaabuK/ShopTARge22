using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.Domain;
using ShopTARge22.Data;
using ShopTARge22.Models.Accounts;

namespace ShopTARge22.Controllers
{
	public class AccountsController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ShopTARge22Context _context;


        public AccountsController
			(
            ShopTARge22Context context,
            UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager
			)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
			
		}

		[HttpGet]
		public async Task<IActionResult> ChangePassword()
		{
            var user = await _userManager.GetUserAsync(User);
            var userHasPassword = await _userManager.HasPasswordAsync(user);

            if (userHasPassword)
            {
                return View("ChangePassword");
            }
            else
            {
                RedirectToAction("AddPassword");
                return View("AddPassword");
            }
        }

		[HttpPost]
		public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.GetUserAsync(User);

				if (user == null)
				{
					return RedirectToAction("Login");
				}

				var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

				if (!result.Succeeded)
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
					return View();
				}
				await _signInManager.RefreshSignInAsync(user);
				return View("ChangePasswordConfirmation");
			}
			return View(model);
		}

        [HttpGet]
        public async Task<IActionResult> AddPassword()
        {
            return View("AddPassword");
        }

        [HttpPost]
        public async Task<IActionResult> AddPassword(AddPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var result = await _userManager.AddPasswordAsync(user, model.NewPassword);

                if (result.Succeeded)
                {
                    return View("AddPasswordConfirmation");
                }
                else
                {
                    // Password addition failed, add errors to ModelState
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View("AddPassword", model); // Return the same view with errors
                }
            }
            return View("AddPassword", model);
        }


        [HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> ResetPassword()//string token, string email, string id
        {
            var user = await _userManager.GetUserAsync(User);
            var userHasPassword = await _userManager.HasPasswordAsync(user);

            if (userHasPassword)
            {
				var token = await _userManager.GeneratePasswordResetTokenAsync(user);

				if (token == null || user.Email == null)
				{
					ModelState.AddModelError("", "Invalid password reset token");
				}

				var model = new ResetPasswordViewModel
				{
					Token = token,
					Email = user.Email,
				};

				return View(model);
            }
            else
            {
                RedirectToAction("AddPassword");
                return View("AddPassword");
            }
        }

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (model.DeletePassword == false)
				{
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                        if (result.Succeeded)
                        {
                            if (await _userManager.IsLockedOutAsync(user))
                            {
                                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
                            }
                            await _signInManager.SignOutAsync();
                            return RedirectToAction(nameof(ResetPasswordConfirmation));
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(model);
                    }
                    //await _signInManager.SignOutAsync();
                    return View("ResetPasswordConfirmation");
                }
				else if (model.DeletePassword == false)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        var result = await _userManager.ResetPasswordAsync(user, model.Token, "NULL");
                        if (result.Succeeded)
                        {
                            if (await _userManager.IsLockedOutAsync(user))
                            {
                                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
                            }
                            await _signInManager.SignOutAsync();
                            return RedirectToAction(nameof(ResetPasswordConfirmation));
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(model);
                    }
                    //await _signInManager.SignOutAsync();
                    return View("ResetPasswordConfirmation");
                }

            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
		[AllowAnonymous]
		public IActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				if (user != null && await _userManager.IsEmailConfirmedAsync(user))
				{
					var token = await _userManager.GeneratePasswordResetTokenAsync(user);

					var passwordResetLink = Url.Action("ResetPassword", "Accounts", new {email = model.Email, token = token}, Request.Scheme);

					//_logger.Log(LogLevel.Warning, passwordResetLink);

					return View("ForgotPasswordConfirmation");
				}

                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser
				{
					UserName = model.Email,
					Email = model.Email,
					City = model.City
				};

				var result = await _userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

					var confirmationLink = Url.Action("ConfirmEmail", "Accounts", new { userId = user.Id, token = token }, Request.Scheme);

					//_logger.Log(LogLevel.Warning, confirmationLink);

					if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
					{
						return RedirectToAction("ListUsers", "Administrations");
					}

					ViewBag.ErrorTitle = "Registration successful";
					ViewBag.ErrorMessage = "Before you can login, please confirm your email address, " +
						"by clicking on the confirmation link sent to your entered email address";

					return View("Error");
				}

				foreach(var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View();
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> ConfirmEmail(string userId, string token)
		{
			if (userId == null || token == null)
			{
				return RedirectToAction("Index", "Home");
			}

			var user = await _userManager.FindByIdAsync(userId);

			if(user == null)
			{
				ViewBag.ErrorMessage = $"The User ID {userId} is not valid";
				return View("NotFound");
			}

			var result = await _userManager.ConfirmEmailAsync(user, token);

			if (result.Succeeded)
			{
				return View();
			}

			ViewBag.ErrorTitle = "Email cannot be confirmed";

			return View("Error");
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Login(string? returnUrl)
		{
			LoginViewModel vm = new()
			{
				ReturnUrl = returnUrl,
				ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
			};

			return View(vm);
		}

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null && !user.EmailConfirmed && (await _userManager.CheckPasswordAsync(user, model.Password)))
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

                // Log the result for debugging purposes
                if (!result.Succeeded)
                {
                    // Log or debug the result to identify the issue
                    Console.WriteLine($"Login failed. Result: {result}");
                }

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                if (result.IsLockedOut)
                {
                    return View("AccountLocked");
                }

                ModelState.AddModelError("", "Invalid Login attempt");
            }

            return View(model);
        }


        [HttpPost]
		[AllowAnonymous]
		public IActionResult ExternalLogin(string provider, string? returnUrl)
		{
            var redirectUrl = Url.Action("ExternalLoginCallback", "Accounts", new { returnUrl = returnUrl });

			var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

			return new ChallengeResult(provider, properties);
		}

		[AllowAnonymous]
		public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string remoteError = null)
		{
			returnUrl = returnUrl ?? Url.Content("~/");

			LoginViewModel loginViewModel = new()
			{
				ReturnUrl = returnUrl,
				ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
			};

			if (remoteError != null)
			{
				ModelState.AddModelError(string.Empty, $"Problem with external provider : {remoteError}");

				return View("Login", loginViewModel);
			}

			var info = await _signInManager.GetExternalLoginInfoAsync();
			if (info == null)
			{
				ModelState.AddModelError("", "Error loading external login information.");

				return View("Login", loginViewModel);
			}

			var email = info.Principal.FindFirstValue(ClaimTypes.Email);
			ApplicationUser user = null;

			if (email != null)
			{
				user = await _userManager.FindByEmailAsync(email);

				//if (user != null && !user.EmailConfirmed)
				//{
				//	ModelState.AddModelError("", "Email not confirmed yet");
				//	return View("Login", loginViewModel);
				//}
			}

			var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
																			isPersistent: false, bypassTwoFactor: true);

			if (signInResult.Succeeded)
			{
				return LocalRedirect(returnUrl);
			}
			else
			{
				if (email != null)
				{
					if (user == null)
					{
						user = new ApplicationUser
						{
							UserName = info.Principal.FindFirstValue(ClaimTypes.Email),

							Email = info.Principal.FindFirstValue(ClaimTypes.Email),

							City = "Unset",
						};

						await _userManager.CreateAsync(user);

						var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

						var confirmationLink = Url.Action("ConfirmEmail", "Accounts", new { userId = user.Id, token = token }, Request.Scheme);

						//logger.Log(LogLevel.Warning, confirmationLink);

						ViewBag.ErrorTitle = "Registration successful";
						ViewBag.ErrorMessage = "Before you can login, please verify your email address. Verification link has been sent to your email";

						return View("Error");
					}

					await _userManager.AddLoginAsync(user, info);
					await _signInManager.SignInAsync(user, isPersistent: false);

					return LocalRedirect(returnUrl);
				}

				ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
				ViewBag.ErrorMessage = "Please contact support at asd@asd.com";

				return View("Error");
			}
		}
	}
}

