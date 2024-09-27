using Microsoft.AspNetCore.Mvc;

namespace MyPage.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
