using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTARge22.ApplicationServices.Services;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;
using ShopTARge22.Models.RealEstates;

namespace ShopTARge22.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly ShopTARge22Context _context;
        private readonly IRealEstatesServices _realEstatesServices;
        private readonly IFileServices _fileServices;

        public RealEstatesController
        (
                ShopTARge22Context context,
                IRealEstatesServices RealEstatesServices,
                IFileServices fileServices
            )
        {
            _context = context;
            _realEstatesServices = RealEstatesServices;
            _fileServices = fileServices;
        }


        public IActionResult Index()
        {
            var result = _context.RealEstates
                .Select(x => new RealEstatesIndexViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    BuildingType = x.BuildingType,
                    BuiltInYear = x.BuiltInYear,
                    SizeSqrM = x.SizeSqrM
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel result = new RealEstateCreateUpdateViewModel();

            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                SizeSqrM = vm.SizeSqrM,
                RoomCount = vm.RoomCount,
                Floor = vm.Floor,
                BuildingType = vm.BuildingType,
                BuiltInYear = vm.BuiltInYear,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
                Files = vm.Files,
                Image = vm.Image
                    .Select(x => new FileToDatabaseDto
                    {
                        Id = x.ImageId,
                        ImageData = x.ImageData,
                        ImageTitle = x.ImageTitle,
                        RealEstateId = x.RealEstateId,
                    }).ToArray()
            };

            var result = await _realEstatesServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realestate = await _realEstatesServices.DetailsAsync(id);

            if (realestate == null)
            {
                return NotFound();
            }
            var images = await _context.FileToDatabases
               .Where(x => x.RealEstateId == id)
               .Select(y => new RealEstateImageViewModel
               {
                   RealEstateId = y.Id,
                   ImageId = y.Id,
                   ImageData = y.ImageData,
                   ImageTitle = y.ImageTitle,
                   Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
               }).ToArrayAsync();

            var vm = new RealEstateCreateUpdateViewModel();

            vm.Id = realestate.Id;
            vm.Address = realestate.Address;
            vm.SizeSqrM = realestate.SizeSqrM;
            vm.RoomCount = realestate.RoomCount;
            vm.Floor = realestate.Floor;
            vm.BuildingType = realestate.BuildingType;
            vm.BuiltInYear = realestate.BuiltInYear;
            vm.CreatedAt = realestate.CreatedAt;
            vm.UpdatedAt = realestate.UpdatedAt;
            vm.Image.AddRange(images);


            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                SizeSqrM = vm.SizeSqrM,
                RoomCount = vm.RoomCount,
                Floor = vm.Floor,
                BuildingType = vm.BuildingType,
                BuiltInYear = vm.BuiltInYear,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
                Files = vm.Files,
                Image = vm.Image
                    .Select(x => new FileToDatabaseDto
                    {
                        Id = x.ImageId,
                        ImageData = x.ImageData,
                        ImageTitle = x.ImageTitle,
                        RealEstateId = x.RealEstateId,
                    }).ToArray()

            };

            var result = await _realEstatesServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var RealEstate = await _realEstatesServices.DetailsAsync(id);

            if (RealEstate == null)
            {
                return NotFound();
            }
            var images = await _context.FileToDatabases
                .Where(x => x.RealEstateId == id)
                .Select(y => new RealEstateImageViewModel
                {
                    RealEstateId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new RealEstateDetailsViewModel();

            vm.Id = RealEstate.Id;
            vm.Address = RealEstate.Address;
            vm.SizeSqrM = RealEstate.SizeSqrM;
            vm.RoomCount = RealEstate.RoomCount;
            vm.Floor = RealEstate.Floor;
            vm.BuildingType = RealEstate.BuildingType;
            vm.BuiltInYear = RealEstate.BuiltInYear;
            vm.CreatedAt = RealEstate.CreatedAt;
            vm.UpdatedAt = RealEstate.UpdatedAt;
            vm.Image.AddRange(images);


            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var RealEstate = await _realEstatesServices.DetailsAsync(id);

            if (RealEstate == null)
            {
                return NotFound();
            }
            var images = await _context.FileToDatabases
              .Where(x => x.RealEstateId == id)
              .Select(y => new RealEstateImageViewModel
              {
                  RealEstateId = y.Id,
                  ImageId = y.Id,
                  ImageData = y.ImageData,
                  ImageTitle = y.ImageTitle,
                  Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
              }).ToArrayAsync();

            var vm = new RealEstateDeleteViewModel();

            vm.Id = RealEstate.Id;
            vm.Address = RealEstate.Address;
            vm.SizeSqrM = RealEstate.SizeSqrM;
            vm.RoomCount = RealEstate.RoomCount;
            vm.Floor = RealEstate.Floor;
            vm.BuildingType = RealEstate.BuildingType;
            vm.BuiltInYear = RealEstate.BuiltInYear;
            vm.CreatedAt = RealEstate.CreatedAt;
            vm.UpdatedAt = RealEstate.UpdatedAt;
            vm.Image.AddRange(images);


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var RealEstateId = await _realEstatesServices.Delete(id);

            if (RealEstateId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(RealEstateImageViewModel vm)
        {
            var dto = new FileToDatabaseDto()
            {
                Id = vm.ImageId
            };

            var image = await _fileServices.RemoveFilesFromDatabase(dto);

            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
