using RingRevenue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using Moq;

namespace CallCenterAPI.Test
{


    /// <summary>
    ///This is a test class for CallTest and is intended
    ///to contain all CallTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CallTest
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
        ///A test for Call Constructor
        ///</summary>
        [TestMethod()]
        public void CallConstructorTest()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("start_time_t", "84023452");
            parameters.Add("call_center_call_id", "991234567");
            parameters.Add("calling_number", "+1 8049274933");
            parameters.Add("sku_list", "dvd, cleaner");
            Call target = new Call(parameters);
            Assert.AreEqual(4, target.Parameters.Count); // target has set all parameters?
            // target parameters have correct keys?
            Assert.AreEqual(true, target.Parameters.ContainsKey("start_time_t"));
            Assert.AreEqual(true, target.Parameters.ContainsKey("call_center_call_id"));
            Assert.AreEqual(true, target.Parameters.ContainsKey("calling_number"));
            Assert.AreEqual(true, target.Parameters.ContainsKey("sku_list"));
            // target parameters have correct values?
            Assert.AreEqual(true, target.Parameters.ContainsValue("84023452"));
            Assert.AreEqual(true, target.Parameters.ContainsValue("991234567"));
            Assert.AreEqual(true, target.Parameters.ContainsValue("+1 8049274933"));
            Assert.AreEqual(true, target.Parameters.ContainsValue("dvd, cleaner"));
        }

        /// <summary>
        ///A test for ConvertToForm
        ///</summary>
        [TestMethod()]
        public void ConvertToFormTest()
        {
            // create a Call object w/the following parameters
            String[] a = { "DVD", "cleaner" };
            String[] b = { "2", "1" };
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("start_time_t", 1339721018);
            parameters.Add("call_center_call_id", 91234568);
            parameters.Add("duration_in_seconds", 200);
            parameters.Add("reason_code", "Terms&Conditions");
            parameters.Add("sale_currency", "USD");
            parameters.Add("sale_amount", 1.12);
            parameters.Add("email_address", "john@doe.com");
            parameters.Add("sku_list", a);
            parameters.Add("quantity_list", b);
            parameters.Add("calling_number", "+1 8889990000");
            Call target = new Call(parameters);

            string expected = "start_time_t=1339721018&call_center_call_id=91234568&duration_in_seconds=200&reason_code=Terms%26Conditions&sale_currency=USD&sale_amount=1.12&email_address=john%40doe.com&sku_list[]=DVD&sku_list[]=cleaner&quantity_list[]=2&quantity_list[]=1&calling_number=%2b1+8889990000";
            string actual = target.ConvertToForm(parameters);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        ///A test for request
        ///</summary>
        [TestMethod()]
        public void requestTest()
        {
            // create a new Call object w/the following parameters:
            String[] a = { "DVD", "cleaner" };
            String[] b = { "2", "1" };
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("start_time_t", 1339721018);
            parameters.Add("call_center_call_id", 91234568);
            parameters.Add("duration_in_seconds", 200);
            parameters.Add("reason_code", "Terms&Conditions");
            parameters.Add("sale_currency", "USD");
            parameters.Add("sale_amount", 1.12);
            parameters.Add("email_address", "john@doe.com");
            parameters.Add("sku_list", a);
            parameters.Add("quantity_list", b);
            parameters.Add("calling_number", "+1 8889990000");
            Call target = new Call(parameters);

            string method = "PUT";
            Dictionary<string, string> expected = null;
            Dictionary<string, string> actual = target.request(method);
            Assert.AreEqual(expected, actual);
        }

        /*
        /// <summary>
        ///A test for save
        ///</summary>
        [TestMethod()]
        public void saveTest()
        {
            Dictionary<string, object> parameters = null; // TODO: Initialize to an appropriate value
            Call target = new Call(parameters); // TODO: Initialize to an appropriate value
            Dictionary<string, string> expected = null; // TODO: Initialize to an appropriate value
            Dictionary<string, string> actual;
            actual = target.save();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
         * */
    }
}