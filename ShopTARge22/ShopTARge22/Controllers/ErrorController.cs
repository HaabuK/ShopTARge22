using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ShopTARge22.Controllers
{
	public class ErrorController : Controller
	{
		private readonly ILogger<ErrorController> _logger;

		public ErrorController(ILogger<ErrorController> logger)
		{
			_logger = logger;
		}

		public IActionResult HttpStatusCodeHandler(int statusCode)
		{
			var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

			switch (statusCode)
			{
				case 404:
					ViewBag.ErrorMessage = "Requested resource not found";
					_logger.LogWarning($"404 Error occurred. Path = {statusCodeResult.OriginalPath}, QueryString = {statusCodeResult.OriginalQueryString}");
					break;
			}
			return View("NotFound");
		}
		[Route("Error")]
		[AllowAnonymous]
		public IActionResult Error()
		{
			var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();
			_logger.LogError($"The path {exceptionDetails.Path} threw an exception {exceptionDetails.Error}");
			return View("Error");
		}
	}
}

