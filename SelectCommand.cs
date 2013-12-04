using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class SelectCommand : Command
    {
        protected List<AbstractColumn> selectedColumns;
        protected List<int> selectedIndices;
        public SelectCommand(List<AbstractColumn> selectedColumns)
        {
            this.selectedColumns = selectedColumns;
        }
        //public SelectCommand(List<int> selectedIndeces)
        //{
        //    this.selectedIndices = selectedIndeces;
        //}

        public override Table Execute(Table table)
        {
            //List<AbstractColumn> columns;
            //if (selectedIndices == null)
            //{
            //    columns = selectedColumns;
            //}
            //else
            //{
            //    columns = new List<AbstractColumn>();
            //    foreach (int index in selectedIndices)
            //    {
            //        columns.Add(table.Columns[index]);
            //    }

            //}

            return new Table(table.Name, table.Columns.FindAll(delegate(AbstractColumn column)
                {
                    return (selectedColumns.IndexOf(column) != -1);
                }), table);

        }
    }
}
