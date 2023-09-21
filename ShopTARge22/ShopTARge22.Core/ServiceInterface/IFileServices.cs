using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship spaceship);
    }
}
