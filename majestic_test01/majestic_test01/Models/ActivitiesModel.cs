using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace majestic_test01.Models
{
    public class ActivitiesModel
    {
        /// <summary>
        /// 編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 活動名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 活動日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 活動費用
        /// </summary>
        public int Charge { get; set; }

        /// <summary>
        /// 人數
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 參加會員
        /// </summary>
        public string Participate { get; set; }

        /// <summary>
        /// 參加會員
        /// </summary>
        public List<SelectListItem> Participates { get; set; }
    }
}
