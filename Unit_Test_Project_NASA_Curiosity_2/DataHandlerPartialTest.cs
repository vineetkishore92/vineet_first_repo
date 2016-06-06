using DataTransferBusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Test_Project_NASA_Curiosity_2
{
    
    
    /// <summary>
    ///This is a test class for DataHandlerPartialTest and is intended
    ///to contain all DataHandlerPartialTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataHandlerPartialTest
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
        ///A test for transferFromMarsToS1
        ///</summary>
        [TestMethod()]
        public void transferFromMarsToS1Test()
        {
            DataHandlerPartial target = new DataHandlerPartial(); // TODO: Initialize to an appropriate value
            int m1 = 1; // TODO: Initialize to an appropriate value
            int m2 = 1; // TODO: Initialize to an appropriate value
            int m3 = 1; // TODO: Initialize to an appropriate value
            string message = "test"; // TODO: Initialize to an appropriate value
            int expected = 48; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.transferFromMarsToS1(m1, m2, m3, message);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for transferFromS1ToS2
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DataTransferBusinessLayer.dll")]
        public void transferFromS1ToS2Test()
        {
            DataHandlerPartial_Accessor target = new DataHandlerPartial_Accessor(); // TODO: Initialize to an appropriate value
            int m2 = 1; // TODO: Initialize to an appropriate value
            int m3 = 1; // TODO: Initialize to an appropriate value
            List<KeyValuePair<int, string>> listToS1 = new List<KeyValuePair<int,string>>(); // TODO: Initialize to an appropriate value
            listToS1.Add(new KeyValuePair<int, string>(0,"test"));
            int expected = 44; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.transferFromS1ToS2(m2, m3, listToS1);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for transferFromS2ToS3
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DataTransferBusinessLayer.dll")]
        public void transferFromS2ToS3Test()
        {
            DataHandlerPartial_Accessor target = new DataHandlerPartial_Accessor(); // TODO: Initialize to an appropriate value
            int m3 = 1; // TODO: Initialize to an appropriate value
            List<KeyValuePair<int, string>> listToS2 = new List<KeyValuePair<int,string>>(); // TODO: Initialize to an appropriate value
            listToS2.Add(new KeyValuePair<int, string>(0, "test"));
            int expected = 24; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.transferFromS2ToS3(m3, listToS2);
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for transferFromS3ToNASA
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DataTransferBusinessLayer.dll")]
        public void transferFromS3ToNASATest()
        {
            DataHandlerPartial_Accessor target = new DataHandlerPartial_Accessor(); // TODO: Initialize to an appropriate value
            string message = "test"; // TODO: Initialize to an appropriate value
            int expected = 4; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.transferFromS3ToNASA(message);
            Assert.AreEqual(expected, actual);
        }
    }
}
