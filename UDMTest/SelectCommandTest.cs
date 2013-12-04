using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using NMock2;

namespace UDMTest
{
    
    
    /// <summary>
    ///This is a test class for SelectCommandTest and is intended
    ///to contain all SelectCommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SelectCommandTest
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
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteNullTest()
        {
            List<Column<object>> selectedColumns = null; 
            SelectCommand target = new SelectCommand(selectedColumns); // TODO: Initialize to an appropriate value
            Table table = null; // TODO: Initialize to an appropriate value
            Table expected = null; // TODO: Initialize to an appropriate value
            Table actual;
            actual = target.Execute(table);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SelectCommand Constructor
        ///</summary>
        [TestMethod()]
        public void SelectCommandConstructorTest()
        {
            List<Column<object>> selectedColumns = null; // TODO: Initialize to an appropriate value
            SelectCommand target = new SelectCommand(selectedColumns);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
