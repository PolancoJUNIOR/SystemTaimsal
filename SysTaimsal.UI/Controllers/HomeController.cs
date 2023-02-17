using Microsoft.AspNetCore.Mvc;
using SysTaimsal.UI.Models;
using System.Diagnostics;
using SysTaimsal.BL;
using SysTaimsal.DAL;
using SysTaimsal.EL;

namespace SysTaimsal.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly SysTaimsalBDContext _context = new SysTaimsalBDContext();

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
        public IActionResult OursCompany()
        {
            return View();
        }
        public IActionResult Machinery()
        {
            return View(_context.Machines.ToList());
        }
        public IActionResult Briefcase()
        {
            return View();
        }     
        public IActionResult Jobs()
        {
            return View();
        }     
        public IActionResult Contact()
        {
            return View();
        }       
        public IActionResult Shop()
        {
            return View(_context.Products.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}