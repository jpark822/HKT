using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using DomainModel;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace HKTReceiptGenerator
{
    public class Emailer
    {
        public static void SendEmailWithBodyAsync(String body, string toEmailAddress)
        {
            Thread emailThread = new Thread(()=> SendEmailWithBody(body, toEmailAddress));
            emailThread.Start();
        }

        public static void SendEmailWithBody(String body, string toEmailAddress)
        {
            SimpleAES crypt = new SimpleAES();
            string fromaddress = crypt.DecryptString(ConfigurationManager.AppSettings["UserName"]);
            string password = crypt.DecryptString(ConfigurationManager.AppSettings["Password"]);
            if (fromaddress == "" || password == "")
            {
                MessageBox.Show("No HKT email credentials have been provided.");
                return;
            }

            string toaddress = toEmailAddress;
            MailMessage message = new MailMessage(fromaddress, toaddress);
            message.Subject = "Your e-Receipt From Hong Kong Tailors";
            message.Body = body;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(fromaddress, password);
            try
            {
                client.Send(message);
                MessageBox.Show("Done! E-mail was queued.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error sending your email. Please contact Jay with this message: " + ex.Message);
            }
        }

        //public static void SendBackupToEmail()
        //{
        //    SimpleAES crypt = new SimpleAES();
        //    string fromaddress = crypt.DecryptString(ConfigurationManager.AppSettings["UserName"]);
        //    string password = crypt.DecryptString(ConfigurationManager.AppSettings["Password"]);
        //    if (fromaddress == "" || password == "")
        //    {
        //        MessageBox.Show("No HKT email credentials have been provided.");
        //        return;
        //    }

        //    string toaddress = @"hktautoemailer@gmail.com";
        //    MailMessage message = new MailMessage(fromaddress, toaddress);
        //    message.Subject = "Backup For " + DateTime.Today.ToLongDateString();

        //    //add the db
        //    DirectoryInfo currentDirectoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
        //    currentDirectoryInfo = currentDirectoryInfo.Parent;
        //    currentDirectoryInfo = currentDirectoryInfo.Parent;
        //    currentDirectoryInfo = currentDirectoryInfo.Parent;
        //    String pathToDomainModel = currentDirectoryInfo.FullName;
        //    pathToDomainModel += "\\DomainModel\\HKTSQLiteDB.s3db";

        //    message.Attachments.Add(new Attachment(pathToDomainModel));
        //    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        //    client.EnableSsl = true;
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = new NetworkCredential(fromaddress, password);
        //    try
        //    {
        //        client.Send(message);
        //        MessageBox.Show("Done! Backup was sent to HKTAutoEmailer@gmailcom.");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("There was an error sending your email. Please contact Jay with this message: " + ex.Message);
        //    }
        //}
    }
}
