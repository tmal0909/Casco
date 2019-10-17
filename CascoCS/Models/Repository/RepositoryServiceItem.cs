using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascoCS.Models
{
    public class RepositoryServiceItem
    {
        public static List<ServiceItem> Query()
        {
            string sql = string.Empty;
            List<ServiceItem> result = new List<ServiceItem>();

            sql = "select * from [Casco].[dbo].[ServiceItem] ";

            try
            {
                using(clsDBDapper db = new clsDBDapper())
                {
                    result = db.ToClass<ServiceItem>(sql).ToList();
                }
            }
            catch(Exception ex)
            {

            }

            return result;
        }
    }
}