﻿using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UDMTest
{
    
    
    /// <summary>
    ///This is a test class for CellTest and is intended
    ///to contain all CellTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CellTest
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
        ///A test for Cell`1 Constructor
        ///</summary>
        public void CellConstructorTestHelper<T>()
        {
            T content = default(T); // TODO: Initialize to an appropriate value
            Cell<T> target = new Cell<T>(content);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void CellConstructorTest()
        {
            CellConstructorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Content
        ///</summary>
        public void ContentTestHelper<T>()
        {
            T content = default(T); // TODO: Initialize to an appropriate value
            Cell<T> target = new Cell<T>(content); // TODO: Initialize to an appropriate value
            T expected = default(T); // TODO: Initialize to an appropriate value
            T actual;
            target.Content = expected;
            actual = target.Content;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void ContentTest()
        {
            ContentTestHelper<GenericParameterHelper>();
        }
    }
}
