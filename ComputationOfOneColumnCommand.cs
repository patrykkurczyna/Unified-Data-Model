using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class ComputationOfOneColumnCommand : Command
    {
        public delegate double Del(Object cellContent);
        List<Cell> newRows;
        Column column;
        Del del;
        public ComputationOfOneColumnCommand(Column column, Del del)
        {
            this.column = column;
            newRows = new List<Cell>();
            this.del = del;
        }
        public override Table Execute(Table table)
        {
                if (column.Type == DataType.StringDimension || column.Type == DataType.DateDimension) throw new BadColumnForComputationException();
                double newCellContent;
                foreach (Cell cell in column.Cells)
                {
                    newCellContent = del.Invoke((double)cell.Content);
                    newRows.Add(new Cell(newCellContent));
                }
                List<Column> newColumnList = new List<Column>();
                foreach (Column col in table.Columns)
                {
                    Column newCol = new Column(col.Name,col.Type);
                    foreach (Cell cell in col.Cells)
                    {
                        newCol.AddCell(new Cell(cell.Content));
                    }
                    newColumnList.Add(newCol);
                }
                
                Table newTable = new Table(table.Name, table, newColumnList);
                Column newColumn = new Column("Computation",DataType.FloatFact, newRows);
                newTable.AddColumn(newColumn);
                return newTable;

        }
    }
}
