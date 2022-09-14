using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Business.Utilities
{
    public static class Helper
    {
        #region Email Sender


        public static bool SendEmail(string userEmail, string msgArea, string subject)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("mmdvorxan123@gmail.com");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = msgArea;

            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("mmdvorxan123@gmail.com", "mtcmhdpnhofozdaj");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // log exception
            }
            return false;
        }


        #endregion
    }

    #region Roles

    public enum UserRoles
    {
        SuperAdmin,
        TrAdmin,
        AzAdmin,
        User
    }

    #endregion
}
