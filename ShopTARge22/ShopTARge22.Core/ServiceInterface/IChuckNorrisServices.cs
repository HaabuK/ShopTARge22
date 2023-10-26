using ShopTARge22.Core.Dto;
using ShopTARge22.Core.Dto.Norris;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IChuckNorrisServices
    {
        Task<ChuckNorrisDto> ChuckNorrisResult(ChuckNorrisDto dto);
    }
}
