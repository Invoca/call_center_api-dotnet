using RingRevenue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CallCenterAPI.Test
{


    /// <summary>
    ///This is a test class for CallCenterTest and is intended
    ///to contain all CallCenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CallCenterTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetAPIurl
        ///</summary>
        [TestMethod()]
        public void GetAPIurlTest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("CallCenterID", "1");
            dict.Add("APIVersion", "2010-04-22");
            dict.Add("APIUsername", "username@example.com");
            dict.Add("APIPassword", "password");
            CallCenter.config(dict);
            string expected = "http://api" + CallCenter.APInum.ToString() + ".ringrevenue.com:3000/api/2010-04-22/calls/1.xml"; // TODO: Initialize to an appropriate value
            string actual;
            actual = CallCenter.GetAPIurl();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void configTest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("CallCenterID", "1");
            dict.Add("APIVersion", "2010-04-22");
            dict.Add("APIUsername", "username@example.com");
            dict.Add("APIPassword", "password");
            CallCenter.config(dict);
            Assert.AreEqual(dict["CallCenterID"], CallCenter.CallCenterID);
            Assert.AreEqual(dict["APIVersion"], CallCenter.APIVersion);
            Assert.AreEqual(dict["APIUsername"], CallCenter.APIUsername);
            Assert.AreEqual(dict["APIPassword"], CallCenter.APIPassword);
        }
    }
}