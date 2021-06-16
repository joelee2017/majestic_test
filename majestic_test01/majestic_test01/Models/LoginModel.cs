using System.ComponentModel.DataAnnotations;

namespace majestic_test01.Models
{
    public class LoginModel
    {
        /// <summary>
        /// 登入信箱
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// 使用者密碼
        /// </summary>
        [Required]       
        public string Password { get; set; }

        /// <summary>
        /// 是否記得我
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
