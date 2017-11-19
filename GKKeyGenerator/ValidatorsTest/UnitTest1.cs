using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validators;


namespace ValidatorsTest
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
            List<string> nipList = new List<string>();
            nipList.Add("1234567890");//0 ok
            nipList.Add("1234567891");
            nipList.Add("9542662860");//0 ok
            
            foreach (var nel in nipList)
            {
              Debug.WriteLine(Validator.IsValid(nel));
            }
            //assert.istrue
            //bool t =(Validator.IsValid("12345"));
        }

        [TestMethod]
        public void nextTest()
        {
            
        }
    }
}
