using Microsoft.AspNetCore.Mvc;
using PBL3.Models;
using System.Diagnostics;
using PBL3.Models.DAL;
using PBL3.Models;

namespace PBL3.Controllers
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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
             DatabaseAccess da = new DatabaseAccess();
            Account user = da.GetUserByUsername(username);

            if (user != null && user.Password == password)
            {
           
                return RedirectToAction("Index", "Home", new { area = "Admin" });
                
            }
            else
            {
                
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
