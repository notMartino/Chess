using Chess.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Client.Controllers
{
    public class MapsController : Controller
    {
        private readonly ILogger<MapsController> _logger;
        private readonly IMapService _mapService;
        private readonly IBoxService _boxService;

        public MapsController(ILogger<MapsController> logger, IMapService mapService, IBoxService boxService)
        {
            _logger = logger;
            _mapService = mapService;
            _boxService = boxService;
        }

        public async Task<IActionResult> Index()
        {
            var maps = await _mapService.GetAll(includes: new () { "Boxes" });

            maps.ForEach(x => x.Boxes = x.Boxes.OrderByDescending(y => y.RowId).ThenBy(y => y.ColId).ToList());

            return View(maps);
        }
    }
}
