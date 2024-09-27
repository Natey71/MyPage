using Microsoft.AspNetCore.Mvc;
using MyPage.DataAccess.Management;
using MyPage.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMasterDataRepo _masterRepo;
        public HomeController(ILogger<HomeController> logger, IMasterDataRepo masterRepo)
        {
            _logger = logger;
            _masterRepo = masterRepo;
        }

        public IActionResult Index()
        {
            return View();
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
        [HttpPost]
        public async Task<IActionResult> GetLanguages()
        {
            var list = await _masterRepo.GetLanguagesAsync();
            var result = JsonConvert.SerializeObject(list);
            return Json(result);
        }
    }
}
