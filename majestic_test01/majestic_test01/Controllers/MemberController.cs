using majestic_test01.Data;
using majestic_test01.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace majestic_test01.Controllers
{
    [Authorize]
    [ResponseCache(NoStore = true)]
    public class MemberController : Controller
    {
        private readonly AccountContext _accountContext;

        public MemberController(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }


        /// <summary>
        /// 會員畫面
        /// </summary>
        [HttpGet]
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

        /// <summary>
        /// 會員新增畫面
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 會員新增執行
        /// </summary>
        [HttpPost]
        public IActionResult Create(MemberModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var rnumberid = ConfirmRepeatNumberId(model.NemberId);
            if (rnumberid)
            {
                return View(model);
            }

            Member member = new Member()
            {
                Name = model.Name,
                Gender = model.Gender,
                Birthday = model.Birthday,
                NemberId = model.NemberId,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                School = model.School,
                Department = model.Department
            };

            _accountContext.Members.Add(member);
            _accountContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// 會員編輯畫面
        /// </summary>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            MemberModel model = new SeedData().GetMemberData().FirstOrDefault(s => s.Id == id);

            return View(model);
        }

        /// <summary>
        /// 會員編輯執行
        /// </summary>
        [HttpPost]
        public IActionResult Edit(MemberModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var rnumberid = ConfirmRepeatNumberId(model.NemberId);
            if (rnumberid)
            {
                return View(model);
            }

            Member member = new Member()
            {
                Name = model.Name,
                Gender = model.Gender,
                Birthday = model.Birthday,
                NemberId = model.NemberId,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                School = model.School,
                Department = model.Department
            };

            _accountContext.Members.Update(member);
            _accountContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// 確認信箱是否重覆
        /// </summary>        
        private bool ConfirmRepeatNumberId(string id)
        {
            bool result = true;
            // result = _accountContext.Accounts.Any(s => s.Email == mail);
            if (result)
            {
                TempData["RepeatNumberId"] = "身份證字號不可重覆";
            }
            return result;
        }
    }
}
