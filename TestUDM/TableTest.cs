using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace TestUDM
{
    
    
    /// <summary>
    ///This is a test class for TableTest and is intended
    ///to contain all TableTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TableTest
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
        ///A test for AddColumn
        ///</summary>
        [TestMethod()]
        public void AddColumnTest()
        {
            var column1 = new Mock<Column>();
            var column2 = new Mock<Column>();
            var column3 = new Mock<Column>();
            List<Column> columns = new List<Column>();
            columns.Add(column1.Object);
            columns.Add(column2.Object);

            Table table = new Table("Tabela", null, columns);

            List<Column> columnsCopy = new List<Column>();
            columnsCopy = columns.Select(column => column).ToList();

            columnsCopy.Add(column3.Object);
            table.AddColumn(column3.Object);

            CollectionAssert.Equals(columnsCopy, table.Columns);
        }

        /// <summary>
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            string _name = string.Empty; // TODO: Initialize to an appropriate value
            Table previous = null; // TODO: Initialize to an appropriate value
            List<Column> columns = null; // TODO: Initialize to an appropriate value
            Table target = new Table(_name, previous, columns); // TODO: Initialize to an appropriate value
            Command command = null; // TODO: Initialize to an appropriate value
            Table expected = null; // TODO: Initialize to an appropriate value
            Table actual;
            actual = target.Execute(command);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Normalize
        ///</summary>
        [TestMethod()]
        public void NormalizeTest()
        {
            string _name = string.Empty; // TODO: Initialize to an appropriate value
            Table previous = null; // TODO: Initialize to an appropriate value
            List<Column> columns = null; // TODO: Initialize to an appropriate value
            Table target = new Table(_name, previous, columns); // TODO: Initialize to an appropriate value
            Table expected = null; // TODO: Initialize to an appropriate value
            Table actual;
            actual = target.Normalize();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RemoveColumn
        ///</summary>
        [TestMethod()]
        public void RemoveColumnTest()
        {
            var column1 = new Mock<Column>();
            var column2 = new Mock<Column>();
            var column3 = new Mock<Column>();
            List<Column> columns = new List<Column>();
            columns.Add(column1.Object);
            columns.Add(column2.Object);
            columns.Add(column3.Object);

            Table table = new Table("Tabela", null, columns);

            List<Column> columnsCopy = null;// new List<Column>();
            //columnsCopy = columns.Select(column => column).ToList();

            //columnsCopy.Remove(column3.Object);
            //table.AddColumn(column3.Object);

            CollectionAssert.Equals(columnsCopy, table.Columns);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            string _name = string.Empty; // TODO: Initialize to an appropriate value
            Table previous = null; // TODO: Initialize to an appropriate value
            List<Column> columns = null; // TODO: Initialize to an appropriate value
            Table target = new Table(_name, previous, columns); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Undo
        ///</summary>
        [TestMethod()]
        public void UndoTest()
        {
            string _name = string.Empty; // TODO: Initialize to an appropriate value
            Table previous = null; // TODO: Initialize to an appropriate value
            List<Column> columns = null; // TODO: Initialize to an appropriate value
            Table target = new Table(_name, previous, columns); // TODO: Initialize to an appropriate value
            Table expected = null; // TODO: Initialize to an appropriate value
            Table actual;
            actual = target.Undo();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Columns
        ///</summary>
        [TestMethod()]
        public void ColumnsTest()
        {
            string _name = string.Empty; // TODO: Initialize to an appropriate value
            Table previous = null; // TODO: Initialize to an appropriate value
            List<Column> columns = null; // TODO: Initialize to an appropriate value
            Table target = new Table(_name, previous, columns); // TODO: Initialize to an appropriate value
            List<Column> expected = null; // TODO: Initialize to an appropriate value
            List<Column> actual;
            target.Columns = expected;
            actual = target.Columns;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            string _name = string.Empty; // TODO: Initialize to an appropriate value
            Table previous = null; // TODO: Initialize to an appropriate value
            List<Column> columns = null; // TODO: Initialize to an appropriate value
            Table target = new Table(_name, previous, columns); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
