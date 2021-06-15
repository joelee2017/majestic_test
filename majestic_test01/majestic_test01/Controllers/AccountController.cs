using majestic_test01.Models;
using Microsoft.AspNetCore.Mvc;

namespace majestic_test01.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(AccountModel model)
        {
            return View();
        }
    }
}
