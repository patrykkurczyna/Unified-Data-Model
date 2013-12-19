using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class GroupCommand : Command
    {
        protected List<Column> groupingColumns;
        protected Dictionary<Column,Aggregation> aggregatedColumns;

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

        public GroupCommand(List<Column> groupingColumns, Dictionary<Column,Aggregation> aggregatedColumns)
        {
            this.groupingColumns = groupingColumns;
            this.aggregatedColumns = aggregatedColumns;
        }

        public override Table Execute(Table table)
        {   
            foreach(Column column in groupingColumns)
            {
                if (column.Type != DataType.StringDimension && column.Type != DataType.DateDimension) throw new BadColumnsChooseForGroupingException();
            }
            foreach(Column column in aggregatedColumns.Keys)
            {
                if (column.Type == DataType.StringDimension || column.Type == DataType.DateDimension) throw new BadColumnsChooseForAggregationException();
            }
            if ((groupingColumns.Count + aggregatedColumns.Count) != table.Columns.Count)
                throw new AllColumnsShouldBeSelectedForGroupingException();

            List<Column> newColumns = new List<Column>();
            //List<Column> newAggregatedColumns = new List<Column>();

            

            foreach (Column gCol in groupingColumns)
            {
                Dictionary<Object,List<Column>> map = new Dictionary<Object,List<Column>>();
                for (int i = 0; i<gCol.Cells.Count; i++)
                {
                    Cell cell = gCol.Cells[i];
                    if (!map.ContainsKey(cell.Content))
                    {
                        List<Column> mapList = new List<Column>();
                
                        foreach (Column key in aggregatedColumns.Keys)
                        {
                            mapList.Add(new Column(key.Name,key.Type,new List<Cell>()));
                        }
                        map.Add(cell.Content, mapList);
                    }
                    List<Column> newAggregatedColumns = map[cell.Content];
                    for (int j = 0; j < aggregatedColumns.Count; j++)
                    {
                        newAggregatedColumns[j].AddCell(aggregatedColumns.Keys.ToList<Column>()[j].Cells[i]);
                    }
                    
                }
                int n = aggregatedColumns.Count;
                List<Column> groupedTableColumns = new List<Column>();
                List<Cell> cells = map.Keys.Select(content => new Cell(content)).ToList();
                groupedTableColumns.Add(new Column(gCol.Name,gCol.Type,cells));
                for (int i = 0; i < n; i++)
                {
                    Column column = aggregatedColumns.Keys.ToList<Column>()[i];
                    groupedTableColumns.Add(new Column(column.Name, column.Type));
                }
                //List<Cell> gCells = map.Keys.Select(content => new Cell(content)).ToList();
                //groupedTableColumns.Add(new Column(gCol.Name, gCol.Type, gCells));

                foreach (Object content in map.Keys)
                {
                    groupedTableColumns[0].AddCell(new Cell(content));
                    for (int i = 1; i < n+1; i++)
                    {
                        Column column = aggregatedColumns.Keys.ToList<Column>()[i-1];
                        Aggregation aggr = aggregatedColumns[column];
                        groupedTableColumns[i].AddCell(new Cell(aggr.GetAggregatedValue(map[content][i-1].Cells)));
                    }
                }

                table = new Table(table.Name, table, groupedTableColumns);
                
            }

            return table;
        }
    }
}
