using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Net.Mail;


namespace ATP.Kiosk.Common
{
    public class EmailToCCBCCList
    {
        public int? ServiceTypeId { get; set; }
        public string EmailGroupCode { get; set; }
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public string EmailBCC { get; set; }
        public string ShortName { get; set; }
        public string EmailDescription { get; set; }
        public System.Nullable<decimal> Cost { get; set; }
    }

    public class MailHelper
    {
        public MailHelper()
        {
            MailSmtpHost = ConfigurationManager.AppSettings["SMTPHostServer"];
            MailSmtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPHostServerPort"]);
            MailSmtpUsername = ConfigurationManager.AppSettings["SMTPServerUserId"];
            MailSmtpPassword = ConfigurationManager.AppSettings["SMTPServerUserPwd"];
            MailFrom = ConfigurationManager.AppSettings["AdamSupportTeam"];
        }
        public string MailSmtpHost { get; set; }
        public int MailSmtpPort { get; set; }
        public string MailSmtpUsername { get; set; }
        public string MailSmtpPassword { get; set; }

        public string MailFrom { get; set; }
        public bool IsEnableSsl { get; set; }
        public string SendMailTo { get; set; }
        public string SendMailcc { get; set; }
        public string MailSubject { get; set; }
        public bool IsSmtpCredRequired { get; set; }
        public string MailBody { get; set; }
        public AlternateView AlternateViews { get; set; }

        public bool SendEmail()
        {

            var smtpClient = new SmtpClient(MailSmtpHost) { Port = MailSmtpPort };

            // Create the credentials to login to the gmail account associated with my custom domain
            var sendEmailsFrom = MailSmtpUsername;
            var sendEmailsFromPassword = MailSmtpPassword;

            var cred = new NetworkCredential(sendEmailsFrom, sendEmailsFromPassword);

            if (IsEnableSsl)
            {
                smtpClient.EnableSsl = true;
            }


            //smtpClient.Host = "Treasuryhbgdc2.acchbg1.Treasurysystems.com";
            //smtpClient.Port = 25;

            smtpClient.Credentials = cred;


            //smtpClient.Port = MailSmtpPort;
            //smtpClient.UseDefaultCredentials = true;

            var mail = new MailMessage { IsBodyHtml = true, From = new MailAddress(MailFrom) };

            mail.To.Add(SendMailTo);

            if (!string.IsNullOrEmpty(SendMailcc))
                mail.CC.Add(SendMailcc);

            mail.Subject = MailSubject;
           // mail.Body = MailBody;
            mail.AlternateViews.Add( AlternateViews);

            if (IsSmtpCredRequired)
            {
                smtpClient.Credentials = new NetworkCredential(MailSmtpUsername, MailSmtpPassword);
            }



            smtpClient.Send(mail);

            return true;
        }
    }
}


