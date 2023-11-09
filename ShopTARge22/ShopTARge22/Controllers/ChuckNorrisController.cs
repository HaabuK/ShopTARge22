using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Core.Dto.ChuckNorrisDtos;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Models.ChuckNorris;

namespace ShopTARge22.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisServices _chuckNorrisServices;

        public ChuckNorrisController
            (
                IChuckNorrisServices chuckNorrisServices
            )
        {
            _chuckNorrisServices = chuckNorrisServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchChuckNorrisJokes(ChuckNorrisViewModel model)
        {
            //if(ModelState.IsValid)
            //{
                return RedirectToAction("Joke", "ChuckNorris");
            //}

            //return View(model);
        }

        [HttpGet]
        public IActionResult Joke()
        {
            ChuckNorrisResultDto dto = new();

            _chuckNorrisServices.ChuckNorrisResult(dto);
            ChuckNorrisViewModel vm = new();

            vm.Categories = dto.Categories;
            vm.CreatedAt = dto.CreatedAt;
            vm.IconUrl = dto.IconUrl;
            vm.Id = dto.Id;
            vm.UpdatedAt = dto.UpdatedAt;
            vm.Url = dto.Url;
            vm.Value = dto.Value;

            return View(vm);
        }
    }
}
