using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class GroupCommand : Command
    {
        protected List<Column> groupingColumns;
        protected Dictionary<Column, Aggregation> aggregatedColumns;

        public class AllColumnsShouldBeSelectedForGroupingException : Exception
        {
            public AllColumnsShouldBeSelectedForGroupingException() : base("Do grupowania trzeba wybrać wszystkie kolumny z tabeli!") { }
        }

        public class BadColumnsChooseForAggregationException : Exception
        {
            public BadColumnsChooseForAggregationException() : base("Nie można agregować kolumn typu WYMIAR") { }
        }

        public class BadColumnsChooseForGroupingException : Exception
        {
            public BadColumnsChooseForGroupingException() : base("Nie można grupować po kolumnach typu FAKT") { }
        }

        public GroupCommand(List<Column> groupingColumns, Dictionary<Column, Aggregation> aggregatedColumns)
        {
            this.groupingColumns = groupingColumns;
            this.aggregatedColumns = aggregatedColumns;
        }

        private class ListComparer<T> : IEqualityComparer<List<T>>
        {
            public bool Equals(List<T> x, List<T> y)
            {
                return x.SequenceEqual(y);
            }

            public int GetHashCode(List<T> obj)
            {
                int hashcode = 0;
                foreach (T t in obj)
                {
                    hashcode ^= t.GetHashCode();
                }
                return hashcode;
            }
        }

        public override Table Execute(Table table)
        {
            foreach (Column column in groupingColumns)
            {
                if (column.Type != DataType.StringDimension && column.Type != DataType.DateDimension) throw new BadColumnsChooseForGroupingException();
            }
            foreach (Column column in aggregatedColumns.Keys)
            {
                if (column.Type == DataType.StringDimension || column.Type == DataType.DateDimension) throw new BadColumnsChooseForAggregationException();
            }
            if ((groupingColumns.Count + aggregatedColumns.Count) != table.Columns.Count)
                throw new AllColumnsShouldBeSelectedForGroupingException();

            List<Column> newColumns = new List<Column>();
            //List<Column> newAggregatedColumns = new List<Column>();



            int n = groupingColumns[0].Cells.Count;
            Dictionary<List<String>, List<Column>> map = new Dictionary<List<String>, List<Column>>(new ListComparer<String>());
            for (int i = 0; i < n; i++)
            {
                List<String> cell = new List<String>();
                foreach (Column gCol in groupingColumns)
                {
                    cell.Add(gCol.Cells[i].Content.ToString());
                }
                //Cell cell = gCol.Cells[i];

                if (!map.ContainsKey(cell))
                {
                    List<Column> mapList = new List<Column>();

                    foreach (Column key in aggregatedColumns.Keys)
                    {
                        mapList.Add(new Column(key.Name, key.Type, new List<Cell>()));
                    }
                    map.Add(cell, mapList);
                }

                List<Column> newAggregatedColumns = map[cell];
                for (int j = 0; j < aggregatedColumns.Count; j++)
                {
                    newAggregatedColumns[j].AddCell(aggregatedColumns.Keys.ToList<Column>()[j].Cells[i]);
                }

            }

            List<Column> groupedTableColumns = new List<Column>();
            List<Cell> cells = map.Keys.Select(content => new Cell(content)).ToList();

            foreach (Column gCol in groupingColumns)
            {
                groupedTableColumns.Add(new Column(gCol.Name, gCol.Type, new List<Cell>()));
            }
            foreach (List<String> l in map.Keys.ToList<List<String>>())
            {
                for (int i = 0; i < l.Count; i++)
                {
                    groupedTableColumns[i].AddCell(new Cell(l[i]));
                }
            }

            int m = aggregatedColumns.Count;
            for (int i = 0; i < m; i++)
            {
                Column column = aggregatedColumns.Keys.ToList<Column>()[i];
                string name = column.Name + " - " + aggregatedColumns[column].ToString();
                groupedTableColumns.Add(new Column(name, column.Type));
            }
            //List<Cell> gCells = map.Keys.Select(content => new Cell(content)).ToList();
            //groupedTableColumns.Add(new Column(gCol.Name, gCol.Type, gCells));

            int k = groupingColumns.Count;
            foreach (List<String> content in map.Keys)
            {

                for (int i = 1; i < m + 1; i++)
                {
                    Column column = aggregatedColumns.Keys.ToList<Column>()[i - 1];
                    Aggregation aggr = aggregatedColumns[column];
                    groupedTableColumns[i + k - 1].AddCell(new Cell(aggr.GetAggregatedValue(map[content][i - 1].Cells)));
                }
            }

            table = new Table(table.Name, table, groupedTableColumns);



            return table;
        }
    }
}
