using majestic_test01.Data;
using majestic_test01.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace majestic_test01.Controllers
{
    [Authorize]
    [ResponseCache(NoStore = true)]
    public class ActivitiesController : Controller
    {
        private readonly AccountContext _accountContext;

        public ActivitiesController(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult Create()
        {
            ActivitiesModel model = new ActivitiesModel();
            model.Participates = GetParticipates();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ActivitiesModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Activities activities = new Activities()
            {
                Name = model.Name,
                Date = model.Date,
                Charge = model.Charge,
                Total = model.Total,
                Participate = model.Participate,
            };

            _accountContext.Activitys.Add(activities);
            _accountContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ActivitiesModel model = new SeedData().GetActivityData().FirstOrDefault(s => s.Id == id);
            model.Participates = GetParticipates(model.Name);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ActivitiesModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Activities activities = new Activities()
            {
                Name = model.Name,
                Date = model.Date,
                Charge = model.Charge,
                Total = model.Total,
                Participate = model.Participate,
            };

            _accountContext.Activitys.Update(activities);
            _accountContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetParticipates(string name = null)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var result = new SeedData().GetMemberData().Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Name,
            });

            items = result.ToList();

            items.ForEach(s =>
            {
                if(s.Value == name)
                {
                    s.Selected = true;
                }

            });

            return items;
        }
    }
}
