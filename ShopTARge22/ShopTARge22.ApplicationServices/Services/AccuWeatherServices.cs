using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nancy;
using Nancy.Json;
using Newtonsoft.Json;
using ShopTARge22.Core.Dto.AccuWeatherDtos;
using ShopTARge22.Core.Dto.AccuWeatherLocationDtos;
using ShopTARge22.Core.ServiceInterface;
using System.Net;
using System.Net.Http.Json;

public class AccuWeatherServices : IAccuWeatherServices
{
    //public string Key = "127964";
    string API_Key = "81x4qXCOAtsPhDWFWi3YDfDhr8TnWv7y";


    public async Task<AccuWeatherLocationResultDto> AccuWeatherGet(AccuWeatherLocationResultDto dto1)
    {

        try
        {

            var url1 = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={API_Key}&q={dto1.City}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url1);
                List<AccuWeatherLocationRootDto> accuGet = new JavaScriptSerializer().Deserialize<List<AccuWeatherLocationRootDto>>(json);

                dto1.Key = accuGet[0].Key;
                dto1.Country = accuGet[0].Country;
                dto1.LocalizedName = accuGet[0].LocalizedName;
            }
        }
        catch (Exception ex) { Console.WriteLine("City not available. Try another city"); }
            return dto1;
       
    }


    public async Task<AccuWeatherResultDtos> AccuWeatherResult(AccuWeatherResultDtos dto, AccuWeatherLocationResultDto dto1)
    {
        await AccuWeatherGet(dto1);

        if (!string.IsNullOrEmpty(dto1.Key))
        {
            string url = $"http://dataservice.accuweather.com/currentconditions/v1/{dto1.Key}?apikey={API_Key}&details=true";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                List<AccuWeatherRootDtos> accuResult = new JavaScriptSerializer().Deserialize<List<AccuWeatherRootDtos>>(json);

                dto.Temperature = accuResult[0].Temperature.Metric.Value;
                dto.RealFeelTemperature = accuResult[0].RealFeelTemperature.Metric.Value;
                dto.RelativeHumidity = accuResult[0].RelativeHumidity;
                dto.Wind = accuResult[0].Wind.Speed.Metric.Value;
                dto.Pressure = accuResult[0].Pressure.Metric.Value;
                dto.WeatherText = accuResult[0].WeatherText;
            }
        }

        return dto;
    }

}
