using majestic_test01.Models;
using System;
using System.Collections.Generic;

namespace majestic_test01.Data
{
    public class SeedData
    {
        public List<AccountModel> GetAccountData()
        {
            List<AccountModel> model = new List<AccountModel>();
            var dateTime = DateTime.Now.ToString("d");
            model.Add(new AccountModel
            {
                Name = "李123",
                Name_En = "joe123",
                Email = "123@123.com",
                CtateTime = Convert.ToDateTime(dateTime),
                Phone = 1234567890,
                Gender = Enum.Gender.M,
                Birthday = Convert.ToDateTime(dateTime),
                Address = "asdssssssssssssssss",
                Subscription = true,
            });
            model.Add(new AccountModel
            {
                Name = "張123",
                Name_En = "joe123",
                Email = "123@123.com",
                CtateTime = Convert.ToDateTime(dateTime).AddDays(1),
                Phone = 1234567890,
                Gender = Enum.Gender.M,
                Birthday = Convert.ToDateTime(dateTime).AddDays(1),
                Address = "asdssssssssssssssss",
                Subscription = true,
            });
            model.Add(new AccountModel
            {
                Name = "陳123",
                Name_En = "joe123",
                Email = "123@123.com",
                CtateTime = Convert.ToDateTime(dateTime).AddDays(2),
                Phone = 1234567890,
                Gender = Enum.Gender.M,
                Birthday = Convert.ToDateTime(dateTime).AddDays(2),
                Address = "asdssssssssssssssss",
                Subscription = true,
            });
            model.Add(new AccountModel
            {
                Name = "趙123",
                Name_En = "joe123",
                Email = "123@123.com",
                CtateTime = Convert.ToDateTime(dateTime).AddDays(3),
                Phone = 1234567890,
                Gender = Enum.Gender.M,
                Birthday = Convert.ToDateTime(dateTime).AddDays(3),
                Address = "asdssssssssssssssss",
                Subscription = true,
            });
            model.Add(new AccountModel
            {
                Name = "黃123",
                Name_En = "joe123",
                Email = "123@123.com",
                CtateTime = Convert.ToDateTime(dateTime).AddDays(4),
                Phone = 1234567890,
                Gender = Enum.Gender.M,
                Birthday = Convert.ToDateTime(dateTime).AddDays(4),
                Address = "asdssssssssssssssss",
                Subscription = true,
            });
            model.Add(new AccountModel
            {
                Name = "徐123",
                Name_En = "joe123",
                Email = "123@123.com",
                CtateTime = Convert.ToDateTime(dateTime).AddDays(5),
                Phone = 1234567890,
                Gender = Enum.Gender.M,
                Birthday = Convert.ToDateTime(dateTime).AddDays(5),
                Address = "asdssssssssssssssss",
                Subscription = true,
            });

            return model;
        }

        public List<MemberModel> GetMemberData()
        {
            List<MemberModel> model = new List<MemberModel>();
            var dateTime = DateTime.Now.ToString("d");
            model.Add(new MemberModel
            {
                Id = 1,
                Name = "李123",
                Gender = Enum.Gender.M,
                Birthday = Convert.ToDateTime(dateTime),
                NemberId = "A123456789",
                Email = "123@123.com",
                Phone = "0912345678",
                Address = "asdasdadasdad",
                School = "123學園",
                Department = "中文系"
            });

            model.Add(new MemberModel
            {
                Id = 2,
                Name = "陳123",
                Gender = Enum.Gender.M,
                Birthday = Convert.ToDateTime(dateTime).AddDays(1),
                NemberId = "A123456788",
                Email = "321@123.com",
                Phone = "0912345699",
                Address = "99dasdadasdad",
                School = "123學園",
                Department = "英文系"
            });

            model.Add(new MemberModel
            {
                Id = 3,
                Name = "張123",
                Gender = Enum.Gender.M,
                Birthday = Convert.ToDateTime(dateTime).AddDays(2),
                NemberId = "A123456766",
                Email = "45@123.com",
                Phone = "0912345588",
                Address = "87dasdadasdad",
                School = "123學園",
                Department = "日文系"
            });

            return model;
        }

        public List<ActivitiesModel> GetActivityData()
        {
            List<ActivitiesModel> activities = new List<ActivitiesModel>();
            var dateTime = DateTime.Now.ToString("d");
            activities.Add(new ActivitiesModel
            {
                Id = 1,
                Name = "跑步",
                Date = Convert.ToDateTime(dateTime),
                Charge = 500,
                Total = 60,
                Participate = "李123"
            });

            activities.Add(new ActivitiesModel
            {
                Id = 2,
                Name = "游泳",
                Date = Convert.ToDateTime(dateTime).AddDays(2),
                Charge = 800,
                Total = 20,
                Participate = "陳123"
            });

            activities.Add(new ActivitiesModel
            {
                Id = 3,
                Name = "籃球",
                Date = Convert.ToDateTime(dateTime).AddDays(4),
                Charge = 1000,
                Total = 36,
                Participate = "張123"
            });

            return activities;
        }
    }
}
