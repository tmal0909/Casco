using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascoCS.Models
{
    public class ReservationMD
    {
        public ReservationMD()
        {
            OptionService = new List<SelectListItem>();
            List<ServiceItem> serviceItems = RepositoryServiceItem.Query();

            OptionService.Add(new SelectListItem { Text = "請選擇服務項目", Value = "", Selected = true });
            foreach(var item in serviceItems)
            {
                OptionService.Add(new SelectListItem { Text = item.Service, Value = item.ID.ToString() });
            }
        }

        [Required(ErrorMessage = "請填寫您的手機號碼 (09XXXXXXXX)")]
        [StringLength(10, ErrorMessage =("請填寫您的手機號碼 (09XXXXXXXX)"))]
        [RegularExpression("^[0-9]*$", ErrorMessage = "請填寫您的手機號碼 (09XXXXXXXX)")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "請填寫您的姓名或姓氏")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="請選擇服務項目")]
        public string ServiceID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "請輸入服務地址")]
        public string Address { get; set; }

        [Required(ErrorMessage = "請輸入有效的電子郵件")]
        [EmailAddress(ErrorMessage = "請輸入有效的電子郵件")]
        public string Email { get; set; }

        public List<SelectListItem> OptionService { get; set; }
    }
}