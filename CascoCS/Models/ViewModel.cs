using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascoCS.Models
{
    public class DBOperationResult
    {
        public DBOperationResult()
        {
            this.Status = true;
            this.Message = "預約成功，感謝您的預約，客服人員將與您聯繫。";
            this.Message = string.Empty;
        }

        public bool Status { get; set; }

        public string Message { get; set; }

        public string ErrorMessage { get; set; }
    }
}