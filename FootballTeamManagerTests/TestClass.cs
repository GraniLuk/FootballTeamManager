using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagerTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            var emailClient = new EmailClient();
            emailClient.Send();
        }

        public class Email : IMessage {
            public string From { get; set; }
            public string To { get; set; }
            public string Subject { get; set; }
            public string Message { get; set; }
        }
    }

    public class EmailClient : IPost
    {
        public void Send()
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential()
                {
                    UserName = "postmaster@appfa642b7cb3bb48cda8fc6068d8fb2ec5.mailgun.org",
                    Password = "154c031f561b3be2a435faa7d076ed35"
                };
                client.Credentials = credential;
                client.Host = "smtp.mailgun.org";
                client.Port = 587;

                var message = new MailMessage()
                {
                    To = { new MailAddress("granica.lukasz@gmail.com")},
                    From = new MailAddress("orlik@footballteammanager.apphb.com"),
                    Subject = "Składy 24.03.2018",
                    Body = "Składy można sprawdzić na stronie http://footballteammanager.apphb.com/"
            };
                client.Send(message);
            }
                throw new NotImplementedException();
        }
    }

    public interface IPost
    {
        void Send();
    }

    public interface IMessage
    {
        string From { get; set; }
        string To { get; set; }
        string Subject { get; set; }
        string Message { get; set; }
        
    }
}
