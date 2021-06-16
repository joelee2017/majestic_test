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
    }
}
