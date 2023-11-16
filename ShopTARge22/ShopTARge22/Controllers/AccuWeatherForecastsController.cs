using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Models.AccuWeather;

namespace ShopTARge22.Controllers
{
    public class AccuWeatherForecastsController : Controller
    {
        private readonly IAccuWeatherForecastServices _AccuWeatherForecastServices;
        public AccuWeatherForecastsController(
            IAccuWeatherForecastServices AccuWeatherForecastServices
            )
        {
            _AccuWeatherForecastServices = AccuWeatherForecastServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            AccuWeatherViewModel vm = new AccuWeatherViewModel();
            return View(vm);
        }
        [HttpPost]
        public IActionResult ShowAccuWeather()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "AccuWeatherForecasts");
            }
            return View();
        }

        public IActionResult City()
        {
            AccuWeatherResultDto dto = new();
            AccuWeatherViewModel vm = new();

            _AccuWeatherForecastServices.WeatherDetail(dto);

            vm.Date = dto.EffectiveDate;
            vm.EpochDate = dto.EffectiveEpochDate;
            vm.Severity = dto.Severity;
            vm.Text = dto.Text;
            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;
            vm.Category = dto.Category;

            vm.TempMinValue = dto.TempMinValue;
            vm.TempMinUnit = dto.TempMinUnit;
            vm.TempMinUnitType = dto.TempMinUnitType;

            vm.TempMaxValue = dto.TempMaxValue;
            vm.TempMaxUnit = dto.TempMaxUnit;
            vm.TempMaxUnitType = dto.TempMaxUnitType;

            vm.DayIcon = dto.DayIcon;
            vm.DayIconPhrase = dto.DayIconPhrase;
            vm.DayHasPrecipitation = dto.DayHasPrecipitation;
            vm.DayPrecipitationType = dto.DayPrecipitationType;
            vm.DayPrecipitationIntensity = dto.DayPrecipitationIntensity;

            vm.NightIcon = dto.NightIcon;
            vm.NightIconPhrase = dto.NightIconPhrase;
            vm.NightHasPrecipitation = dto.NightHasPrecipitation;
            vm.NightPrecipitationType = dto.NightPrecipitationType;
            vm.NightPrecipitationIntensity = dto.NightPrecipitationIntensity;
            return View(vm);
        }

    }
}
