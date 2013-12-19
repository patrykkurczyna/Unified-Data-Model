﻿using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;

namespace TestUDM
{
    
    
    /// <summary>
    ///This is a test class for MaxAggregationTest and is intended
    ///to contain all MaxAggregationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MaxAggregationTest
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
        ///A test for GetAggregatedValue
        ///</summary>
        [TestMethod()]
        public void GetAggregatedValueTest()
        {
            var cell1 = new Mock<Cell>();
            var cell2 = new Mock<Cell>();
            var cell3 = new Mock<Cell>();
            var cell4 = new Mock<Cell>();
            cell1.Setup(foo => foo.Content).Returns((double)0.6);
            cell2.Setup(foo => foo.Content).Returns((double)3);
            cell3.Setup(foo => foo.Content).Returns((double)0.6);
            cell4.Setup(foo => foo.Content).Returns((double)5);
            List<Cell> cells = new List<Cell>();
            cells.Add(cell1.Object);
            cells.Add(cell2.Object);
            cells.Add(cell3.Object);
            MaxAggregation target = new MaxAggregation();
            double expected = 3;
            double actual;
            actual = (double)target.GetAggregatedValue(cells);
            Assert.AreEqual(expected, actual);

            cells.Add(cell4.Object);
            expected = 5;
            actual = (double)target.GetAggregatedValue(cells);
            Assert.AreEqual(expected, actual);
        }
    }
}
