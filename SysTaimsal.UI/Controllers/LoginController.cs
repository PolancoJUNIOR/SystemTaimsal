using Microsoft.AspNetCore.Mvc;

namespace SysTaimsal.UI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
