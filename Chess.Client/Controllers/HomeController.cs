using Chess.Application.Services.Interfaces;
using Chess.Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chess.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapService _mapService;
        private readonly IBoxService _boxService;

        public HomeController(ILogger<HomeController> logger, IMapService mapService, IBoxService boxService)
        {
            _logger = logger;
            _mapService = mapService;
            _boxService = boxService;
        }

        public async Task<IActionResult> Index()
        {
            var map = await _mapService.Get(x => x.Id == 1, new List<string>() { { "Boxes" } });
            //var box = await _boxService.Get(x => x.Id == 1, new List<string>() { { "Map" } });

            return View(map);
        }

        public IActionResult Maps()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}