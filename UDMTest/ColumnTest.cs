using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UDMTest
{
    
    
    /// <summary>
    ///This is a test class for ColumnTest and is intended
    ///to contain all ColumnTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ColumnTest
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
        ///A test for Column`1 Constructor
        ///</summary>
        public void ColumnConstructorTestHelper<T>()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            List<Cell<T>> cells = null; // TODO: Initialize to an appropriate value
            DataType type = new DataType(); // TODO: Initialize to an appropriate value
            Column<T> target = new Column<T>(name, cells, type);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void ColumnConstructorTest()
        {
            ColumnConstructorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for AddCell
        ///</summary>
        public void AddCellTestHelper<T>()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            List<Cell<T>> cells = null; // TODO: Initialize to an appropriate value
            DataType type = new DataType(); // TODO: Initialize to an appropriate value
            Column<T> target = new Column<T>(name, cells, type); // TODO: Initialize to an appropriate value
            Cell<T> cell = null; // TODO: Initialize to an appropriate value
            target.AddCell(cell);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void AddCellTest()
        {
            AddCellTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for RemoveCell
        ///</summary>
        public void RemoveCellTestHelper<T>()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            List<Cell<T>> cells = null; // TODO: Initialize to an appropriate value
            DataType type = new DataType(); // TODO: Initialize to an appropriate value
            Column<T> target = new Column<T>(name, cells, type); // TODO: Initialize to an appropriate value
            Cell<T> cell = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.RemoveCell(cell);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void RemoveCellTest()
        {
            RemoveCellTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Cells
        ///</summary>
        public void CellsTestHelper<T>()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            List<Cell<T>> cells = null; // TODO: Initialize to an appropriate value
            DataType type = new DataType(); // TODO: Initialize to an appropriate value
            Column<T> target = new Column<T>(name, cells, type); // TODO: Initialize to an appropriate value
            List<Cell<T>> expected = null; // TODO: Initialize to an appropriate value
            List<Cell<T>> actual;
            target.Cells = expected;
            actual = target.Cells;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void CellsTest()
        {
            CellsTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        public void NameTestHelper<T>()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            List<Cell<T>> cells = null; // TODO: Initialize to an appropriate value
            DataType type = new DataType(); // TODO: Initialize to an appropriate value
            Column<T> target = new Column<T>(name, cells, type); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void NameTest()
        {
            NameTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        public void TypeTestHelper<T>()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            List<Cell<T>> cells = null; // TODO: Initialize to an appropriate value
            DataType type = new DataType(); // TODO: Initialize to an appropriate value
            Column<T> target = new Column<T>(name, cells, type); // TODO: Initialize to an appropriate value
            DataType actual;
            actual = target.Type;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void TypeTest()
        {
            TypeTestHelper<GenericParameterHelper>();
        }
    }
}
