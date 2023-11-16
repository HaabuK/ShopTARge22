using Nancy.Json;
using ShopTARge22.Core.Dto.CocktailsDtos;
using ShopTARge22.Core.ServiceInterface;
using System.Net;

namespace ShopTARge22.ApplicationServices.Services
{
    public class CocktailServices : ICocktailServices
    {
        public async Task<CocktailResultDto> GetCocktails(CocktailResultDto dto)
        {
            string apiKey = "1";
            string apiCallUrl = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={dto.StrDrink}";

            using (WebClient client = new())
            {
                string json = client.DownloadString(apiCallUrl);
                CocktailRootDto cocktailResult = new JavaScriptSerializer().Deserialize<CocktailRootDto>(json);

                dto.IdDrink = cocktailResult.Drinks[0].IdDrink;
                dto.StrDrink = cocktailResult.Drinks[0].StrDrink;
                dto.StrDrinkAlternate = cocktailResult.Drinks[0].StrDrinkAlternate;
                dto.StrTags = cocktailResult.Drinks[0].StrTags;
                dto.StrVideo = cocktailResult.Drinks[0].StrVideo;
                dto.StrCategory = cocktailResult.Drinks[0].StrCategory;
                dto.StrIBA = cocktailResult.Drinks[0].StrIBA;
                dto.StrAlcoholic = cocktailResult.Drinks[0].StrAlcoholic;
                dto.StrGlass = cocktailResult.Drinks[0].StrGlass;
                dto.StrInstructions = cocktailResult.Drinks[0].StrInstructions;
                dto.StrInstructionsES = cocktailResult.Drinks[0].StrInstructionsES;
                dto.StrInstructionsDE = cocktailResult.Drinks[0].StrInstructionsDE;
                dto.StrInstructionsFR = cocktailResult.Drinks[0].StrInstructionsFR;
                dto.StrInstructionsIT = cocktailResult.Drinks[0].StrInstructionsIT;
                dto.StrInstructionsZHHANS = cocktailResult.Drinks[0].StrInstructionsZHHANS;
                dto.StrInstructionsZHHANT = cocktailResult.Drinks[0].StrInstructionsZHHANT;
                dto.StrDrinkThumb = cocktailResult.Drinks[0].StrDrinkThumb;
                dto.StrIngredient1 = cocktailResult.Drinks[0].StrIngredient1;
                dto.StrIngredient2 = cocktailResult.Drinks[0].StrIngredient2;
                dto.StrIngredient3 = cocktailResult.Drinks[0].StrIngredient3;
                dto.StrIngredient4 = cocktailResult.Drinks[0].StrIngredient4;
                dto.StrIngredient5 = cocktailResult.Drinks[0].StrIngredient5;
                dto.StrIngredient6 = cocktailResult.Drinks[0].StrIngredient6;
                dto.StrIngredient7 = cocktailResult.Drinks[0].StrIngredient7;
                dto.StrIngredient8 = cocktailResult.Drinks[0].StrIngredient8;
                dto.StrIngredient9 = cocktailResult.Drinks[0].StrIngredient9;
                dto.StrIngredient10 = cocktailResult.Drinks[0].StrIngredient10;
                dto.StrIngredient11 = cocktailResult.Drinks[0].StrIngredient11;
                dto.StrIngredient12 = cocktailResult.Drinks[0].StrIngredient12;
                dto.StrIngredient13 = cocktailResult.Drinks[0].StrIngredient13;
                dto.StrIngredient14 = cocktailResult.Drinks[0].StrIngredient14;
                dto.StrIngredient15 = cocktailResult.Drinks[0].StrIngredient15;
                dto.StrMeasure1 = cocktailResult.Drinks[0].StrMeasure1;
                dto.StrMeasure2 = cocktailResult.Drinks[0].StrMeasure2;
                dto.StrMeasure3 = cocktailResult.Drinks[0].StrMeasure3;
                dto.StrMeasure4 = cocktailResult.Drinks[0].StrMeasure4;
                dto.StrMeasure5 = cocktailResult.Drinks[0].StrMeasure5;
                dto.StrMeasure6 = cocktailResult.Drinks[0].StrMeasure6;
                dto.StrMeasure7 = cocktailResult.Drinks[0].StrMeasure7;
                dto.StrMeasure8 = cocktailResult.Drinks[0].StrMeasure8;
                dto.StrMeasure9 = cocktailResult.Drinks[0].StrMeasure9;
                dto.StrMeasure10 = cocktailResult.Drinks[0].StrMeasure10;
                dto.StrMeasure11 = cocktailResult.Drinks[0].StrMeasure11;
                dto.StrMeasure12 = cocktailResult.Drinks[0].StrMeasure12;
                dto.StrMeasure13 = cocktailResult.Drinks[0].StrMeasure13;
                dto.StrMeasure14 = cocktailResult.Drinks[0].StrMeasure14;
                dto.StrMeasure15 = cocktailResult.Drinks[0].StrMeasure15;
                dto.StrImageSource = cocktailResult.Drinks[0].StrImageSource;
                dto.StrImageAttribution = cocktailResult.Drinks[0].StrImageAttribution;
                dto.StrCreativeCommonsConfirmed = cocktailResult.Drinks[0].StrCreativeCommonsConfirmed;
                dto.DateModified = cocktailResult.Drinks[0].DateModified;
            }

                return dto;
        }
    }
}
