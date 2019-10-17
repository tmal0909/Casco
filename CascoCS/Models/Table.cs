using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascoCS.Models
{
    // 服務項目
    public class ServiceItem
    {
        public long ID { get; set; }

        public string Service { get; set; }

        public string Note { get; set; }
    }

    // 客戶清單
    public class Customer
    {
        public long ID { get; set; }

        public string Phone { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string EMail { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}