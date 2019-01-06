using Microsoft.AspNetCore.Mvc;
using System;

namespace xSolution.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
            [HttpGet]
            public IActionResult Index()
            {
                return View();
            }
    }
    
}
