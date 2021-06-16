using majestic_test01.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace majestic_test01.Models
{
    public class AccountModel
    {
        /// <summary>
        /// 登入信箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 使用者姓名中文
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 使用者姓名英文
        /// </summary>

        public string Name_En { get; set; }


        /// <summary>
        /// 使用者電話
        /// </summary>
        public int Phone { get; set; }

        /// <summary>
        /// 性別
        /// </summary>

        public Gender Gender { get; set; }


        /// <summary>
        /// 使用者密碼
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 確認密碼
        /// </summary>
        public string ConfirmPassword { get; set; }


        /// <summary>
        /// 是否記得我
        /// </summary>
        public bool RememberMe { get; set; }


        /// <summary>
        /// 出生年月日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 是否訂閱電子報
        /// </summary>

        public bool Subscription { get; set; }

        /// <summary>
        /// 大頭貼
        /// </summary>
        public byte[] Photo { get; set; }


        /// <summary>
        /// 加入會員時間
        /// </summary>

        public DateTime CtateTime { get; set; }

    }
}
