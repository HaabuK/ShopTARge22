using ShopTARge22.Core.Dto.CocktailsDtos;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface ICocktailServices
    {
        Task<CocktailResultDto> GetCocktails(CocktailResultDto dto);
    }
}
