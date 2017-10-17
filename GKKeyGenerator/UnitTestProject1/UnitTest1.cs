using System;
using FGMailGenerator.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MailManager mailManager = new MailManager("smtp.wp.pl", 587, "Test", "TESTTET", "filipvirus@wp.pl","Filipvirus", "zombi3s@gmail.com" );
            mailManager.Send();
        }
    }
}
