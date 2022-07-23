using FASTrack.Utilities;
using System.Net.Mail;

namespace FASTrack.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="linkConfirm"></param>
        public static void SendRegister(string email, string subject, string linkConfirm)
        {
            int port = FastrackConfig.PORT;
            string host = FastrackConfig.HOST;
            string from = FastrackConfig.FROM;
            string user = FastrackConfig.USERNAME;
            string pass = FastrackConfig.PASSWORD;

            SmtpMailSender.Email(host, email, "", subject, from, "no-reply@atmel.com", user, pass, null, linkConfirm, null, MailType.Register, MailPriority.High);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="linkConfirm"></param>
        /// <param name="plainText"></param>
        public static void SendRecoverPassword(string email, string subject, string linkConfirm, string plainText)
        {
            int port = FastrackConfig.PORT;
            string host = FastrackConfig.HOST;
            string from = FastrackConfig.FROM;
            string user = FastrackConfig.USERNAME;
            string pass = FastrackConfig.PASSWORD;

            SmtpMailSender.Email(host, email, "", subject, from, "no-reply@atmel.com", user, pass, null, linkConfirm, plainText, MailType.RecoverPass, MailPriority.High);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void Send(string to, string subject, string body)
        {
            int port = FastrackConfig.PORT;
            string host = FastrackConfig.HOST;
            string from = FastrackConfig.FROM;
            string user = FastrackConfig.USERNAME;
            string pass = FastrackConfig.PASSWORD;
            SmtpMailSender.Email(host, to, body, subject, from, "no-reply@atmel.com", user, pass, null, null, null, MailType.Normal, MailPriority.Normal);
        }
    }
}