using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Typesafe.Mailgun;

namespace FootballTeamManagerTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        [Category("SkipWhenLiveUnitTesting")]
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
            string domain = "appfa642b7cb3bb48cda8fc6068d8fb2ec5.mailgun.org";
            string api_key = "key-f143564a247580b4a84efbbb6498c95b";
            MailgunClient client = new MailgunClient(domain, api_key,3);
            client.SendMail(new System.Net.Mail.MailMessage("admin@" + domain, "granica.lukasz@gmail.com")
            {
                Subject = "Hello from mailgun",
                Body = "this is a test message from mailgun."
            });

         
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
