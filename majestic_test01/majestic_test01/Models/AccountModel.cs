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
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 使用者姓名英文
        /// </summary>

        public string Name_En { get; set; }


        /// <summary>
        /// 使用者電話
        /// </summary>
        [Required]
        public int Phone { get; set; }

        /// <summary>
        /// 性別
        /// </summary>

        public Gender Gender { get; set; }


        /// <summary>
        /// 使用者密碼
        /// </summary>
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,30}$",ErrorMessage = "6-30碼字元須包含最少1個大寫字母、最少1個小寫字母、 最少1個數字，不可有其他符號")]
        public string Password { get; set; }

        /// <summary>
        /// 確認密碼
        /// </summary>
        [Required]
        [Compare(nameof(Password))]
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
        /// 加入會員時間
        /// </summary>

        public DateTime CtateTime { get; set; }

    }
}
