using Nancy.Json;
using System.Net;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Core.Dto.WeatherDtos;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace ShopTARge22.ApplicationServices.Services
{
    public class AccuWeatherForecastsServices : IAccuWeatherForecastServices
    {
        public async Task<AccuWeatherResultDto> WeatherDetail(AccuWeatherResultDto dto)
        {
           
            string apikey = "81x4qXCOAtsPhDWFWi3YDfDhr8TnWv7y";
            var url = $"http://dataservice.accuweather.com/currentconditions/v1/127964?apikey={apikey}&metric=true";


            //127964
            using (WebClient client = new WebClient())
            {

                string json = client.DownloadString(url);

                List<AccuWeatherRootDto> AccuWeatherInfo = new JavaScriptSerializer().Deserialize<List<AccuWeatherRootDto>>(json);

                dto.EffectiveDate = AccuWeatherInfo[0].Headline.EffectiveDate;
                dto.EffectiveEpochDate = AccuWeatherInfo[0].Headline.EffectiveEpochDate;
                dto.Severity = AccuWeatherInfo[0].Headline.Severity;
                dto.Text = AccuWeatherInfo[0].Headline.Text;
                dto.Category = AccuWeatherInfo[0].Headline.Category;
                dto.EndDate = AccuWeatherInfo[0].Headline.EndDate;
                dto.EndEpochDate = AccuWeatherInfo[0].Headline.EndEpochDate;

                dto.MobileLink = AccuWeatherInfo[0].Headline.MobileLink;
                dto.Link = AccuWeatherInfo[0].Headline.Link;

                //dto.DailyForecastsDay = AccuWeatherInfo[0].DailyForecasts[0].Date;
                //dto.DailyForecastsEpochDate = AccuWeatherInfo[0].DailyForecasts[0].EpochDate;

                //dto.TempMinValue = AccuWeatherInfo[0].DailyForecasts[0].Temperature.Minimum.Value;
                //dto.TempMinUnit = AccuWeatherInfo[0].DailyForecasts[0].Temperature.Minimum.Unit;
                //dto.TempMinUnitType = AccuWeatherInfo[0].DailyForecasts[0].Temperature.Minimum.UnitType;

                //dto.TempMaxValue = AccuWeatherInfo[0].DailyForecasts[0].Temperature.Maximum.Value;
                //dto.TempMaxUnit = AccuWeatherInfo[0].DailyForecasts[0].Temperature.Maximum.Unit;
                //dto.TempMaxUnitType = AccuWeatherInfo[0].DailyForecasts[0].Temperature.Maximum.UnitType;

                //dto.DayIcon = AccuWeatherInfo[0].DailyForecasts[0].Day.Icon;
                //dto.DayIconPhrase = AccuWeatherInfo[0].DailyForecasts[0].Day.IconPhrase;
                //dto.DayHasPrecipitation = AccuWeatherInfo[0].DailyForecasts[0].Day.HasPrecipitation;
                //dto.DayPrecipitationType = AccuWeatherInfo[0].DailyForecasts[0].Day.PrecipitationType;
                //dto.DayPrecipitationIntensity = AccuWeatherInfo[0].DailyForecasts[0].Day.PrecipitationIntensity;

                //dto.NightIcon = AccuWeatherInfo[0].DailyForecasts[0].Night.Icon;
                //dto.NightIconPhrase = AccuWeatherInfo[0].DailyForecasts[0].Night.IconPhrase;
                //dto.NightHasPrecipitation = AccuWeatherInfo[0].DailyForecasts[0].Night.HasPrecipitation;
                //dto.NightPrecipitationType = AccuWeatherInfo[0].DailyForecasts[0].Night.PrecipitationType;
                //dto.NightPrecipitationIntensity = AccuWeatherInfo[0].DailyForecasts[0].Night.PrecipitationIntensity;
            }
            return null;
        }
    }
}
