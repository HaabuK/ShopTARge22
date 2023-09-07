using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Data;
using ShopTARge22.Models.Spaceships;

namespace ShopTARge22.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopTARge22Context _context;

        public SpaceshipsController
            (
            ShopTARge22Context context
            )
        {_context = context;}
        public IActionResult Index()
        {
            var result = _context.Spaceships.Select( x => new SpaceshipsIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    BuiltDate = x.BuiltDate,
                    Passengers = x.Passengers
                });

            return View();
        }
    }
}