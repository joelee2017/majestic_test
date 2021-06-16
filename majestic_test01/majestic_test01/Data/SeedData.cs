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

            model.Add(new AccountModel
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
            });
            model.Add(new AccountModel
            {
                Name = "張123",
                Name_En = "joe123",
                Email = "123@123.com",
                CtateTime = DateTime.Now,
                Phone = 1234567890,
                Gender = Enum.Gender.M,
                Birthday = DateTime.Now,
                Address = "asdssssssssssssssss",
                Subscription = true,
            });
            model.Add(new AccountModel
            {
                Name = "陳123",
                Name_En = "joe123",
                Email = "123@123.com",
                CtateTime = DateTime.Now,
                Phone = 1234567890,
                Gender = Enum.Gender.M,
                Birthday = DateTime.Now,
                Address = "asdssssssssssssssss",
                Subscription = true,
            });
            model.Add(new AccountModel
            {
                Name = "趙123",
                Name_En = "joe123",
                Email = "123@123.com",
                CtateTime = DateTime.Now,
                Phone = 1234567890,
                Gender = Enum.Gender.M,
                Birthday = DateTime.Now,
                Address = "asdssssssssssssssss",
                Subscription = true,
            });
            model.Add(new AccountModel
            {
                Name = "黃123",
                Name_En = "joe123",
                Email = "123@123.com",
                CtateTime = DateTime.Now,
                Phone = 1234567890,
                Gender = Enum.Gender.M,
                Birthday = DateTime.Now,
                Address = "asdssssssssssssssss",
                Subscription = true,
            });
            model.Add(new AccountModel
            {
                Name = "徐123",
                Name_En = "joe123",
                Email = "123@123.com",
                CtateTime = DateTime.Now,
                Phone = 1234567890,
                Gender = Enum.Gender.M,
                Birthday = DateTime.Now,
                Address = "asdssssssssssssssss",
                Subscription = true,
            });

            return model;
        }

        public List<MemberModel> GetMemberData()
        {
            List<MemberModel> model = new List<MemberModel>();
            var dateTime = DateTime.Now.ToString("d");
            model.Add(new MemberModel {
                Id = 1,
                Name = "李123",
                Gender = Enum.Gender.M,
                Birthday = Convert.ToDateTime(dateTime),
                NemberId = "A123456789",
                Email = "123@123.com",
                Phone = "0912345678",
                Address ="asdasdadasdad",
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
    }
}
