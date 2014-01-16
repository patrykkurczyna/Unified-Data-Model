using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Collections;
using System.Collections.Generic;

namespace TestUDM
{
    
    
    /// <summary>
    ///This is a test class for FilterCommandTest and is intended
    ///to contain all FilterCommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FilterCommandTest
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
            var table = new Mock<Table>();
            var table2 = new Mock<Table>();
            
            var cell1 = new Mock<Cell>();
            var cell2 = new Mock<Cell>();
            cell1.Setup(foo => foo.Content).Returns(1.0);
            cell2.Setup(foo => foo.Content).Returns(5.0);
            var cell3 = new Mock<Cell>();
            var cell4 = new Mock<Cell>();
            //var cell5 = new Mock<Cell>();
            //var cell6 = new Mock<Cell>();
            //var cell7 = new Mock<Cell>();
            //var cell8 = new Mock<Cell>();

            List<Cell> list1 = new List<Cell>();
            List<Cell> list2 = new List<Cell>();

            List<Cell> list3 = new List<Cell>();
            List<Cell> list4 = new List<Cell>();

            list1.Add(cell1.Object);
            list1.Add(cell2.Object);
            list2.Add(cell3.Object);
            list2.Add(cell4.Object);
            list3.Add(cell2.Object);
            list4.Add(cell4.Object);

            var column1 = new Mock<Column>();
            var column2 = new Mock<Column>();
            var column3 = new Mock<Column>();
            var column4 = new Mock<Column>();

            column1.Setup(foo => foo.Cells).Returns(list1);
            column2.Setup(foo => foo.Cells).Returns(list2);
            column3.Setup(foo => foo.Cells).Returns(list3);
            column4.Setup(foo => foo.Cells).Returns(list4);

            List<Column> columns1 = new List<Column>();
            List<Column> columns2 = new List<Column>();

            columns1.Add(column1.Object);
            columns1.Add(column2.Object);
            columns2.Add(column3.Object);
            columns2.Add(column4.Object);

            //tabela do filtrowania
            table.Setup(foo => foo.Columns).Returns(columns1);
            table2.Setup(foo => foo.Columns).Returns(columns2);

            FilterCommand.Del del = c => (double)c > 2.0;
            Command cmd = new FilterCommand(column1.Object, del);
            var result = cmd.Execute(table.Object);

            
            int n = table2.Object.Columns.Count;
            int m = result.Columns.Count;
            Assert.AreEqual(n, m);

            for (int i = 0; i < n; i++)
            {
                CollectionAssert.AreEqual(table2.Object.Columns[i].Cells, result.Columns[i].Cells);
            }
        }
    }
}
