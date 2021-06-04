using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using Spectre.Console;

namespace TiConsoleUtils.SystemInfo.Backend.SendMessages
{
    public static class SendEmail
    {
        public static bool SendMessage(string id, string file = "")
        {
            try
            {
                var from = new MailAddress("TiConsoleUtils.SystemInfo@gmail.com", "TiConsoleUtils.SystemInfo");
                var to = new MailAddress("andrey.timofeev.and37@gmail.com");
                var message = new MailMessage(from, to)
                {
                    Subject = $"{id} - TiConsoleUtils.SystemInfo",
                    Body = $"<h1>TiConsoleUtils.SystemInfo. Система - {id}</h2>",
                    IsBodyHtml = true,
                };

                if (file != "" && File.Exists(file))
                    message.Attachments.Add(new Attachment(file));
                
                var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("TiConsoleUtils.SystemInfo@gmail.com", "5Jp-vTM-W6r-cHh"),
                    EnableSsl = true
                };

                smtp.Send(message);
            
                return true;
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteException(ex);
                return false;
            }
        }
    }
}