using DataTransferBusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit_Test_Project_NASA_Curiosity_2
{
    
    
    /// <summary>
    ///This is a test class for MARS_Message_HandlerTest and is intended
    ///to contain all MARS_Message_HandlerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MARS_Message_HandlerTest
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
        ///A test for messageProcessor
        ///</summary>
        [TestMethod()]
        public void messageProcessorTest()
        {
            MARS_Message_Handler target = new MARS_Message_Handler(); // TODO: Initialize to an appropriate value
            string messageToBeTransferred = "test"; // TODO: Initialize to an appropriate value
            int m1 = 1; // TODO: Initialize to an appropriate value
            int m2 = 1; // TODO: Initialize to an appropriate value
            int m3 = 1; // TODO: Initialize to an appropriate value
            int expected = 48; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.messageProcessor(messageToBeTransferred, m1, m2, m3);
            Assert.AreEqual(expected, actual);
        }
    }
}
