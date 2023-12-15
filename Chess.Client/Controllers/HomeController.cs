using Chess.Application.DTOs;
using Chess.Application.Services.Interfaces;
using Chess.Client.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Chess.Client.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        private readonly IMapService _mapService;
        private readonly IBoxService _boxService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration,IMapService mapService, IBoxService boxService)
        {
            _logger = logger;
            _configuration = configuration;

            _mapService = mapService;
            _boxService = boxService;
        }

        public class UserModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        #region public

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //var map = await _mapService.Get(x => x.Id == 1, new List<string>() { { "Boxes" } });
            //var box = await _boxService.Get(x => x.Id == 1, new List<string>() { { "Map" } });
            var maps = await _mapService.GetAll(includes: new List<string>() { { "Boxes" } });

            return View(maps);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            try
            {
                UserModel user = new UserModel()
                {
                    Username = "Martino",
                    Password = BCrypt.Net.BCrypt.HashPassword("password")
                };

                var a = HttpContext.Connection.ClientCertificate;

                if (model.Username != user.Username || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                    return RedirectToAction("Index");

                string cookiesSchemeName = _configuration.GetValue<string>("CookiesScheme");

                List<Claim> claims = new()
                {
                    new Claim("Username", model.Username),
                    new Claim("Password", model.Password)
                };

                ClaimsIdentity identity = new(claims, cookiesSchemeName);
                ClaimsPrincipal claimsPrincipal = new(identity);

                // Sign-in
                await HttpContext.SignInAsync(cookiesSchemeName, claimsPrincipal, new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe,
                    ExpiresUtc = model.RememberMe ? DateTime.UtcNow.AddDays(1) : DateTime.UtcNow.AddMinutes(20),
                });

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                string cookiesSchemeName = _configuration.GetValue<string>("CookiesScheme");

                // Sign-out
                await HttpContext.SignOutAsync(cookiesSchemeName);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> AccessDenied()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> SaveMap(MapDTO map)
        {
            map = await _mapService.Update(map);

            return null;
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

        #endregion

        #region private

        #endregion
    }
}