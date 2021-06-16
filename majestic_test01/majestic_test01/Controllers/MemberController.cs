using majestic_test01.Data;
using majestic_test01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace majestic_test01.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index(string name, string birthday)
        {
            IEnumerable<MemberModel> model = new SeedData().GetMemberData();

            if (!string.IsNullOrEmpty(name))
            {
                model = model.Where(s => s.Name.Contains(name));
                TempData["name"] = name;
            }


            if (!string.IsNullOrEmpty(birthday))
            {
                DateTime dateTime = Convert.ToDateTime(birthday);
                model = model.Where(s => s.Birthday == dateTime);
                TempData["birthday"] = birthday;
            }

            return View(model);
        }
    }
}
