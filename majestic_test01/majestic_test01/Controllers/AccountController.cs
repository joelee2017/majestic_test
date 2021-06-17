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

        /// <summary>
        /// 登入畫面
        /// </summary>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登入執行
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            RememberMe(model);

            Claim[] claims = new[] { new Claim("Account", model.Email, null) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            double loginExpireMinute = this._config.GetValue<double>("LoginExpireMinute");
            await HttpContext.SignInAsync(principal, new AuthenticationProperties()
            {
                IsPersistent = false,
                //用戶頁面停留太久，逾期時間，在此設定的話會覆蓋Startup.cs裡的逾期設定
                ExpiresUtc = DateTime.UtcNow.AddSeconds(10)
            });

            if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// 登出畫面
        /// </summary>

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }


        /// <summary>
        /// 註冊畫面
        /// </summary>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        /// <summary>
        /// 註冊執行
        /// </summary>
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
        /// 登入資訊記憶
        /// </summary>
        /// <param name="model"></param>
        private void RememberMe(LoginModel model)
        {
            if (model.RememberMe)
            {
                HttpContext.Response.Cookies.Append("email", model.Email);
                HttpContext.Response.Cookies.Append("password", model.Password);
                HttpContext.Response.Cookies.Append("rememberme", "yes");
            }
            else
            {
                HttpContext.Response.Cookies.Delete("email");
                HttpContext.Response.Cookies.Delete("password");
                HttpContext.Response.Cookies.Delete("rememberme");
            }
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
