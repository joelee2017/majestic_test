using majestic_test01.Data;
using majestic_test01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace majestic_test01.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly AccountContext _accountContext;

        public ActivitiesController(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public IActionResult Index(string name, string start, string end)
        {
            IEnumerable<ActivitiesModel> model = new SeedData().GetActivityData();


            if (!string.IsNullOrEmpty(name))
            {
                model = model.Where(s => s.Name.Contains(name));
                TempData["name"] = name;
            }

            if (!string.IsNullOrEmpty(start) || !string.IsNullOrEmpty(end))
            {
                DateTime _start = Convert.ToDateTime(start);
                DateTime _end = Convert.ToDateTime(end);
                model = model.Where(s => s.Date >= _start && s.Date <= _end);
                TempData["start"] = start;
                TempData["end"] = end;
            }

            return View(model);
        }
    }
}
