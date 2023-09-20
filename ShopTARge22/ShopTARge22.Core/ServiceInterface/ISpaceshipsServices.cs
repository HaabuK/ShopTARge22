using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;


namespace ShopTARge22.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> Create(SpaceshipDto dto);
        Task<Spaceship> DetailsAsync(Guid id);
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);
    }
}
