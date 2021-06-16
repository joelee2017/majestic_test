using majestic_test01.Data;
using majestic_test01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace majestic_test01.Controllers
{
    public class UserController : Controller
    {
        private readonly AccountContext _accountContext;

        public UserController(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<AccountModel> model = new SeedData().GetAccountData();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var model = new AccountModel
            {
                Name = "李123",
                Name_En = "joe123",
                Email = "123@123.com",
                CtateTime = DateTime.Now,
                Phone = 1234567890,
                Gender = Enum.Gender.M,
                Birthday = DateTime.Now,
                Address = "asdssssssssssssssss",
                Subscription = true,
            };
            return View(model);
        }


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
