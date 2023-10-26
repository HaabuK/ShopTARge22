using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Core.Dto.WeatherDtos;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Models.Forecast;

namespace ShopTARge22.Controllers
{
    public class WeatherForecastsController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public WeatherForecastsController
            (
            IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }


        [HttpGet]
        public IActionResult Index()
        {
            //SearchCityViewModel model = new();

            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecasts", new { city = model.CityName });
            }

            return View(model);
        }

        public IActionResult City(string city)
        {

            OpenWeatherResultDto dto = new();
            dto.City = city;
            _weatherForecastServices.OpenWeatherResult(dto);
            OpenWeatherViewModel vm = new();

            vm.City = dto.City;
            vm.Temp = dto.Temp;
            vm.FeelsLike = dto.FeelsLike;
            vm.Humidity = dto.Humidity;
            vm.Pressure = dto.Pressure;
            vm.WindSpeed = dto.WindSpeed;
            vm.Description = dto.Description;
            vm.Country = dto.Country;

            return View(vm);
        }
    }
}
