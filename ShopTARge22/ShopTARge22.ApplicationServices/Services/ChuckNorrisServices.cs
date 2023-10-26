using System.Net;
using Nancy.Json;
using ShopTARge22.Core.Dto.Norris;
using ShopTARge22.Core.ServiceInterface;


namespace ShopTARge22.ApplicationServices.Services
{
    public class ChuckNorrisServices : IChuckNorrisServices
    {

        public async Task<ChuckNorrisDto> ChuckNorrisResult(ChuckNorrisDto dto)
        {

            string url = $"https://api.chucknorris.io/jokes/random";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                ChuckNorrisRootDto chuckResult = new JavaScriptSerializer().Deserialize<ChuckNorrisRootDto>(json);

                dto.Id = chuckResult.Id;
                dto.icon_url = chuckResult.Icon_url;
                dto.url = chuckResult.Url;
                dto.value = chuckResult.Value;
            }

            return null;
        }
    }
}
