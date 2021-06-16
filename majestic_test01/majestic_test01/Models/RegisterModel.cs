using System.ComponentModel.DataAnnotations;

namespace majestic_test01.Models
{
    public class RegisterModel
    {
        /// <summary>
        /// 使用者姓名中文
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 登入信箱
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// 使用者電話
        /// </summary>
        [Required]
        public int Phone { get; set; }

        /// <summary>
        /// 使用者密碼
        /// </summary>
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,30}$", ErrorMessage = "6-30碼字元須包含最少1個大寫字母、最少1個小寫字母、 最少1個數字，不可有其他符號")]
        public string Password { get; set; }

        /// <summary>
        /// 確認密碼
        /// </summary>
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
