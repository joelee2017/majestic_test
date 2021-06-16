using majestic_test01.Enum;
using System;

namespace majestic_test01.Models
{
    public class MemberModel
    {
        /// <summary>
        /// 編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 出生年月日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 歲數
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 身份證字號
        /// </summary>
        public string NemberId { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手機
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 通訊地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 學校
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// 科系
        /// </summary>
        public string Department { get; set; }
    }
}
