using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace TestUDM
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
        ///A test for AddCell
        ///</summary>
        [TestMethod()]
        public void AddCellTest()
        {
            var cell1 = new Mock<Cell>();
            var cell2 = new Mock<Cell>();
            var cell3 = new Mock<Cell>();
            List<Cell> cells = new List<Cell>();
            cells.Add(cell1.Object);
            cells.Add(cell2.Object);
            cells.Add(cell3.Object);

            Column column = new Column("Kolumna", DataType.IntegerFact, cells);

            List<Cell> cellsCopy = new List<Cell>();
            cellsCopy = cells.Select(cell => cell).ToList();

            cellsCopy.Add(cell3.Object);
            column.AddCell(cell3.Object);

            CollectionAssert.AreEqual(cellsCopy, column.Cells);
        }

        /// <summary>
        ///A test for RemoveCell
        ///</summary>
        [TestMethod()]
        public void RemoveCellTest()
        {
            var cell1 = new Mock<Cell>();
            var cell2 = new Mock<Cell>();
            var cell3 = new Mock<Cell>();
            List<Cell> cells = new List<Cell>();
            cells.Add(cell1.Object);
            cells.Add(cell2.Object);
            cells.Add(cell3.Object);

            Column column = new Column("Kolumna", DataType.IntegerFact, cells);

            List<Cell> cellsCopy = new List<Cell>();
            cellsCopy = cells.Select(cell => cell).ToList();

            cellsCopy.Remove(cell3.Object);
            column.RemoveCell(cell3.Object);

            CollectionAssert.AreEqual(cellsCopy,column.Cells);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            //kolumna integerów
            string name = "Nazwa";
            List<Cell> cells = new List<Cell>();
            var cell1 = new Mock<Cell>();
            var cell2 = new Mock<Cell>();
            var cell3 = new Mock<Cell>();
            var cell4 = new Mock<Cell>();
            cell1.Setup(foo => foo.ToString()).Returns("5");
            cell2.Setup(foo => foo.ToString()).Returns("6");
            cell3.Setup(foo => foo.ToString()).Returns("7");
            cell4.Setup(foo => foo.ToString()).Returns("1");
            cells.Add(cell1.Object);
            cells.Add(cell2.Object);
            cells.Add(cell3.Object);
            cells.Add(cell4.Object);
            Column target = new Column(name, DataType.IntegerFact, cells);
            string expected = name + "\n5 6 7 1 ";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            //kolumna stringów
            cell1.Setup(foo => foo.ToString()).Returns("pięć");
            cell2.Setup(foo => foo.ToString()).Returns("sześć");
            cell3.Setup(foo => foo.ToString()).Returns("siedem");
            cell4.Setup(foo => foo.ToString()).Returns("jeden");
            cells = new List<Cell>();
            cells.Add(cell1.Object);
            cells.Add(cell2.Object);
            cells.Add(cell3.Object);
            cells.Add(cell4.Object);
            target = new Column(name, DataType.StringDimension, cells);
            expected = name + "\npięć sześć siedem jeden ";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Cells
        ///</summary>
        [TestMethod()]
        public void CellsTest()
        {
            var cell1 = new Mock<Cell>();
            var cell2 = new Mock<Cell>();
            List<Cell> cells = new List<Cell>();
            cells.Add(cell1.Object);
            cells.Add(cell2.Object);
            Column column = new Column("Kolumna", DataType.IntegerFact, cells);
            Assert.AreEqual(cells,column.Cells);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            Column column = new Column("Nazwa", DataType.StringDimension);
            Assert.AreEqual("Nazwa", column.Name);
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        public void TypeTest()
        {
            Column column = new Column("Nazwa", DataType.StringDimension);
            Assert.AreEqual(DataType.StringDimension, column.Type);

            column = new Column("Nazwa", DataType.IntegerFact);
            Assert.AreEqual(DataType.IntegerFact, column.Type);

        }
    }
}
