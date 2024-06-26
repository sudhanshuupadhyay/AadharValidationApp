using AadharValidationApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AadharValidationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult AadharValidationView()
        {
            return View();
        }

        public string InputResult(string aadharnumber)
        {
            string message = string.Empty;
            try
            {
                
                BussinesLogic bl = new BussinesLogic();
                if (bl.ValidateAdharnumber(aadharnumber))
                {
                    message = "Aadhar number is Valid";
                }
                else
                {
                    message = "Duplicate Aadhar number";
                }
            }
            catch (Exception ex)
            {
                message = "Something went wrong";
            }
            return message;
        }
    }
}
