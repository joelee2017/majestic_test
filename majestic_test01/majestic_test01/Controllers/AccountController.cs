using majestic_test01.Data;
using majestic_test01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace majestic_test01.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountContext _accountContext;

        public AccountController(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var remil = ConfirmRepeatEmail(model.Email);
            var rphone = ConfirmRepeatPhone(model.Phone);
            
            if (remil || rphone)
            {             
                return View(model);
            }



            return View();
        }

        /// <summary>
        /// 確認信箱是否重覆
        /// </summary>        
        private bool ConfirmRepeatEmail(string mail)
        {
            bool result = true;
            // result = _accountContext.Accounts.Any(s => s.Email == mail);
            if (result)
            {
                TempData["RepeatEmail"] = "信箱不可重覆";
            }
            return result;
        }

        /// <summary>
        /// 確認手機是否重覆
        /// </summary>        
        private bool ConfirmRepeatPhone(int phone)
        {
            bool result = true;
            // result = _accountContext.Accounts.Any(s => s.Phone == phone);
            if (result)
            {
                TempData["RepeatPhone"] = "電話不可重覆";
            }
            return result;
        }
    }
}
