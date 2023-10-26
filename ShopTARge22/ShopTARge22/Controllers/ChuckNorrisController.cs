using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Core.Dto.Norris;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Models.Norris;

namespace ShopTARge22.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisServices _chuckNorrisServices;

        public ChuckNorrisController
            (
            IChuckNorrisServices ChuckNorrisServices
            )
        {
            _chuckNorrisServices = ChuckNorrisServices;
        }


        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SearchCategory(SearchCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Search", "ChuckNorris", new { category = model.categories });
            }

            return View(model);
        }

        public IActionResult Search(string category)
        {

            ChuckNorrisDto dto = new();
            _chuckNorrisServices.ChuckNorrisResult(dto);
            ChuckNorrisViewModel vm = new();

            vm.Id = dto.Id;
            vm.icon_url = dto.icon_url;
            vm.url = dto.url;
            vm.value = dto.value;

            return View(vm);
        }
    }
}
