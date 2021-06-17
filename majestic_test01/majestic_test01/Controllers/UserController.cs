using majestic_test01.Data;
using majestic_test01.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace majestic_test01.Controllers
{
    [Authorize]
    [ResponseCache(NoStore = true)]
    public class UserController : Controller
    {
        private readonly AccountContext _accountContext;

        public UserController(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        /// <summary>
        /// 維護個人畫面
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            List<AccountModel> model = new SeedData().GetAccountData();
            return View(model);
        }

        /// <summary>
        /// 維護個人編輯畫面
        /// </summary>
        [HttpGet]
        public IActionResult Edit(int id)
        {
               AccountModel model = new SeedData().GetAccountData().FirstOrDefault(s => s.Id == id);
            return View(model);
        }


        /// <summary>
        /// 維護個人編輯執行
        /// </summary>
        [HttpPost]
        public IActionResult Edite(AccountModel model, IFormFile files)
        {        
            if (ModelState.IsValid)
            {
                Account account = new Account()
                {
                    Photo = FileToBytes(files),
                    Name = model.Name,
                    Name_En = model.Name_En,
                    Phone = model.Phone,
                    Gender = model.Gender,
                    Birthday = model.Birthday,
                    Address = model.Address,
                    Subscription = model.Subscription,
                };
                _accountContext.Accounts.Update(account);
                _accountContext.SaveChanges();
            }
            return View(model);
        }

        /// <summary>
        /// 圖轉 byte[]
        /// </summary>
        private byte[] FileToBytes(IFormFile files)
        {
            byte[] fileBytes = new byte[] {};
            if (files.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    files.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }
            }

            return fileBytes;
        }
    }
}
