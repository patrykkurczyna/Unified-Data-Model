using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class HorizontalJoinCommand : Command
    {
        protected Table secondTable;
        public HorizontalJoinCommand(Table table)
        {
            secondTable = table;
        }
        public override Table Execute(Table firstTable)
        {
            Table newTable = new Table(firstTable.Name,new List<AbstractColumn>(firstTable.Columns),firstTable);
            foreach (AbstractColumn column in secondTable.Columns)
            {
                bool found = false;
                foreach (AbstractColumn columnInFirst in firstTable.Columns)
                {
                    if (column.Name == columnInFirst.Name)
                        found = true;
                }
                if (!found) newTable.AddColumn(column);
            }
            return newTable.Normalize();
        }
    }
}
