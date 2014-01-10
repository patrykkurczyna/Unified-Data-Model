using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class ComputationOfTwoColumnsCommand : Command
    {
        public delegate double Del(Object firstCellContent, Object secondCellCOntent);
        List<Cell> newRows;
        Column column;
        Column column2;
        Del del;
        public ComputationOfTwoColumnsCommand(Column column, Column column2, Del del)
        {
            this.column = column;
            this.column2 = column2;
            newRows = new List<Cell>();
            this.del = del;
        }
        public override Table Execute(Table table)
        {
            if (column.Type == DataType.StringDimension || column.Type == DataType.DateDimension || column2.Type == DataType.StringDimension || column2.Type == DataType.DateDimension) throw new BadColumnForComputationException();
            double newCellContent;
            Cell secondCell;
            foreach (Cell cell in column.Cells)
            {
                secondCell = column2.Cells[column.Cells.IndexOf(cell)];
                newCellContent = del.Invoke((double)cell.Content, (double)secondCell.Content);
                newRows.Add(new Cell(newCellContent));
            }
            List<Column> newColumnList = new List<Column>();
            foreach (Column col in table.Columns)
            {
                Column newCol = new Column(col.Name, col.Type);
                foreach (Cell cell in col.Cells)
                {
                    newCol.AddCell(new Cell(cell.Content));
                }
                newColumnList.Add(newCol);
            }

            Table newTable = new Table(table.Name, table, newColumnList);
            Column newColumn = new Column("Computation", DataType.FloatFact, newRows);
            newTable.AddColumn(newColumn);
            return newTable;

        }
    }
}
