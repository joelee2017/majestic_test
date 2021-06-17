using majestic_test01.Data;
using majestic_test01.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace majestic_test01.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AccountContext _accountContext;

        public AccountController(IConfiguration config, AccountContext accountContext)
        {
            this._config = config;
            _accountContext = accountContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Claim[] claims = new[] { new Claim("Account", model.Email, null ) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            double loginExpireMinute = this._config.GetValue<double>("LoginExpireMinute");
            await HttpContext.SignInAsync(principal, new AuthenticationProperties()
                {
                    IsPersistent = false, 
                    //用戶頁面停留太久，逾期時間，在此設定的話會覆蓋Startup.cs裡的逾期設定
                    ExpiresUtc = DateTime.UtcNow.AddSeconds(20)
                });

            if (!String.IsNullOrEmpty(returnUrl) && !Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
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
