using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Dapper;

namespace CascoCS.Models
{
    public class RepositoryOrder
    {
        public static DBOperationResult Insert(ReservationMD Data)
        {
            DBOperationResult result = new DBOperationResult();
            DynamicParameters pars = new DynamicParameters();
            DateTime processTime = DateTime.Now;
            long defaultEmployeeID = Convert.ToInt64(ConfigurationManager.AppSettings["DefaultEmployeeID"].ToString().Trim());
            string sql = string.Empty;

            sql = "insert into [Casco].[dbo].[Order] ";
            sql += "(Name, Phone, Address, ServiceID, EMail, OrderStatus, ReservationDate, Amount, CostManPower, CostMaterial, ServiceDate, Note, DirectorID, IntroducerID, UpdateTime, UpdateUserID) ";
            sql += "values(@Name, @Phone, @Address, @ServiceID, @EMail, @OrderStatus, @ReservationDate, @Amount, @CostManPower, @CostMaterial, @ServiceDate, @Note, @DirectorID, @IntroducerID, @UpdateTime, @UpdateUserID) ";

            pars.Add("@Name", Data.Name.Trim());
            pars.Add("@Phone", Data.Phone.Trim());
            pars.Add("@Address", Data.Address.Trim());
            pars.Add("@ServiceID", Data.ServiceID.Trim());
            pars.Add("@EMail", Data.Email.Trim());
            pars.Add("@OrderStatus", "聯繫中");
            pars.Add("@ReservationDate", processTime);
            pars.Add("@Amount", null);
            pars.Add("@CostManPower", null);
            pars.Add("@CostMaterial", null);
            pars.Add("@ServiceDate", null);
            pars.Add("@Note", null);
            pars.Add("@DirectorID", null);
            pars.Add("@IntroducerID", defaultEmployeeID);
            pars.Add("@UpdateTime", processTime);
            pars.Add("@UpdateUserID", defaultEmployeeID);

            try
            {
                using (clsDBDapper db = new clsDBDapper())
                {
                    if (!db.ToExecute(sql, pars)) throw new Exception("訂單新增失敗");
                    RepositoryGoogle.Send(Data.Email, Data.Name);    
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "預約失敗 : 請重新送出或洽詢 (02) 8648 - 2536";
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}