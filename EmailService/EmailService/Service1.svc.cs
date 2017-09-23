using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmailService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        
        public void SendEmail(string FromAddress, string FromPassword, string ToAddress, string Subject, string Body)
        {
            var client = new SmtpClient();

            MailMessage Message = new MailMessage(FromAddress, ToAddress);
            Message.Subject = Subject;
            Message.Body = Body;

            if (FromAddress.ToLower().Contains("@gmail.com"))
            {
                client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(FromAddress, FromPassword),
                    EnableSsl = true
                };
            }
            else if (FromAddress.ToLower().Contains("@yahoo.com"))
            {
                client = new SmtpClient("smtp.mail.yahoo.com", 587)
                {
                    Credentials = new NetworkCredential(FromAddress, FromPassword),
                    EnableSsl = true
                };
            }
            else if (FromAddress.ToLower().Contains("@hotmail.com"))
            {
                client = new SmtpClient("smtp.live.com", 25)
                {
                    Credentials = new NetworkCredential(FromAddress, FromPassword),
                    EnableSsl = true
                };
            }
            else
            {
                // RETURN ERROR
                // ONLY SUPPORTED EMAIL SERVICES: gmail, yahoo, hotmail
            }

            try
            {
                client.Send(Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
