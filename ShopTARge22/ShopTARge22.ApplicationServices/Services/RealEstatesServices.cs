using System.Xml;
using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;

namespace ShopTARge22.ApplicationServices.Services
{
    public class RealEstatesServices : IRealEstatesServices
    {
        private readonly ShopTARge22Context _context;
        private readonly IFileServices _fileServices;

        public RealEstatesServices
            (
                ShopTARge22Context context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }


        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realestate = new RealEstate();

            realestate.Id = Guid.NewGuid();
            realestate.Address = dto.Address;
            realestate.SizeSqrM = dto.SizeSqrM;
            realestate.RoomCount = dto.RoomCount;
            realestate.Floor = dto.Floor;
            realestate.BuildingType = dto.BuildingType;
            realestate.BuiltInYear = dto.BuiltInYear;
            realestate.CreatedAt = DateTime.Now;
            realestate.UpdatedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, realestate);
            }


            await _context.RealEstates.AddAsync(realestate);
            await _context.SaveChangesAsync();

            return realestate;
        }

        public async Task<RealEstate> DetailsAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            RealEstate realestate = new();

            realestate.Id = dto.Id;
            realestate.Address = dto.Address;
            realestate.SizeSqrM = dto.SizeSqrM;
            realestate.RoomCount = dto.RoomCount;
            realestate.Floor = dto.Floor;
            realestate.BuildingType = dto.BuildingType;
            realestate.BuiltInYear = dto.BuiltInYear;
            realestate.CreatedAt = DateTime.Now;
            realestate.UpdatedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, realestate);
            }

            _context.RealEstates.Update(realestate);
            await _context.SaveChangesAsync();

            return realestate;
        }

        public async Task<RealEstate> Delete(Guid id)
        {
            var realestateId = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.RealEstates.Remove(realestateId);
            await _context.SaveChangesAsync();


            return realestateId;
        }
    }
}
