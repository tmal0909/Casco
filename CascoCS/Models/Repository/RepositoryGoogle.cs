using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CascoCS.Models
{
    public class RepositoryGoogle
    {
        private static string UserName = ConfigurationManager.AppSettings["UserName"].ToString().Trim();
        private static string Password = ConfigurationManager.AppSettings["Password"].ToString().Trim();
        private static string Host = ConfigurationManager.AppSettings["Host"].ToString().Trim();
        private static int Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString().Trim());
        private static bool EnableSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"].ToString().Trim());
        private static string WebIndex = ConfigurationManager.AppSettings["WebIndex"].ToString().Trim();
        
        public static void Send(string Email, string Name)
        {
            // 驗證信箱
            if (string.IsNullOrEmpty(Email)) return;

            // 寄送郵件
            try
            {
                SmtpClient smtp = new SmtpClient();
                MailMessage mailMsg = new MailMessage();

                smtp.Host = Host;
                smtp.Port = Port;
                smtp.EnableSsl = EnableSSL;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(UserName, Password);

                mailMsg.To.Add(new MailAddress(Email));
                mailMsg.Subject = "好事多清潔服務 - 收到訂單";
                mailMsg.Body = string.Format("<div style=''><p>{0} 先生/小姐 您好 :<br><br>非常感謝您的預約，<br>我們將會盡快與您聯絡，<br>若有其他疑問請洽 (02) 8648 - 2536，<br>將有專員為您服務。<br><br><br><a href='{1}'>好事多清潔服務</a></p></div>", Name, WebIndex);
                mailMsg.From = new MailAddress(UserName.Trim());
                mailMsg.IsBodyHtml = true;

                smtp.Send(mailMsg);
            }
            catch (Exception ex)
            {
            }

            return;
        }
    }
}