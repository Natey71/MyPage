﻿using Microsoft.AspNetCore.Mvc;

namespace MyPage.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
