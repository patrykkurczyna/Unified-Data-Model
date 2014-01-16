using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;

namespace TestUDM
{
    
    
    /// <summary>
    ///This is a test class for GroupCommandTest and is intended
    ///to contain all GroupCommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GroupCommandTest
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
        public void ExecuteTest()
        {
            var cell1 = new Mock<Cell>();
            var cell2 = new Mock<Cell>();
            var cell3 = new Mock<Cell>();
            cell1.Setup(foo => foo.Content).Returns("2011");
            cell2.Setup(foo => foo.Content).Returns("2011");
            cell3.Setup(foo => foo.Content).Returns("2012");

            var cell4 = new Mock<Cell>();
            var cell5 = new Mock<Cell>();
            var cell6 = new Mock<Cell>();
            cell4.Setup(foo => foo.Content).Returns(7);
            cell5.Setup(foo => foo.Content).Returns(8);
            cell6.Setup(foo => foo.Content).Returns(9);

            List<Cell> cells1 = new List<Cell>();
            List<Cell> cells2 = new List<Cell>();
            cells1.Add(cell1.Object);
            cells1.Add(cell2.Object);
            cells1.Add(cell3.Object);
            cells2.Add(cell4.Object);
            cells2.Add(cell5.Object);
            cells2.Add(cell6.Object);


            var column1 = new Mock<Column>();
            var column2 = new Mock<Column>();
            column1.Setup(foo => foo.Cells).Returns(cells1);
            column1.Setup(foo => foo.Type).Returns(DataType.DateDimension);
            column2.Setup(foo => foo.Cells).Returns(cells2);
            column2.Setup(foo => foo.Type).Returns(DataType.FloatFact);

            List<Column> columns = new List<Column>();
            columns.Add(column1.Object);
            columns.Add(column2.Object);

            var table = new Mock<Table>();
            table.Setup(foo => foo.Columns).Returns(columns);

            var agg = new Mock<Aggregation>();
            agg.Setup(foo => foo.GetAggregatedValue(It.IsAny<List<Cell>>())).Returns(5.0);

            Dictionary<Column, Aggregation> dict = new Dictionary<Column, Aggregation>();
            dict.Add(column2.Object, agg.Object);

            List<Column> gColumn = new List<Column>();
            gColumn.Add(column1.Object);
            Command cmd = new GroupCommand(gColumn, dict);

            var result = cmd.Execute(table.Object);

            //czego oczekujemy
            var column3 = new Mock<Column>();
            var column4 = new Mock<Column>();

            List<Cell> cells3 = new List<Cell>();
            cells3.Add(cell1.Object);
            cells3.Add(cell3.Object);

            var cellAgg = new Mock<Cell>();
            cellAgg.Setup(foo => foo.Content).Returns(5.0);

            List<Cell> cells4 = new List<Cell>();
            cells4.Add(cellAgg.Object);
            cells4.Add(cellAgg.Object);

            column3.Setup(foo => foo.Cells).Returns(cells3);
            column4.Setup(foo => foo.Cells).Returns(cells4);

            List<Column> columns3 = new List<Column>();
            columns3.Add(column3.Object);
            columns3.Add(column4.Object);

            var expected = new Mock<Table>();
            expected.Setup(foo => foo.Columns).Returns(columns3);

            //czy takie same
            int n = expected.Object.Columns.Count;
            int m = result.Columns.Count;
            Assert.AreEqual(n, m);
            for (int i = 0; i < n; i++)
            {
                int k = result.Columns[i].Cells.Count;
                int l = expected.Object.Columns[i].Cells.Count;
                Assert.AreEqual(k, l);
                for (int j = 0; j < k; j++)
                {
                    Assert.AreEqual(expected.Object.Columns[i].Cells[j].Content, result.Columns[i].Cells[j].Content);
                }
            }
        }
    }
}
