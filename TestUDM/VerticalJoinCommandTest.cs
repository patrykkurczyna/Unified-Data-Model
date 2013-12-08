﻿using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestUDM
{
    
    
    /// <summary>
    ///This is a test class for VerticalJoinCommandTest and is intended
    ///to contain all VerticalJoinCommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VerticalJoinCommandTest
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
        ///A test for VerticalJoinCommand Constructor
        ///</summary>
        [TestMethod()]
        public void VerticalJoinCommandConstructorTest()
        {
            Table table = null; // TODO: Initialize to an appropriate value
            VerticalJoinCommand target = new VerticalJoinCommand(table);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            Table table = null; // TODO: Initialize to an appropriate value
            VerticalJoinCommand target = new VerticalJoinCommand(table); // TODO: Initialize to an appropriate value
            Table firstTable = null; // TODO: Initialize to an appropriate value
            Table expected = null; // TODO: Initialize to an appropriate value
            Table actual;
            actual = target.Execute(firstTable);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
