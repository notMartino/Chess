using Chess.Application;
using Chess.Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chess.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapService _mapService;

        public HomeController(ILogger<HomeController> logger, IMapService mapService)
        {
            _logger = logger;
            _mapService = mapService;
        }

        public IActionResult Index()
        {
            var maps = _mapService.GetAllMaps().Select(x => new MapModel { Id = x.Id, Name = x.Name, cols = x.cols, rows = x.rows});

            return View(maps.ToList());
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