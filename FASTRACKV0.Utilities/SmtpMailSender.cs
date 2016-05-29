﻿// ***********************************************************************
// Assembly         : FASTrack
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-13-2016
// ***********************************************************************
// <copyright file="SmtpMailSender.cs" company="Atmel">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// **********************************************************************

using System.Diagnostics;
using System.Net.Mail;
using System.Text;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public class SmtpMailSender
    {
        /// <summary>
        /// Sends and email
        /// </summary>
        /// <param name="to">Message to address</param>
        /// <param name="body">Text of message to send</param>
        /// <param name="subject">Subject line of message</param>
        /// <param name="fromAddress">Message from address</param>
        /// <param name="fromDisplay">Display name for "message from address"</param>
        /// <param name="credentialUser">User whose credentials are used for message send</param>
        /// <param name="credentialPassword">User password used for message send</param>
        /// <param name="attachments">Optional attachments for message</param>
        public static void Email(string mailServerAddress,
                                 string toAddress,
                                 string body,
                                 string subject,
                                 string fromAddress,
                                 string fromDisplay,
                                 string credentialUser,
                                 string credentialPassword,
                                 MailAttachment[] attachments,
                                 string linkConfirm = null,
                                 string passPlainText = null,
                                 MailType mailType = MailType.Normal,
                                 MailPriority mailpriority = MailPriority.Normal)
        {
            string host = mailServerAddress;
            body = UpgradeEmailFormat(body, linkConfirm, passPlainText, mailType);
            try
            {
                MailMessage mail = new MailMessage() { Body = body, IsBodyHtml = true };

                string[] toArray = toAddress.Split(';');

                foreach (string to in toArray)
                {
                    mail.To.Add(new MailAddress(to.Trim()));
                }

                mail.From = new MailAddress(fromAddress, fromDisplay, Encoding.UTF8);
                mail.Subject = subject;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Priority = mailpriority;

                using (SmtpClient smtp = new SmtpClient())
                {

                    // This is necessary for gmail
                    //smtp.EnableSsl = true;
                    //smtp.Credentials = new System.Net.NetworkCredential(credentialUser, credentialPassword);

                    smtp.Host = host;
                    smtp.Send(mail);
                }
            }
            catch
            {
                StringBuilder sb = new StringBuilder(1024);
                sb.Append("\\nTo:" + toAddress);
                sb.Append("\\nbody:" + body);
                sb.Append("\\nsubject:" + subject);
                sb.Append("\\nfromAddress:" + fromAddress);
                sb.Append("\\nfromDisplay:" + fromDisplay);
                sb.Append("\\ncredentialUser:" + credentialUser);
                sb.Append("\\ncredentialPasswordto:" + credentialPassword);
                sb.Append("\\nHosting:" + host);
                Debug.Print(sb.ToString());
            }
        }

        /// <summary>
        /// Upgrades the email format.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="linkConfirm">The link confirm.</param>
        /// <param name="passPlainText">The pass plain text.</param>
        /// <param name="mailType">Type of the mail.</param>
        /// <returns></returns>
        private static string UpgradeEmailFormat(string body, string linkConfirm, string passPlainText, MailType mailType)
        {
            string ebody = body;
            // This has to be implemented as needed. Currently doing nothing!
            switch (mailType)
            {
                case MailType.Normal:
                    ebody = body;
                    break;
                case MailType.Register:
                    ebody = SampleRegisterBody(linkConfirm);
                    break;
                case MailType.RecoverPass:
                    ebody = SampleRecoverBody(linkConfirm, passPlainText);
                    break;
            }
            return ebody;
        }

        /// <summary>
        /// Samples the register body.
        /// </summary>
        /// <param name="linkConfirm">The link confirm.</param>
        /// <returns></returns>
        private static string SampleRegisterBody(string linkConfirm)
        {
            StringBuilder strBuilderBody = new StringBuilder();
            strBuilderBody.AppendLine("<table border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse;background-color:#fff;border:solid 1px #ededed!important' width='100%'>");
            strBuilderBody.AppendLine(" <tbody>");
            strBuilderBody.AppendLine("     <tr>");
            strBuilderBody.AppendLine("         <td>");
            strBuilderBody.AppendLine("             <table align='center' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse' width='100%'>");
            strBuilderBody.AppendLine("                 <tbody>");
            strBuilderBody.AppendLine("                     <tr>");
            strBuilderBody.AppendLine("                         <td align='center' style='padding:55px 10px 30px'>");
            strBuilderBody.AppendLine("                             <h2 style='margin:0;font-size:23px;font-weight:400;color:#2e3645'>Email Confirmation</h2>");
            strBuilderBody.AppendLine("                         </td>");
            strBuilderBody.AppendLine("                     </tr>");
            strBuilderBody.AppendLine("                     <tr>");
            strBuilderBody.AppendLine("                         <td align='center' style='padding-bottom:30px'>");
            strBuilderBody.AppendLine("                             <p style='font-size:15px;font-weight:300;color:#a5a5a5;line-height:1.4;margin:0 10px'>Please confirm your email address and agree to our Terms of Service. By clicking on the following link, you are agreeing to FASTrack </p>");
            strBuilderBody.AppendLine("                         </td>");
            strBuilderBody.AppendLine("                     </tr>");
            strBuilderBody.AppendLine("                 </tbody>");
            strBuilderBody.AppendLine("             </table>");
            strBuilderBody.AppendLine("         </td>");
            strBuilderBody.AppendLine("     </tr>");
            strBuilderBody.AppendLine("     <tr>");
            strBuilderBody.AppendLine("         <td style='padding-bottom:40px;border-bottom:1px solid #ededed'>");
            strBuilderBody.AppendLine("             <table align='center' border='0' cellpadding='0' cellspacing='0' style='height:45px;margin:0 auto;table-layout:fixed' width='280'>");
            strBuilderBody.AppendLine("                 <tbody>");
            strBuilderBody.AppendLine("                     <tr>");
            strBuilderBody.AppendLine("                         <td align='center' bgcolor='#3bca96'><a href=" + linkConfirm + " style='font-size:13px;color:#ffffff;background-color:#3bca96;text-decoration:none;text-decoration:none;padding:11px 44px 10px;border:1px solid #3bca96;display:inline-block' target='_blank'>Confirm Your Email Address</a></td>");
            strBuilderBody.AppendLine("                     </tr>");
            strBuilderBody.AppendLine("                 </tbody>");
            strBuilderBody.AppendLine("             </table>");
            strBuilderBody.AppendLine("         </td>");
            strBuilderBody.AppendLine("     </tr>");
            strBuilderBody.AppendLine(" </tbody>");
            strBuilderBody.AppendLine("</table>");
            string body = strBuilderBody.ToString();
            return body;
        }

        /// <summary>
        /// Samples the recover body.
        /// </summary>
        /// <param name="linkConfirm">The link confirm.</param>
        /// <param name="passPlainText">The pass plain text.</param>
        /// <returns></returns>
        private static string SampleRecoverBody(string linkConfirm, string passPlainText)
        {
            StringBuilder strBuilderBody = new StringBuilder();
            strBuilderBody.AppendLine("<table border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse;background-color:#fff;border:solid 1px #ededed!important' width='100%'>");
            strBuilderBody.AppendLine(" <tbody>");
            strBuilderBody.AppendLine("     <tr>");
            strBuilderBody.AppendLine("         <td>");
            strBuilderBody.AppendLine("             <table align='center' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse' width='100%'>");
            strBuilderBody.AppendLine("                 <tbody>");
            strBuilderBody.AppendLine("                     <tr>");
            strBuilderBody.AppendLine("                         <td align='center' style='padding-bottom:30px'>");
            strBuilderBody.AppendLine("                             <p style='font-size:15px;font-weight:300;line-height:1.4;margin:0 10px'>Your new password is <strong>" + passPlainText + "</strong>." +
                " Please use this password to login, then change your password again. <a href='" + linkConfirm + "' target='_blank'>Click here</a> to go to login page.</p>");
            strBuilderBody.AppendLine("                         </td>");
            strBuilderBody.AppendLine("                     </tr>");
            strBuilderBody.AppendLine("                 </tbody>");
            strBuilderBody.AppendLine("             </table>");
            strBuilderBody.AppendLine("         </td>");
            strBuilderBody.AppendLine("     </tr>");
            strBuilderBody.AppendLine(" </tbody>");
            strBuilderBody.AppendLine("</table>");
            string body = strBuilderBody.ToString();
            return body;
        }
    }
}
