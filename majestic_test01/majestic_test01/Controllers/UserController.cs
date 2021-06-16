using majestic_test01.Data;
using majestic_test01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace majestic_test01.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            List<AccountModel> model = new SeedData().GetAccountData();
            return View(model);
        }

        public IActionResult Edite()
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
    }
}
