using RingRevenue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            Dictionary<string, object> parameters = null; // TODO: Initialize to an appropriate value
            Call target = new Call(parameters);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
        /*
        /// <summary>
        ///A test for ConvertToForm
        ///</summary>
        [TestMethod()]
        public void ConvertToFormTest()
        {
            Dictionary<string, object> parameters = null; // TODO: Initialize to an appropriate value
            Call target = new Call(parameters); // TODO: Initialize to an appropriate value
            Dictionary<string, object> og_params = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ConvertToForm(og_params);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for request
        ///</summary>
        [TestMethod()]
        public void requestTest()
        {
            Dictionary<string, object> parameters = null; // TODO: Initialize to an appropriate value
            Call target = new Call(parameters); // TODO: Initialize to an appropriate value
            string method = string.Empty; // TODO: Initialize to an appropriate value
            Dictionary<string, string> expected = null; // TODO: Initialize to an appropriate value
            Dictionary<string, string> actual;
            actual = target.request(method);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

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